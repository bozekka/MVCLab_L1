using Riffnation.Models;
using Riffnation.Models.Enums;
using Riffnation.Helpers;

namespace Riffnation.Data;

public static class SeedData
{
    public static void Initialize(ApplicationDbContext db)
    {
        if (db.Events.Any()) return;

   
        var v = new Dictionary<string, Venue>
        {
            ["B90"]         = new Venue { Name = "Klub B90",                 City = "Gdańsk",            Capacity = 1500  },
            ["VooDoo"]      = new Venue { Name = "VooDoo Club",              City = "Warszawa",           Capacity = 800   },
            ["Stocznia"]    = new Venue { Name = "Stocznia Gdańska",         City = "Gdańsk",            Capacity = 25000 },
            ["Grod"]        = new Venue { Name = "Grod Rycerski",            City = "Byczyna",            Capacity = 3000  },
            ["Torwar"]      = new Venue { Name = "COS Torwar",               City = "Warszawa",           Capacity = 5000  },
            ["Narodowy"]    = new Venue { Name = "PGE Narodowy",             City = "Warszawa",           Capacity = 58000 },
            ["Kosakowo"]    = new Venue { Name = "Lotnisko Gdynia-Kosakowo", City = "Gdynia",             Capacity = 90000 },
            ["Bolkow"]      = new Venue { Name = "Zamek Bolkow",             City = "Bolków",             Capacity = 5000  },
            ["MOSiR"]       = new Venue { Name = "MOSiR im. W. Smolarka",    City = "Aleksandrów Łódzki", Capacity = 8000  },
            ["Atlas"]       = new Venue { Name = "Atlas Arena",              City = "Łódz",               Capacity = 13000 },
            ["Stodola"]     = new Venue { Name = "Klub Stodoła",             City = "Warszawa",           Capacity = 2500  },
            ["TauronArena"] = new Venue { Name = "Tauron Arena",             City = "Kraków",             Capacity = 15000 },
            ["NettoArena"]  = new Venue { Name = "Netto Arena",              City = "Szczecin",           Capacity = 5000  },
            ["Progresja"]   = new Venue { Name = "Letnia Scena Progresji",   City = "Warszawa",           Capacity = 6000  },
            ["Proxima"]     = new Venue { Name = "Klub Proxima",             City = "Warszawa",           Capacity = 1200  },
            ["Spodek"]      = new Venue { Name = "Spodek",                   City = "Katowice",           Capacity = 11000 },
            ["OperaLes"]    = new Venue { Name = "Opera Leśna",              City = "Sopot",              Capacity = 5000  },
        };
        db.Venues.AddRange(v.Values);
        db.SaveChanges();

        
        var b = new Dictionary<string, Band>
        {
            ["Korpiklaani"]   = new Band { Name = "Korpiklaani",          Genre = MusicGenre.FolkMetal,       Country = "Finlandia",       Description = "Fińscy mistrzowie folk metalu. Skrzypce, akordeon i pijackie chóry." },
            ["Finntroll"]     = new Band { Name = "Finntroll",            Genre = MusicGenre.FolkMetal,       Country = "Finlandia",       Description = "Trollowe black/folk metalowe szaleństwo z Helsinek." },
            ["ChristAgony"]   = new Band { Name = "Christ Agony",         Genre = MusicGenre.BlackMetal,      Country = "Polska",          Description = "Legenda polskiego black metalu od 1990 roku." },
            ["Trauma"]        = new Band { Name = "Trauma",               Genre = MusicGenre.DeathMetal,      Country = "Polska",          Description = "Polska ikona death metalu. Techniczne riffy i brutalna precyzja." },
            ["VirginSnatch"]  = new Band { Name = "Virgin Snatch",        Genre = MusicGenre.ThrashMetal,     Country = "Polska",          Description = "Warszawski thrash metal w najczystszej postaci." },
            ["Megadeth"]      = new Band { Name = "Megadeth",             Genre = MusicGenre.ThrashMetal,     Country = "USA",             Description = "Jeden z Wielkiej Czworki Thrash Metalu. Wirtuozeria i polityczne teksty." },
            ["Behemoth"]      = new Band { Name = "Behemoth",             Genre = MusicGenre.BlackMetal,      Country = "Polska",          Description = "Najsłynniejszy polski zespol metalowy na swiecie. Blackened death metal." },
            ["Anthrax"]       = new Band { Name = "Anthrax",              Genre = MusicGenre.ThrashMetal,     Country = "USA",             Description = "Jeden z Wielkiej Czworki Thrash Metalu. Energia od lat 80." },
            ["Mastodon"]      = new Band { Name = "Mastodon",             Genre = MusicGenre.HeavyMetal,      Country = "USA",             Description = "Progresywny metal z Atlanty. Epickie kompozycje." },
            ["BLS"]           = new Band { Name = "Black Label Society",  Genre = MusicGenre.HeavyMetal,      Country = "USA",             Description = "Zakk Wylde i jego ciezki, bluesowy metal." },
            ["Tankard"]       = new Band { Name = "Tankard",              Genre = MusicGenre.ThrashMetal,     Country = "Niemcy",          Description = "Frankfurccy thrashowcy – piwo, humor i szybka muzyka od 1982 r." },
            ["FooFighters"]   = new Band { Name = "Foo Fighters",         Genre = MusicGenre.Rock,            Country = "USA",             Description = "Dave Grohl i krolowie areny rockowej. Legenda alt-rocka." },
            ["Trivium"]       = new Band { Name = "Trivium",              Genre = MusicGenre.Metalcore,       Country = "USA",             Description = "Florydzki metalcore. Matt Heafy laczy thrash z melodia." },
            ["NickCave"]      = new Band { Name = "Nick Cave The Bad Seeds", Genre = MusicGenre.Rock,        Country = "Australia",       Description = "Poeta rocka. Mroczne ballady i niepowtarzalna charyzma." },
            ["IDLES"]         = new Band { Name = "IDLES",                Genre = MusicGenre.Rock,            Country = "Wielka Brytania", Description = "Bristolski post-punk nowej fali. Wsciekly i energetyczny." },
            ["JudasPriest"]   = new Band { Name = "Judas Priest",         Genre = MusicGenre.HeavyMetal,      Country = "Wielka Brytania", Description = "Metalowe Bogi z Birmingham. Rob Halford i klasyki heavy metalu." },
            ["Savatage"]      = new Band { Name = "Savatage",             Genre = MusicGenre.PowerMetal,      Country = "USA",             Description = "Ojcowie Trans-Siberian Orchestra. Dramatyczny power metal." },
            ["Satyricon"]     = new Band { Name = "Satyricon",            Genre = MusicGenre.BlackMetal,      Country = "Norwegia",        Description = "Norwescy pionierzy black metalu. Atmosfera polnocy." },
            ["Triptykon"]     = new Band { Name = "Triptykon",            Genre = MusicGenre.DoomMetal,       Country = "Szwajcaria",      Description = "Tom G. Warrior i jego doom/black metalowy projekt." },
            ["Nevermore"]     = new Band { Name = "Nevermore",            Genre = MusicGenre.PowerMetal,      Country = "USA",             Description = "Ponownie zjednoczeni – thrash/power metal z Seattle." },
            ["DeepPurple"]    = new Band { Name = "Deep Purple",          Genre = MusicGenre.HardRock,        Country = "Wielka Brytania", Description = "Smoke on the Water – pionierzy hard rocka od 1968." },
            ["IPrevail"]      = new Band { Name = "I Prevail",            Genre = MusicGenre.Metalcore,       Country = "USA",             Description = "Michiganski metalcore z podwojnymi wokalami." },
            ["Korn"]          = new Band { Name = "Korn",                 Genre = MusicGenre.NuMetal,         Country = "USA",             Description = "Twórcy nu metalu. Jonathan Davis i ikony lat 90." },
            ["TomWarrior"]    = new Band { Name = "Tom G. Warrior",       Genre = MusicGenre.BlackMetal,      Country = "Szwajcaria",      Description = "Ojciec extreme metalu – Celtic Frost, Hellhammer, Triptykon." },
            ["APC"]           = new Band { Name = "A Perfect Circle",     Genre = MusicGenre.Rock,            Country = "USA",             Description = "Projekt Maynarda Keenana (Tool). Mroczny alt-rock." },
            ["BMTH"]          = new Band { Name = "Bring Me The Horizon", Genre = MusicGenre.Metalcore,       Country = "Wielka Brytania", Description = "Najpopularniejsi metalcore'owcy XXI wieku. Throne, Can You Feel My Heart, Mantra." },
            ["KnockedLoose"]  = new Band { Name = "Knocked Loose",        Genre = MusicGenre.Metalcore,       Country = "USA",             Description = "Najbrutalniejszy hardcore nowej fali. Ogłuszające breakdowny." },
            ["LimpBizkit"]    = new Band { Name = "Limp Bizkit",          Genre = MusicGenre.NuMetal,         Country = "USA",             Description = "Fred Durst i nu-metalowy kult. Break Stuff, Rollin, My Way." },
            ["EccaVandal"]    = new Band { Name = "Ecca Vandal",          Genre = MusicGenre.Rock,            Country = "Australia",       Description = "Australijska wokalistka – hip-hop, elektronika i rockowa energia." },
            ["HollywoodUnd"]  = new Band { Name = "Hollywood Undead",     Genre = MusicGenre.NuMetal,         Country = "USA",             Description = "Maski, rapy i metalowe riffowanie. Swan Song i Bullet." },
            ["TheOffspring"]  = new Band { Name = "The Offspring",        Genre = MusicGenre.PunkRock,        Country = "USA",             Description = "Californijscy punkowi tytani. Ponad 40 mln sprzedanych plyt." },
            ["PapaRoach"]     = new Band { Name = "Papa Roach",           Genre = MusicGenre.NuMetal,         Country = "USA",             Description = "Last Resort, Scars, Broken Home – hymny calego pokolenia." },
            ["TheRasmus"]     = new Band { Name = "The Rasmus",           Genre = MusicGenre.Rock,            Country = "Finlandia",       Description = "Fińska alternatywa. In the Shadows grane do dzis." },
            ["BadOmens"]      = new Band { Name = "Bad Omens",            Genre = MusicGenre.AlternativeMetal,Country = "USA",             Description = "Blyskawicznie wzrastajacy alt-metal z Richmond, VA. Headliner Summer Punch 2026." },
            ["Babymetal"]     = new Band { Name = "BABYMETAL",            Genre = MusicGenre.Metalcore,       Country = "Japonia",         Description = "Kawaii metal – japońskie girlsband i heavy metal w jednym." },
            ["ThreeDaysGrace"]= new Band { Name = "Three Days Grace",     Genre = MusicGenre.Rock,            Country = "Kanada",          Description = "I Hate Everything About You, Animal I Have Become – hard rockowe hymny." },
            ["PalayeRoyale"]  = new Band { Name = "Palaye Royale",        Genre = MusicGenre.Rock,            Country = "USA",             Description = "Teatralni alt-rockowcy z Las Vegas." },
            ["Drabusheyka"]   = new Band { Name = "Drabusheyka",          Genre = MusicGenre.Rock,            Country = "Ukraina",         Description = "Ukrainskie trio laczace folk, punk i elektronikę." },
            ["Amorphis"]      = new Band { Name = "Amorphis",             Genre = MusicGenre.DeathMetal,      Country = "Finlandia",       Description = "Fińscy pionierzy melodic death metalu. Kalevala w muzyce." },
            ["Insomnium"]     = new Band { Name = "Insomnium",            Genre = MusicGenre.DeathMetal,      Country = "Finlandia",       Description = "Melodyjny death metal z melancholijna dusza." },
            ["Metallica"]     = new Band { Name = "Metallica",            Genre = MusicGenre.ThrashMetal,     Country = "USA",             Description = "Największy zespol metalowy wszech czasow. Enter Sandman, Master of Puppets." },
            ["Rammstein"]     = new Band { Name = "Rammstein",            Genre = MusicGenre.HeavyMetal,      Country = "Niemcy",          Description = "Niemieccy mistrzowie Neue Deutsche Harte. Ogien i pirotechnika." },
            ["Slipknot"]      = new Band { Name = "Slipknot",             Genre = MusicGenre.AlternativeMetal,Country = "USA",             Description = "9 muzykow, maski i najciezszy nu-metal świata. Duality, Psychosocial." },
            ["Architects"]    = new Band { Name = "Architects",           Genre = MusicGenre.Metalcore,       Country = "Wielka Brytania", Description = "Brightonski metalcore na najwyzszym poziomie technicznym." },
            ["Parkway"]       = new Band { Name = "Parkway Drive",        Genre = MusicGenre.Metalcore,       Country = "Australia",       Description = "Australijski metalcore stadium-level. Crushing riffy i epicki rozmach." },
            ["Gojira"]        = new Band { Name = "Gojira",               Genre = MusicGenre.DeathMetal,      Country = "Francja",         Description = "Twórcze progressive death metalu. Groove, brutalnosc i ekologiczne przeslanie." },
            ["SystemOfADown"] = new Band { Name = "System of a Down",     Genre = MusicGenre.AlternativeMetal,Country = "USA",             Description = "Chop Suey, B.Y.O.B., Toxicity – nie ma drugiego takiego brzmienia." },
            ["IronMaiden"]    = new Band { Name = "Iron Maiden",          Genre = MusicGenre.HeavyMetal,      Country = "Wielka Brytania", Description = "Bogowie heavy metalu i Eddie. The Trooper, Run to the Hills." },
            ["Billie"]        = new Band { Name = "Billie Eilish",        Genre = MusicGenre.Rock,            Country = "USA",             Description = "Popowa ikona pokolenia Z. Mroczne produkcje i hipnotyzujacy glos." },
            ["Fontaines"]     = new Band { Name = "Fontaines D.C.",       Genre = MusicGenre.Rock,            Country = "Irlandia",        Description = "Dublinskie post-punk objawienie. Gritty, poetyckie i intensywne." },
            ["MagnumMagnolia"]= new Band { Name = "Magnum Magnolia",      Genre = MusicGenre.Rock,            Country = "Polska",          Description = "Polska reprezentacja na Open'er. Alternatywny rock z ambicjami." },
            ["Wet"]           = new Band { Name = "Wet Leg",              Genre = MusicGenre.Rock,            Country = "Wielka Brytania", Description = "Indie rock z Isle of Wight. Cheeky Monkey i piekny minimalizm." },
            ["Lagwagon"]      = new Band { Name = "Lagwagon",             Genre = MusicGenre.PunkRock,        Country = "USA",             Description = "Skatepunkowa legenda z Fat Wreck Chords. Support na Lost Generation." },
        };
        db.Bands.AddRange(b.Values);
        db.SaveChanges();


        var mystic = AddFestival(db, b,
            "Mystic Festival 2026",
            new DateTime(2026, 6, 4), new DateTime(2026, 6, 7),
            "Gdansk", v["Stocznia"], 25000,
            standing: 749, vip: 1500, dayTicket: 249, fullPass: 749,
            "Największy festiwal metalowy w Polsce – 5 scen, ok. 90 zespołów na Stoczni Gdanskiej.",
            MusicGenre.ThrashMetal,
            new string[] { "Megadeth", "Behemoth", "BLS" },
            new string[] { "Megadeth", "Behemoth", "BLS", "Anthrax", "Mastodon" });

        AddDays(mystic, new DayInfo[]
        {
            new DayInfo { Label = "Dzień 1 – czwartek", Date = new DateTime(2026,6,4), Headliners = "Megadeth, Anthrax" },
            new DayInfo { Label = "Dzień 2 – piątek",   Date = new DateTime(2026,6,5), Headliners = "Behemoth, Mastodon" },
            new DayInfo { Label = "Dzień 3 – sobota",   Date = new DateTime(2026,6,6), Headliners = "Black Label Society" },
            new DayInfo { Label = "Dzień 4 – niedziela",Date = new DateTime(2026,6,7), Headliners = "Closing ceremony" },
        });

      
        var punch = AddFestival(db, b,
            "Summer Punch Festival 2026",
            new DateTime(2026, 6, 18), new DateTime(2026, 6, 19),
            "Warszawa", v["Progresja"], 6000,
            standing: 587, vip: 1199, dayTicket: 384, fullPass: 587,
            "Pierwsze Punch Festival w Warszawie! Metalcore, alt-metal i kawaii metal – dwa dni na Letniej Scenie Progresji.",
            MusicGenre.AlternativeMetal,
            new string[] { "BadOmens", "ThreeDaysGrace" },
            new string[] { "Babymetal", "ThreeDaysGrace", "PalayeRoyale", "Yonaka" });

        AddDays(punch, new DayInfo[]
        {
            new DayInfo { Label = "Dzień 1 – środa 18.06",  Date = new DateTime(2026,6,18), Headliners = "Bad Omens, BABYMETAL, Landmvrks, P.O.D., Set It Off, Bury Tomorrow" },
            new DayInfo { Label = "Dzień 2 – czwartek 19.06", Date = new DateTime(2026,6,19), Headliners = "Three Days Grace, Palaye Royale, Alexisonfire, Man With A Mission, Yonaka, Dead by April" },
        });

      
        var opener = AddFestival(db, b,
            "Open er Festival 2026",
            new DateTime(2026, 7, 1), new DateTime(2026, 7, 4),
            "Gdynia", v["Kosakowo"], 90000,
            standing: 899, vip: 1799, dayTicket: 359, fullPass: 899,
            "Największy festiwal w Polsce – cztery dni na lotnisku w Gdyni. Rock, pop, elektronika i metal.",
            MusicGenre.Rock,
            new string[] { "NickCave", "Billie" },
            new string[] { "NickCave", "IDLES", "Billie", "Fontaines", "MagnumMagnolia", "Wet" });

        AddDays(opener, new DayInfo[]
        {
            new DayInfo { Label = "Dzień 1 – środa 1.07",    Date = new DateTime(2026,7,1), Headliners = "Nick Cave and The Bad Seeds, Fontaines D.C." },
            new DayInfo { Label = "Dzień 2 – czwartek 2.07", Date = new DateTime(2026,7,2), Headliners = "Billie Eilish, Wet Leg" },
            new DayInfo { Label = "Dzień 3 – piątek 3.07",   Date = new DateTime(2026,7,3), Headliners = "IDLES, Magnum Magnolia" },
            new DayInfo { Label = "Dzień 4 – sobota 4.07",   Date = new DateTime(2026,7,4), Headliners = "Linkin Park, Leap, Hozier" },
        });

  
        var sdl = AddFestival(db, b,
            "Summer Dying Loud 2026",
            new DateTime(2026, 9, 3), new DateTime(2026, 9, 5),
            "Aleksandrow Lodzki", v["MOSiR"], 8000,
            standing: 459, vip: 999, dayTicket: 199, fullPass: 459,
            "17. edycja – 51 koncertow, trzy dni najciezszej muzyki świata.",
            MusicGenre.DeathMetal,
            new string[] { "Satyricon", "Triptykon", "Nevermore" },
            new string[] { "Satyricon", "Triptykon", "Nevermore" });

        AddDays(sdl, new DayInfo[]
        {
            new DayInfo { Label = "Czwartek 3.09",  Date = new DateTime(2026,9,3), Headliners = "Satyricon" },
            new DayInfo { Label = "Piątek 4.09",    Date = new DateTime(2026,9,4), Headliners = "Triptykon" },
            new DayInfo { Label = "Sobota 5.09",    Date = new DateTime(2026,9,5), Headliners = "Nevermore" },
        });

       
        AddFestival(db, b,
            "Lost Generation Festival 2026",
            new DateTime(2026, 6, 16), null,
            "Krakow", v["TauronArena"], 15000,
            standing: 389, vip: 849, dayTicket: 0, fullPass: 0,
            "Nostalgiczny festiwal: The Offspring, Papa Roach, The Rasmus, Hollywood Undead i Lagwagon.",
            MusicGenre.NuMetal,
            new string[] { "TheOffspring", "PapaRoach" },
            new string[] { "TheOffspring", "PapaRoach", "TheRasmus", "HollywoodUnd", "Lagwagon" });

        AddFestival(db, b,
            "Impact Festival 2026",
            new DateTime(2026, 6, 3), null,
            "Krakow", v["TauronArena"], 12000,
            standing: 349, vip: 799, dayTicket: 0, fullPass: 0,
            "Powrót legendarnego Impact Festival! Limp Bizkit jako headliner.",
            MusicGenre.NuMetal,
            new string[] { "LimpBizkit" },
            new string[] { "LimpBizkit", "EccaVandal", "Drabusheyka" });

        AddFestival(db, b,
            "Metal Kommando Fest IX",
            new DateTime(2026, 5, 9), null,
            "Warszawa", v["VooDoo"], 800,
            standing: 149, vip: 320, dayTicket: 0, fullPass: 0,
            "Dziewiata edycja kultowego festiwalu polskiej sceny ekstremalnej.",
            MusicGenre.BlackMetal,
            new string[] { "ChristAgony" },
            new string[] { "ChristAgony", "Trauma", "VirginSnatch" });

        AddFestival(db, b,
            "Heidenfest 2026",
            new DateTime(2026, 1, 13), null,
            "Gdansk", v["B90"], 1500,
            standing: 169, vip: 350, dayTicket: 0, fullPass: 0,
            "Trasa folk/pagan metalu. Korpiklaani i Finntroll razem na jednej scenie.",
            MusicGenre.FolkMetal,
            new string[] { "Korpiklaani", "Finntroll" },
            new string[] { "Korpiklaani", "Finntroll" });

        AddFestival(db, b,
            "Black Silesia Open Air IX",
            new DateTime(2026, 6, 12), new DateTime(2026, 6, 13),
            "Byczyna", v["Grod"], 3000,
            standing: 259, vip: 599, dayTicket: 149, fullPass: 259,
            "Swieto oldschoolowego metalu w Grodzie Rycerskim.",
            MusicGenre.ThrashMetal,
            new string[] { "Tankard" },
            new string[] { "Tankard" });

        AddFestival(db, b,
            "Castle Party 2026",
            new DateTime(2026, 7, 16), new DateTime(2026, 7, 18),
            "Bolkow", v["Bolkow"], 5000,
            standing: 349, vip: 749, dayTicket: 149, fullPass: 349,
            "Festiwal muzyki gothic i dark na dziedzincu zamku w Bolkowie.",
            MusicGenre.Gothic,
            new string[] { },
            new string[] { });

        AddFestival(db, b,
            "Death Ceremony 2026",
            new DateTime(2026, 10, 31), null,
            "Katowice", null, 1500,
            standing: 199, vip: 449, dayTicket: 0, fullPass: 0,
            "Halloweenowy festiwal extreme metalu w Katowicach. Tom G. Warrior solo.",
            MusicGenre.BlackMetal,
            new string[] { "TomWarrior" },
            new string[] { "TomWarrior" });

        AddConcert(db, b, "Bring Me The Horizon + Knocked Loose",
            new DateTime(2026,6,9), "Krakow", v["TauronArena"], 15000,
            369, 279, 349, 429, 899,
            "Największy metalcore event roku w Polsce. BMTH promuja Post Human: Nex Gen.",
            MusicGenre.Metalcore,
            new string[] { "BMTH" }, new string[] { "BMTH", "KnockedLoose" });

        AddConcert(db, b, "A Perfect Circle Tour 2026",
            new DateTime(2026,6,10), "Warszawa", v["Torwar"], 5000,
            299, 249, 319, 389, 699,
            "Maynard James Keenan w Warszawie. Mroczny alt-rock i niepowtarzalna atmosfera.",
            MusicGenre.Rock,
            new string[] { "APC" }, new string[] { "APC" });

        AddConcert(db, b, "Foo Fighters Tour 2026",
            new DateTime(2026,6,15), "Warszawa", v["Narodowy"], 58000,
            449, 349, 449, 549, 999,
            "Dave Grohl i Foo Fighters na PGE Narodowym. Everlong, The Pretender, Best of You.",
            MusicGenre.Rock,
            new string[] { "FooFighters" }, new string[] { "FooFighters" });

        AddConcert(db, b, "Trivium Tour 2026",
            new DateTime(2026,6,22), "Gdansk", v["B90"], 1500,
            219, 0, 0, 0, 499,
            "Florydzki metalcore w kameralnym B90.",
            MusicGenre.Metalcore,
            new string[] { "Trivium" }, new string[] { "Trivium" });

        AddConcert(db, b, "Metallica M72 World Tour Polska",
            new DateTime(2026,7,4), "Warszawa", v["Narodowy"], 55000,
            599, 449, 579, 699, 1499,
            "Metallica wraca do Polski! Enter Sandman, Master of Puppets i nowe utwory z 72 Seasons.",
            MusicGenre.ThrashMetal,
            new string[] { "Metallica" }, new string[] { "Metallica" });

        AddConcert(db, b, "Rammstein Polska 2026",
            new DateTime(2026,7,11), "Katowice", v["Spodek"], 11000,
            499, 379, 479, 579, 1199,
            "Niemieccy mistrzowie ognia i kontrowersji. Pelna pirotechnika.",
            MusicGenre.HeavyMetal,
            new string[] { "Rammstein" }, new string[] { "Rammstein" });

        AddConcert(db, b, "Slipknot 25 lat",
            new DateTime(2026,7,18), "Krakow", v["TauronArena"], 15000,
            449, 329, 429, 529, 1099,
            "25-lecie debiutanckiego albumu! Slipknot gra go w calosci plus klasyki.",
            MusicGenre.AlternativeMetal,
            new string[] { "Slipknot" }, new string[] { "Slipknot" });

        AddConcert(db, b, "Iron Maiden The Future Past Tour",
            new DateTime(2026,7,22), "Sopot", v["OperaLes"], 5000,
            429, 329, 419, 519, 1049,
            "Bruce Dickinson i Iron Maiden w Operze Lesnej w Sopocie.",
            MusicGenre.HeavyMetal,
            new string[] { "IronMaiden" }, new string[] { "IronMaiden" });

        AddConcert(db, b, "Judas Priest Tour 2026",
            new DateTime(2026,7,28), "Warszawa", v["Torwar"], 5000,
            379, 289, 369, 449, 899,
            "Rob Halford i Judas Priest. Leather Rebel, Breaking the Law, Painkiller.",
            MusicGenre.HeavyMetal,
            new string[] { "JudasPriest" }, new string[] { "JudasPriest" });

        AddConcert(db, b, "Gojira Kongres Mocy",
            new DateTime(2026,8,5), "Warszawa", v["Torwar"], 4000,
            279, 219, 279, 339, 699,
            "Francuscy wizjonerzy progressive death metalu.",
            MusicGenre.DeathMetal,
            new string[] { "Gojira" }, new string[] { "Gojira" });

        AddConcert(db, b, "System of a Down Reunion Tour",
            new DateTime(2026,8,14), "Warszawa", v["Narodowy"], 50000,
            529, 399, 519, 629, 1299,
            "Historyczny powrót System of a Down! Chop Suey, B.Y.O.B., Toxicity.",
            MusicGenre.AlternativeMetal,
            new string[] { "SystemOfADown" }, new string[] { "SystemOfADown" });

        AddConcert(db, b, "Savatage Summer Tour 2026",
            new DateTime(2026,8,11), "Warszawa", v["Torwar"], 5000,
            329, 249, 319, 399, 799,
            "Historyczny powrót Savatage po latach rozlaki.",
            MusicGenre.PowerMetal,
            new string[] { "Savatage" }, new string[] { "Savatage" });

        AddConcert(db, b, "Architects Warszawa 2026",
            new DateTime(2026,9,12), "Warszawa", v["Proxima"], 1200,
            249, 0, 0, 0, 549,
            "Kameralny klub Proxima i Architects.",
            MusicGenre.Metalcore,
            new string[] { "Architects" }, new string[] { "Architects" });

        AddConcert(db, b, "Parkway Drive Reverence Tour",
            new DateTime(2026,9,25), "Katowice", v["Spodek"], 8000,
            299, 229, 299, 369, 749,
            "Australijski metalcore na poziomie stadionowym.",
            MusicGenre.Metalcore,
            new string[] { "Parkway" }, new string[] { "Parkway" });

        AddConcert(db, b, "Amorphis i Insomnium",
            new DateTime(2026,9,20), "Warszawa", v["Torwar"], 3000,
            249, 189, 249, 309, 649,
            "Mistrzowie finskiego melodic death metalu.",
            MusicGenre.DeathMetal,
            new string[] { "Amorphis" }, new string[] { "Amorphis", "Insomnium" });

        AddConcert(db, b, "Deep Purple Tour 2026",
            new DateTime(2026,10,8), "Lodz", v["Atlas"], 13000,
            359, 269, 349, 429, 899,
            "Ian Gillan i Deep Purple w Atlas Arenie. Smoke on the Water na pelny regulator.",
            MusicGenre.HardRock,
            new string[] { "DeepPurple" }, new string[] { "DeepPurple" });

        AddConcert(db, b, "I Prevail Tour 2026",
            new DateTime(2026,10,12), "Warszawa", v["Stodola"], 2500,
            229, 0, 0, 0, 499,
            "Michiganski metalcore w kameralnej Stodole.",
            MusicGenre.Metalcore,
            new string[] { "IPrevail" }, new string[] { "IPrevail" });

        AddConcert(db, b, "Korn Tour 2026",
            new DateTime(2026,11,17), "Krakow", v["TauronArena"], 10000,
            389, 299, 379, 469, 949,
            "Jonathan Davis i Korn w Tauron Arenie. Freak on a Leash, Blind.",
            MusicGenre.NuMetal,
            new string[] { "Korn" }, new string[] { "Korn" });

        db.SaveChanges();

        var admin = new AppUser { FullName = "Admin Riffnation", Email = "admin@riffnation.pl", PasswordHash = PasswordHelper.Hash("Admin123!"), IsAdmin = true,  CreatedAt = DateTime.Now };
        var demo  = new AppUser { FullName = "Jan Demo",         Email = "demo@riffnation.pl",  PasswordHash = PasswordHelper.Hash("Demo123!"),  IsAdmin = false, CreatedAt = DateTime.Now };
        db.Users.AddRange(admin, demo);
        db.SaveChanges();

        var punch2 = db.Events.First(e => e.Name.Contains("Summer Punch"));
        db.Reservations.Add(new Reservation
        {
            EventId = punch2.Id, AppUserId = demo.Id,
            CustomerName = demo.FullName, Email = demo.Email,
            NumberOfTickets = 1, TicketCategory = TicketCategory.FullPass,
            PricePerTicket = punch2.PriceFullPass,
        });
        db.SaveChanges();
    }


