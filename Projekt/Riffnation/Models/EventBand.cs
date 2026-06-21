using System.ComponentModel.DataAnnotations;

namespace Riffnation.Models;

public class EventBand
{
    public int EventId { get; set; }
    public Event Event { get; set; } = null!;

    public int BandId { get; set; }
    public Band Band { get; set; } = null!;

    [Display(Name = "Headliner")]
    public bool IsHeadliner { get; set; }
}
