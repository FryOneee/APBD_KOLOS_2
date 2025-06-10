


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KOLOS_2.Models
{
    public class TrackRace
    {
        [Key]
        public int TrackRaceId { get; set; }

        public int RaceId { get; set; }
        public Race Race { get; set; }

        public int TrackId { get; set; }
        public Track Track { get; set; }

        public int Laps { get; set; }
        public int? BestTimeInSeconds { get; set; }

        public ICollection<RaceParticipation> RaceParticipations { get; set; }
    }
}