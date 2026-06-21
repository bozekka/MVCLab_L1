using Microsoft.EntityFrameworkCore;
using Riffnation.Models;

namespace Riffnation.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Event>       Events       => Set<Event>();
    public DbSet<Venue>       Venues       => Set<Venue>();
    public DbSet<Band>        Bands        => Set<Band>();
    public DbSet<EventBand>   EventBands   => Set<EventBand>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<AppUser>     Users        => Set<AppUser>();
    public DbSet<FestivalDay> FestivalDays => Set<FestivalDay>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);

        mb.Entity<EventBand>().HasKey(eb => new { eb.EventId, eb.BandId });

        mb.Entity<EventBand>()
            .HasOne(eb => eb.Event).WithMany(e => e.EventBands)
            .HasForeignKey(eb => eb.EventId).OnDelete(DeleteBehavior.Cascade);

        mb.Entity<EventBand>()
            .HasOne(eb => eb.Band).WithMany(b => b.EventBands)
            .HasForeignKey(eb => eb.BandId).OnDelete(DeleteBehavior.Cascade);

        mb.Entity<Event>()
            .HasOne(e => e.Venue).WithMany(v => v.Events)
            .HasForeignKey(e => e.VenueId).OnDelete(DeleteBehavior.SetNull);

        mb.Entity<Reservation>()
            .HasOne(r => r.Event).WithMany(e => e.Reservations)
            .HasForeignKey(r => r.EventId).OnDelete(DeleteBehavior.Cascade);

        mb.Entity<Reservation>()
            .HasOne(r => r.AppUser).WithMany(u => u.Reservations)
            .HasForeignKey(r => r.AppUserId).OnDelete(DeleteBehavior.SetNull);

        mb.Entity<FestivalDay>()
            .HasOne(fd => fd.Event).WithMany(e => e.FestivalDays)
            .HasForeignKey(fd => fd.EventId).OnDelete(DeleteBehavior.Cascade);

        mb.Entity<AppUser>().HasIndex(u => u.Email).IsUnique();
    }
}
