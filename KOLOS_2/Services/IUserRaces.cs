using KOLOS_2.Models;
using KOLOS_2.DTOs;



namespace KOLOS_2.Services;

public interface IUserRaces
{
    Task<UserRaceInfoDTO> GetUserRaces(int idPatient);
    Task<bool> AddRacersToRace(AddRacerToRaceDTO req);

}