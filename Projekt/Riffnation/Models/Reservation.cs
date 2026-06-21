using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Riffnation.Models.Enums;

namespace Riffnation.Models;

public class Reservation
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Wybierz wydarzenie.")]
    public int EventId { get; set; }
    public Event? Event { get; set; }

    public int? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    [Required(ErrorMessage = "Podaj imię i nazwisko.")]
    [StringLength(100, MinimumLength = 3)]
    [Display(Name = "Imię i nazwisko")]
    public string CustomerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Podaj adres e-mail.")]
    [EmailAddress]
    [Display(Name = "E-mail")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Kategoria biletu")]
    public TicketCategory TicketCategory { get; set; } = TicketCategory.Standing;

    [Display(Name = "Dzień festiwalu")]
    public int? FestivalDayId { get; set; }

    [StringLength(120)]
    public string? FestivalDayLabel { get; set; }

    [Range(1, 10)]
    [Display(Name = "Liczba biletów")]
    public int NumberOfTickets { get; set; } = 1;

    [Display(Name = "Cena za bilet (zl)")]
    public int PricePerTicket { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [NotMapped]
    public int TotalPrice => PricePerTicket * NumberOfTickets;
}
