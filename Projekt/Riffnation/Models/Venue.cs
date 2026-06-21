using System.ComponentModel.DataAnnotations;

namespace Riffnation.Models;

public class Venue
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Podaj nazwę miejsca.")]
    [StringLength(120, MinimumLength = 2, ErrorMessage = "Nazwa musi mieć od 2 do 120 znaków.")]
    [Display(Name = "Nazwa miejsca")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Podaj miasto.")]
    [StringLength(80)]
    [Display(Name = "Miasto")]
    public string City { get; set; } = string.Empty;

    [Range(1, 200_000, ErrorMessage = "Pojemność musi być dodatnia.")]
    [Display(Name = "Pojemność")]
    public int Capacity { get; set; }

    public ICollection<Event> Events { get; set; } = new List<Event>();
}
