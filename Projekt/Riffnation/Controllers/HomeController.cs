using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Riffnation.Data;

namespace Riffnation.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _db;

    public HomeController(ApplicationDbContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        var upcoming = await _db.Events
            .Include(e => e.Venue)
            .Include(e => e.Reservations)
            .OrderBy(e => e.StartDate)
            .Take(6)
            .ToListAsync();

        ViewBag.TotalEvents = await _db.Events.CountAsync();
        ViewBag.TotalBands = await _db.Bands.CountAsync();

        return View(upcoming);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View();
}
