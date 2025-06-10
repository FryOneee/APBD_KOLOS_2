namespace KOLOS_2.DTOs;

public class UserRaceInfoDTO
{
    public int racerId { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public List<ParticipationDTO> participations { get; set; }
}

public class ParticipationDTO
{
    public RaceDTO race { get; set; }
    public TrackDTO track { get; set; }
    
    public int laps { get; set; }
    public int finishTimeInSeconds { get; set; }
    public int position { get; set; }
}


public class RaceDTO
{
    public string name { get; set; }
    public string location { get; set; }
    public DateTime date { get; set; }
}

public class TrackDTO
{
    public string name { get; set; }
    public decimal lengthInKm { get; set; }
}