using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace KOLOS_2.Models;

public class Doctor_Przykladowy
{
    [Key]
    public int IdDoctor { get; set; }
    
    [Required, MaxLength(100)]
    public string FirstName { get; set; }
    
    [Required, MaxLength(100)]
    public string LastName { get; set; }
    
    [Required, MaxLength(100)]
    public string Email { get; set; }
}