using System.ComponentModel.DataAnnotations;


namespace KOLOS_2.Models;

public class Racer
{
    [Key] 
    public int RacerId { get; set; }

    [Required, MaxLength(50)] 
    public string FirstName { get; set; }

    [Required, MaxLength(100)] 
    public string LastName { get; set; }
    
    public ICollection<RaceParticipation> RaceParticipation { get; set; }



}