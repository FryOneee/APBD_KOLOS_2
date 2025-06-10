


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KOLOS_2.Models
{
    public class Race
    {
        [Key]
        public int RaceId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Location { get; set; }

        public DateTime Date { get; set; }

        public ICollection<TrackRace> TrackRaces { get; set; }
    }
}