using System.ComponentModel.DataAnnotations;

namespace Riffnation.Models;


public class FestivalDay
{
    public int Id { get; set; }

    public int EventId { get; set; }
    public Event Event { get; set; } = null!;

    [Required]
    [Display(Name = "Data dnia")]
    public DateTime Date { get; set; }

    [StringLength(80)]
    [Display(Name = "Nazwa dnia")]
    public string? Label { get; set; } 

    [StringLength(500)]
    [Display(Name = "Headlinerzy dnia")]
    public string? HeadlinersText { get; set; } 

    public int SortOrder { get; set; }
}
