using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Riffnation.Data;
using Riffnation.Models;
using Riffnation.Models.Enums;

namespace Riffnation.Controllers;

public class ReservationsController : Controller
{
    private readonly ApplicationDbContext _db;
    private int? CurrentUserId => HttpContext.Session.GetInt32("UserId");

    public ReservationsController(ApplicationDbContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        if (CurrentUserId is null)
            return RedirectToAction("Login", "Account",
                new { returnUrl = Url.Action("Index", "Reservations") });

        var list = await _db.Reservations
            .Include(r => r.Event)
            .Where(r => r.AppUserId == CurrentUserId)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();
        return View(list);
    }

    public async Task<IActionResult> Create(int? eventId)
    {
        if (CurrentUserId is null)
            return RedirectToAction("Login", "Account",
                new { returnUrl = Url.Action("Create", "Reservations", new { eventId }) });

        Event? selectedEvent = null;
        if (eventId.HasValue)
            selectedEvent = await _db.Events
                .Include(e => e.FestivalDays)
                .FirstOrDefaultAsync(e => e.Id == eventId.Value);

        await PopulateEventsAsync(eventId);
        ViewBag.SelectedEvent = selectedEvent;
        return View(new Reservation { EventId = eventId ?? 0 });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("EventId,CustomerName,Email,NumberOfTickets,TicketCategory,FestivalDayId")] Reservation reservation)
    {
        if (CurrentUserId is null)
            return RedirectToAction("Login", "Account");

        var ev = await _db.Events
            .Include(e => e.Reservations)
            .Include(e => e.FestivalDays)
            .FirstOrDefaultAsync(e => e.Id == reservation.EventId);

        if (ev is null)
        {
            ModelState.AddModelError(nameof(Reservation.EventId), "Wybrane wydarzenie nie istnieje.");
        }
        else if (!ev.CanReserve)
        {
            ModelState.AddModelError("", "Na to wydarzenie nie można już zarezerwowac biletów.");
        }
        else if (reservation.NumberOfTickets > ev.AvailableSeats)
        {
            ModelState.AddModelError(nameof(Reservation.NumberOfTickets),
                "Brak tylu wolnych miejsc. Dostępne: " + ev.AvailableSeats);
        }

        if (reservation.TicketCategory == TicketCategory.DayTicket && reservation.FestivalDayId == null)
        {
            ModelState.AddModelError("", "Wybierz dzień festiwalu.");
        }

        int pricePerTicket = ComputePrice(ev, reservation.TicketCategory);
        if (pricePerTicket == 0)
        {
            ModelState.AddModelError("", "Wybrana kategoria nie jest dostępna dla tego wydarzenia.");
        }

        if (reservation.FestivalDayId.HasValue && ev != null)
        {
            var day = ev.FestivalDays.FirstOrDefault(d => d.Id == reservation.FestivalDayId.Value);
            if (day != null)
                reservation.FestivalDayLabel = day.Label + " – " + day.Date.ToString("dd.MM");
        }

        if (ModelState.IsValid)
        {
            reservation.AppUserId      = CurrentUserId;
            reservation.CreatedAt      = DateTime.Now;
            reservation.PricePerTicket = pricePerTicket;
            _db.Reservations.Add(reservation);
            await _db.SaveChangesAsync();
            TempData["Message"] = "Zarezerwowano " + reservation.NumberOfTickets + " bilet(y) na: " + ev!.Name;
            return RedirectToAction(nameof(Index));
        }

        await PopulateEventsAsync(reservation.EventId);
        ViewBag.SelectedEvent = ev;
        return View(reservation);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (CurrentUserId is null) return RedirectToAction("Login", "Account");
        if (id is null) return NotFound();
        var r = await _db.Reservations
            .Include(r => r.Event)
            .FirstOrDefaultAsync(r => r.Id == id && r.AppUserId == CurrentUserId);
        if (r is null) return NotFound();
        return View(r);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (CurrentUserId is null) return RedirectToAction("Login", "Account");
        var r = await _db.Reservations
            .FirstOrDefaultAsync(r => r.Id == id && r.AppUserId == CurrentUserId);
        if (r is not null) { _db.Reservations.Remove(r); await _db.SaveChangesAsync(); }
        TempData["Message"] = "Anulowano rezerwacje.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> GetPrices(int eventId)
    {
        var ev = await _db.Events
            .Include(e => e.FestivalDays)
            .FirstOrDefaultAsync(e => e.Id == eventId);
        if (ev is null) return Json(null);

        bool isFestival = ev.EventType == Riffnation.Models.Enums.EventType.Festival;
        bool isMultiDay = ev.FestivalDays != null && ev.FestivalDays.Count > 1;

        var days = ev.FestivalDays != null
            ? ev.FestivalDays
                .OrderBy(d => d.SortOrder)
                .Select(d => new { id = d.Id, label = d.Label, headliners = d.HeadlinersText, date = d.Date.ToString("dd.MM.yyyy") })
                .ToList<object>()
            : new List<object>();

        return Json(new
        {
            isFestival   = isFestival,
            isMultiDay   = isMultiDay,
            standing     = ev.PriceStanding,
            seatedC      = ev.PriceSeatedC,
            seatedB      = ev.PriceSeatedB,
            seatedA      = ev.PriceSeatedA,
            vip          = ev.PriceVip,
            dayTicket    = ev.PriceDayTicket,
            fullPass     = ev.PriceFullPass,
            available    = ev.AvailableSeats,
            days         = days,
        });
    }

    private static int ComputePrice(Event? ev, TicketCategory cat)
    {
        if (ev is null) return 0;
        switch (cat)
        {
            case TicketCategory.SeatedC:   return ev.PriceSeatedC;
            case TicketCategory.SeatedB:   return ev.PriceSeatedB;
            case TicketCategory.SeatedA:   return ev.PriceSeatedA;
            case TicketCategory.Vip:       return ev.PriceVip;
            case TicketCategory.FullPass:  return ev.PriceFullPass;
            case TicketCategory.DayTicket: return ev.PriceDayTicket;
            default:                       return ev.PriceStanding;
        }
    }

    private async Task PopulateEventsAsync(int? selectedId = null)
    {
        var events = await _db.Events.OrderBy(e => e.StartDate).ToListAsync();
        ViewBag.Events = new SelectList(
            events.Select(e => new
            {
                e.Id,
                Label = e.Name + " – " + e.StartDate.ToString("dd.MM.yyyy") + " (" + e.City + ")"
            }),
            "Id", "Label", selectedId);
    }
}