    private class DayInfo
    {
        public string Label      { get; set; } = "";
        public DateTime Date     { get; set; }
        public string Headliners { get; set; } = "";
    }

    private static Event AddFestival(
        ApplicationDbContext db, Dictionary<string, Band> bands,
        string name, DateTime start, DateTime? end, string city, Venue? venue, int cap,
        int standing, int vip, int dayTicket, int fullPass,
        string desc, MusicGenre genre,
        string[] headliners, string[] allBands)
    {
        var ev = new Event
        {
            Name = name, EventType = EventType.Festival, Genre = genre,
            StartDate = start, EndDate = end, City = city,
            Venue = venue, Capacity = cap, Description = desc,
            PriceStanding = standing, PriceVip = vip,
            PriceDayTicket = dayTicket, PriceFullPass = fullPass,
        };
        foreach (var key in allBands)
            if (bands.ContainsKey(key))
                ev.EventBands.Add(new EventBand { Band = bands[key], IsHeadliner = Array.IndexOf(headliners, key) >= 0 });
        db.Events.Add(ev);
        db.SaveChanges();
        return ev;
    }

    private static void AddDays(Event ev, DayInfo[] days)
    {
        for (int i = 0; i < days.Length; i++)
        {
            ev.FestivalDays.Add(new FestivalDay
            {
                Date           = days[i].Date,
                Label          = days[i].Label,
                HeadlinersText = days[i].Headliners,
                SortOrder      = i,
            });
        }
    }

    private static void AddConcert(
        ApplicationDbContext db, Dictionary<string, Band> bands,
        string name, DateTime start, string city, Venue? venue, int cap,
        int standing, int seatedC, int seatedB, int seatedA, int vip,
        string desc, MusicGenre genre,
        string[] headliners, string[] allBands)
    {
        var ev = new Event
        {
            Name = name, EventType = EventType.Concert, Genre = genre,
            StartDate = start, City = city,
            Venue = venue, Capacity = cap, Description = desc,
            PriceStanding = standing, PriceSeatedC = seatedC,
            PriceSeatedB  = seatedB, PriceSeatedA  = seatedA,
            PriceVip      = vip,
        };
        foreach (var key in allBands)
            if (bands.ContainsKey(key))
                ev.EventBands.Add(new EventBand { Band = bands[key], IsHeadliner = Array.IndexOf(headliners, key) >= 0 });
        db.Events.Add(ev);
    }
}
