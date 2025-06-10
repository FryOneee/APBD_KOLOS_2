


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



            modelBuilder.Entity<Race>().HasData(
                new Race
                {
                    RaceId = 0, Name = "British Grand Prix", Location = "Silverstone, UK",
                    Date = new DateTime(2025, 07, 14)
                },
                new Race
                {
                    RaceId = 1, Name = "Monaco Grand Prix", Location = "Monte Carlo, Monaco",
                    Date = new DateTime(2025, 05, 25)
                }
            );

            modelBuilder.Entity<Track>().HasData(
                new Track
                {
                    TrackId = 0,Name="Silverstone Circuit",LengthInKm = 6,
                },
                new Track
                {
                    TrackId = 1,Name="Monaco Circuit",LengthInKm = 3,

                }
                
                );
            
            
            modelBuilder.Entity<Race>().HasData(
                new TrackRace
                {
                    TrackRaceId = 0,TrackId = 1, RaceId = 1
                }
            );
            
            modelBuilder.Entity<TrackRace>().HasData(
                new TrackRace
                {
                    TrackRaceId = 0,TrackId = 0, RaceId = 0,Laps = 9, BestTimeInSeconds = 2137
                }
            );
            
            
            modelBuilder.Entity<RaceParticipation>().HasData(
                new RaceParticipation
                {
                    TrackRaceId = 0,RacerId = 0,FinishTimeInSeconds = 55555,Position = 3
                }
            );

            
            


            
            

            
            


        }
    }
}