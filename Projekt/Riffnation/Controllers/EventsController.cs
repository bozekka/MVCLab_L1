using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Riffnation.Data;
using Riffnation.Models;
using Riffnation.Models.Enums;
using Riffnation.ViewModels;

namespace Riffnation.Controllers;

public class EventsController : Controller
{
    private readonly ApplicationDbContext _db;
    private bool IsAdmin => HttpContext.Session.GetString("IsAdmin") == "1";

    public EventsController(ApplicationDbContext db) => _db = db;

    public async Task<IActionResult> Index(
        string? searchString, MusicGenre? genre, EventType? eventType, string? city)
    {
        IQueryable<Event> q = _db.Events
            .Include(e => e.Venue)
            .Include(e => e.Reservations)
            .Include(e => e.EventBands).ThenInclude(eb => eb.Band);

        if (!string.IsNullOrWhiteSpace(searchString))
        {
            var s = searchString.Trim();
            q = q.Where(e => e.Name.Contains(s) || e.City.Contains(s) ||
                              e.EventBands.Any(eb => eb.Band.Name.Contains(s)));
        }
        if (genre.HasValue)     q = q.Where(e => e.Genre == genre.Value);
        if (eventType.HasValue) q = q.Where(e => e.EventType == eventType.Value);
        if (!string.IsNullOrWhiteSpace(city)) q = q.Where(e => e.City == city);

        var events = await q.OrderBy(e => e.StartDate).ToListAsync();
        var cities = await _db.Events.Select(e => e.City).Distinct().OrderBy(c => c).ToListAsync();

        return View(new EventListViewModel
        {
            Events = events, SearchString = searchString,
            Genre = genre, EventType = eventType, City = city, Cities = cities
        });
    }
     
    public async Task<IActionResult> Details(int? id)
    {
        if (id is null) return NotFound();
        var ev = await _db.Events
            .Include(e => e.Venue)
            .Include(e => e.Reservations)
            .Include(e => e.EventBands).ThenInclude(eb => eb.Band)
            .Include(e => e.FestivalDays)
            .FirstOrDefaultAsync(e => e.Id == id);
        if (ev is null) return NotFound();
        return View(ev);
    }

    public IActionResult Create()
    {
        if (!IsAdmin) return RedirectToAction("Index");
        PopulateVenues();
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Name,EventType,Genre,StartDate,EndDate,City,Capacity,TicketPrice,Description,VenueId")] Event ev)
    {
        if (!IsAdmin) return RedirectToAction("Index");
        if (ev.EndDate.HasValue && ev.EndDate.Value.Date < ev.StartDate.Date)
            ModelState.AddModelError(nameof(Event.EndDate), "Data zakończenia nie moze byc wczesniejsza niz rozpoczecia.");

        if (ModelState.IsValid)
        {
            _db.Add(ev);
            await _db.SaveChangesAsync();
            TempData["Message"] = "Dodano wydarzeńie: " + ev.Name;
            return RedirectToAction(nameof(Index));
        }
        PopulateVenues(ev.VenueId);
        return View(ev);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (!IsAdmin) return RedirectToAction("Index");
        if (id is null) return NotFound();
        var ev = await _db.Events.FindAsync(id);
        if (ev is null) return NotFound();
        PopulateVenues(ev.VenueId);
        return View(ev);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("Id,Name,EventType,Genre,StartDate,EndDate,City,Capacity,TicketPrice,Description,VenueId")] Event ev)
    {
        if (!IsAdmin) return RedirectToAction("Index");
        if (id != ev.Id) return NotFound();
        if (ev.EndDate.HasValue && ev.EndDate.Value.Date < ev.StartDate.Date)
            ModelState.AddModelError(nameof(Event.EndDate), "Data zakończenia nie moze byc wczesniejsza niz rozpoczecia.");

        if (ModelState.IsValid)
        {
            try { _db.Update(ev); await _db.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            { if (!await _db.Events.AnyAsync(e => e.Id == ev.Id)) return NotFound(); throw; }
            TempData["Message"] = "Zapisano zmiany w: " + ev.Name;
            return RedirectToAction(nameof(Index));
        }
        PopulateVenues(ev.VenueId);
        return View(ev);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (!IsAdmin) return RedirectToAction("Index");
        if (id is null) return NotFound();
        var ev = await _db.Events.Include(e => e.Venue).FirstOrDefaultAsync(e => e.Id == id);
        if (ev is null) return NotFound();
        return View(ev);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (!IsAdmin) return RedirectToAction("Index");
        var ev = await _db.Events.FindAsync(id);
        if (ev is not null) { _db.Events.Remove(ev); await _db.SaveChangesAsync(); }
        TempData["Message"] = "Usuńieto wydarzeńie.";
        return RedirectToAction(nameof(Index));
    }

    private void PopulateVenues(int? selectedId = null)
    {
        var venues = _db.Venues.OrderBy(v => v.City).ThenBy(v => v.Name).ToList();
        ViewBag.Venues = new SelectList(
            venues.Select(v => new { v.Id, Label = v.Name + " (" + v.City + ")" }),
            "Id", "Label", selectedId);
    }
}
