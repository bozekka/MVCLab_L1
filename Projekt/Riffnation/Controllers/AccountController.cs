using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Riffnation.Data;
using Riffnation.Helpers;
using Riffnation.Models;
using Riffnation.ViewModels;

namespace Riffnation.Controllers;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _db;
    private const string SessionUserId   = "UserId";
    private const string SessionUserName = "UserName";
    private const string SessionIsAdmin  = "IsAdmin";

    public AccountController(ApplicationDbContext db) => _db = db;
  
    public IActionResult Register() =>
        IsLoggedIn() ? RedirectToAction("Index", "Home") : View();

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel vm)
    {
        if (ModelState.IsValid)
        {
            if (await _db.Users.AnyAsync(u => u.Email == vm.Email))
            {
                ModelState.AddModelError(nameof(vm.Email), "Ten adres e-mail jest już zajęty.");
                return View(vm);
            }
            var user = new AppUser
            {
                FullName     = vm.FullName,
                Email        = vm.Email,
                PasswordHash = PasswordHelper.Hash(vm.Password),
                CreatedAt    = DateTime.Now
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            SignIn(user);
            TempData["Message"] = "Konto zostało utworzone. Witaj, " + user.FullName + "!";
            return RedirectToAction("Index", "Home");
        }
        return View(vm);
    }

    public IActionResult Login(string? returnUrl = null)
    {
        if (IsLoggedIn()) return RedirectToAction("Index", "Home");
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel vm, string? returnUrl = null)
    {
        if (ModelState.IsValid)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == vm.Email);
            if (user is null || !PasswordHelper.Verify(vm.Password, user.PasswordHash))
            {
                ModelState.AddModelError(string.Empty, "Nieprawidłowy e-mail lub hasło.");
                return View(vm);
            }
            SignIn(user);
            TempData["Message"] = "Zalogowano jako " + user.FullName +
                                  (user.IsAdmin ? " [Admin]" : "") + ".";
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction("Index", "Home");
        }
        return View(vm);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        TempData["Message"] = "Wylogowano.";
        return RedirectToAction("Index", "Home");
    }

    private void SignIn(AppUser user)
    {
        HttpContext.Session.SetInt32(SessionUserId,   user.Id);
        HttpContext.Session.SetString(SessionUserName, user.FullName);
        HttpContext.Session.SetString(SessionIsAdmin,  user.IsAdmin ? "1" : "0");
    }

    private bool IsLoggedIn() =>
        HttpContext.Session.GetInt32(SessionUserId).HasValue;
}
