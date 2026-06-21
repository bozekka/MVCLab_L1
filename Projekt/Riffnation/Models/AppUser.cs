using System.ComponentModel.DataAnnotations;

namespace Riffnation.Models;

public class AppUser
{
    public int Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 3)]
    [Display(Name = "Imię i nazwisko")]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(120)]
    [Display(Name = "E-mail")]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    public bool IsAdmin { get; set; } = false;

    [Display(Name = "Data rejestracji")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
