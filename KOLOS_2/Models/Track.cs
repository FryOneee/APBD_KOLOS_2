

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KOLOS_2.Models
{
    public class Track
    {
        [Key]
        public int TrackId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal LengthInKm { get; set; }

        public ICollection<TrackRace> TrackRaces { get; set; }
    }
}