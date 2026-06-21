using System.ComponentModel.DataAnnotations;
using Riffnation.Models.Enums;

namespace Riffnation.Models;

public class Band
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Podaj nazwę zespołu.")]
    [StringLength(120, MinimumLength = 1)]
    [Display(Name = "Nazwa zespołu")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Gatunek")]
    public MusicGenre Genre { get; set; }

    [StringLength(60)]
    [Display(Name = "Kraj")]
    public string? Country { get; set; }

    [StringLength(500)]
    [DataType(DataType.MultilineText)]
    [Display(Name = "Opis")]
    public string? Description { get; set; }

    public ICollection<EventBand> EventBands { get; set; } = new List<EventBand>();
}
 