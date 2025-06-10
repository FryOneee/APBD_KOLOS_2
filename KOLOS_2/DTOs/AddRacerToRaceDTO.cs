namespace KOLOS_2.DTOs;

public class AddRacerToRaceDTO
{
    public string raceName { get; set; }
    public string trackName { get; set; }
    public List<AddParticipationDTO> participations { get; set; }
    
}

public class AddParticipationDTO
{
    public int racerId { get; set; }
    public int position { get; set; }
    public int finishTimeInSeconds { get; set; }
}