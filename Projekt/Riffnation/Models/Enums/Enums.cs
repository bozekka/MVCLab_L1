using System.ComponentModel.DataAnnotations;

namespace Riffnation.Models.Enums;

public enum EventType
{
    [Display(Name = "Festiwal")]
    Festival,
    [Display(Name = "Koncert")]
    Concert
}

public enum TicketStatus
{
    [Display(Name = "Wyprzedane")]
    SoldOut,
    [Display(Name = "Ostatnie bilety")]
    LowTickets,
    [Display(Name = "Dostępne")]
    Available
}

public enum TicketCategory
{
    [Display(Name = "Stojace (plyta)")]
    Standing = 0,
    [Display(Name = "Siedzace C")]
    SeatedC = 1,
    [Display(Name = "Siedzace B")]
    SeatedB = 2,
    [Display(Name = "Siedzace A – najlepszy widok")]
    SeatedA = 3,
    [Display(Name = "VIP – strefa VIP + meet & greet")]
    Vip = 4,
    [Display(Name = "Karnet – wszystkie dni")]
    FullPass = 5,
    [Display(Name = "Bilet jednodniowy")]
    DayTicket = 6
}

public enum MusicGenre
{
    [Display(Name = "Heavy Metal")]         HeavyMetal,
    [Display(Name = "Thrash Metal")]        ThrashMetal,
    [Display(Name = "Death Metal")]         DeathMetal,
    [Display(Name = "Black Metal")]         BlackMetal,
    [Display(Name = "Doom Metal")]          DoomMetal,
    [Display(Name = "Power Metal")]         PowerMetal,
    [Display(Name = "Metalcore")]           Metalcore,
    [Display(Name = "Post-Hardcore")]       PostHardcore,
    [Display(Name = "Nu Metal")]            NuMetal,
    [Display(Name = "Metal alternatywny")]  AlternativeMetal,
    [Display(Name = "Punk / Pop-Punk")]     PunkRock,
    [Display(Name = "Hard Rock")]           HardRock,
    [Display(Name = "Rock / Alternatywa")]  Rock,
    [Display(Name = "Folk / Pagan Metal")]  FolkMetal,
    [Display(Name = "Gothic / Dark")]       Gothic
}
