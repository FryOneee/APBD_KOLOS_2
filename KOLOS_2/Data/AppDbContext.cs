


using Microsoft.EntityFrameworkCore;
using KOLOS_2.Models;

namespace KOLOS_2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts)
            : base(opts)
        {
        }

        public DbSet<Racer> Racers { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<TrackRace> TrackRaces { get; set; }
        public DbSet<RaceParticipation> RaceParticipations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RaceParticipation>()
                .HasKey(rp => new { rp.RacerId, rp.TrackRaceId });
            
            


        }
    }
}