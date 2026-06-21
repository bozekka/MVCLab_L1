using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Riffnation.Models.Enums;

namespace Riffnation.Models;

public class Event
{
    public int Id { get; set; }

    [Required]
    [StringLength(150, MinimumLength = 2)]
    [Display(Name = "Nazwa wydarzeńia")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Rodzaj")]
    public EventType EventType { get; set; }

    [Display(Name = "Gatunek")]
    public MusicGenre Genre { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Data rozpoczęcia")]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Data zakończenia")]
    public DateTime? EndDate { get; set; }

    [Required]
    [StringLength(80)]
    [Display(Name = "Miasto")]
    public string City { get; set; } = string.Empty;

    [Range(1, 200_000)]
    [Display(Name = "Liczba miejsc")]
    public int Capacity { get; set; }

    [StringLength(1000)]
    [DataType(DataType.MultilineText)]
    [Display(Name = "Opis")]
    public string? Description { get; set; }

    [Range(0, 9999)]
    [Display(Name = "Stojace – plyta (zl)")]
    public int PriceStanding { get; set; }

    [Range(0, 9999)]
    [Display(Name = "Siedzace C (zl)")]
    public int PriceSeatedC { get; set; }

    [Range(0, 9999)]
    [Display(Name = "Siedzace B (zl)")]
    public int PriceSeatedB { get; set; }

    [Range(0, 9999)]
    [Display(Name = "Siedzace A – najlepszy widok (zl)")]
    public int PriceSeatedA { get; set; }

    [Range(0, 9999)]
    [Display(Name = "VIP (zl)")]
    public int PriceVip { get; set; }
 
    [Range(0, 9999)]
    [Display(Name = "Bilet jednodniowy (zl)")]
    public int PriceDayTicket { get; set; }
   
    [Range(0, 9999)]
    [Display(Name = "Karnet pelny (zl)")]
    public int PriceFullPass { get; set; }

    [Display(Name = "Miejsce")]
    public int? VenueId { get; set; }
    public Venue? Venue { get; set; }

    public ICollection<EventBand>    EventBands    { get; set; } = new List<EventBand>();
    public ICollection<Reservation>  Reservations  { get; set; } = new List<Reservation>();
    public ICollection<FestivalDay>  FestivalDays  { get; set; } = new List<FestivalDay>();


    [NotMapped] public int TicketPrice    => PriceStanding > 0 ? PriceStanding : PriceFullPass;
    [NotMapped] public int ReservedSeats  => Reservations?.Sum(r => r.NumberOfTickets) ?? 0;
    [NotMapped] public int AvailableSeats => Math.Max(0, Capacity - ReservedSeats);
    [NotMapped] public bool IsSoldOut     => AvailableSeats <= 0;
    [NotMapped] public bool IsMultiDay    => FestivalDays != null && FestivalDays.Count > 1;

    [NotMapped]
    public TicketStatus Status
    {
        get
        {
            var today   = DateTime.Today;
            var lastDay = (EndDate ?? StartDate).Date;
            if (lastDay < today)       return TicketStatus.SoldOut;
            if (AvailableSeats <= 0)   return TicketStatus.SoldOut;
            var days = (StartDate.Date - today).Days;
            if (days <= 14)            return TicketStatus.LowTickets;
            return TicketStatus.Available;
        }
    }

    [NotMapped] public bool CanReserve => Status != TicketStatus.SoldOut;

    public int PriceFor(TicketCategory cat)
    {
        switch (cat)
        {
            case TicketCategory.SeatedC:  return PriceSeatedC;
            case TicketCategory.SeatedB:  return PriceSeatedB;
            case TicketCategory.SeatedA:  return PriceSeatedA;
            case TicketCategory.Vip:      return PriceVip;
            default:                      return PriceStanding;
        }
    }
}
