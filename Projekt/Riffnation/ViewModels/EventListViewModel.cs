using Riffnation.Models;
using Riffnation.Models.Enums;

namespace Riffnation.ViewModels;


public class EventListViewModel
{
    public IEnumerable<Event> Events { get; set; } = new List<Event>();

   
    public string? SearchString { get; set; }
    public MusicGenre? Genre { get; set; }
    public EventType? EventType { get; set; }
    public string? City { get; set; }

    public IEnumerable<string> Cities { get; set; } = new List<string>();
}
