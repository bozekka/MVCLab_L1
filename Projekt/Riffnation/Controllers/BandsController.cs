using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Riffnation.Data;
using Riffnation.Models;

namespace Riffnation.Controllers;

public class BandsController : Controller
{
    private readonly ApplicationDbContext _db;
    private bool IsAdmin => HttpContext.Session.GetString("IsAdmin") == "1";

    public BandsController(ApplicationDbContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        var bands = await _db.Bands.OrderBy(b => b.Name).ToListAsync();
        return View(bands);
    }
     
    public IActionResult Create()
    {
        if (!IsAdmin) return RedirectToAction("Index");
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Genre,Country,Description")] Band band)
    {
        if (!IsAdmin) return RedirectToAction("Index");
        if (ModelState.IsValid)
        {
            _db.Bands.Add(band);
            await _db.SaveChangesAsync();
            TempData["Message"] = "Dodano zespół: " + band.Name;
            return RedirectToAction(nameof(Index));
        }
        return View(band);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (!IsAdmin) return RedirectToAction("Index");
        if (id is null) return NotFound();
        var band = await _db.Bands.FindAsync(id);
        if (band is null) return NotFound();
        return View(band);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("Id,Name,Genre,Country,Description")] Band band)
    {
        if (!IsAdmin) return RedirectToAction("Index");
        if (id != band.Id) return NotFound();
        if (ModelState.IsValid)
        {
            _db.Update(band);
            await _db.SaveChangesAsync();
            TempData["Message"] = "Zapisano zmiany w: " + band.Name;
            return RedirectToAction(nameof(Index));
        }
        return View(band);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (!IsAdmin) return RedirectToAction("Index");
        if (id is null) return NotFound();
        var band = await _db.Bands.FirstOrDefaultAsync(b => b.Id == id);
        if (band is null) return NotFound();
        return View(band);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (!IsAdmin) return RedirectToAction("Index");
        var band = await _db.Bands.FindAsync(id);
        if (band is not null) { _db.Bands.Remove(band); await _db.SaveChangesAsync(); }
        TempData["Message"] = "Usunięto zespół.";
        return RedirectToAction(nameof(Index));
    }
}
