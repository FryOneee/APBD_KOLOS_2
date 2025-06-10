// Services/PatientService.cs

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KOLOS_2.Data;
using KOLOS_2.Models;
using KOLOS_2.DTOs;

namespace KOLOS_2.Services;

public class UserRaces: IUserRaces
{
    private readonly AppDbContext _db;
    public UserRaces(AppDbContext db) => _db = db;

    public async Task<UserRaceInfoDTO> GetUserRaces(int racerId)
    {
        return await _db.Racers
            .Where(r => r.RacerId == racerId)
            .Select(r => new UserRaceInfoDTO
            {
                racerId = r.RacerId,
                firstName = r.FirstName,
                lastName = r.LastName,
                participations = r.RaceParticipation
                    .Select(p => new ParticipationDTO
                    {
                        race = new RaceDTO
                        {
                            name = p.TrackRace.Race.Name,
                            location = p.TrackRace.Race.Location,
                            date = p.TrackRace.Race.Date
                        },
                        track = new TrackDTO
                        {
                            name = p.TrackRace.Track.Name,
                            lengthInKm = p.TrackRace.Track.LengthInKm,
                        },
                        laps = p.TrackRace.Laps,
                        finishTimeInSeconds = p.FinishTimeInSeconds,
                        position = p.Position
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();
    }



// Services/PatientService.cs
// tylko metoda AddPrescription — poprawiona, bez użycia HasValue

    public async Task<bool> AddRacersToRace(AddRacerToRaceDTO request)
    {

        // 2. Pobierz pacjenta po Id (IdPatient jest typu int, nie nullable)
        var race = await _db.Racers.FindAsync(request.raceName);
        if (race == null)
            throw new KeyNotFoundException($"Race with name {request.raceName} does not exist");
        
        var track = await _db.Tracks.FindAsync(request.trackName);
        if (track == null)
            throw new KeyNotFoundException($"track with name {request.trackName} does not exist");



        // 4. Dla każdego leku w DTO: znajdź go i dodaj do PrescriptionMedicaments
        foreach (var p in request.participations)
        {
            // var medicament = await _db.Medicaments.FindAsync(md.idMedicament);
            // if (medicament == null)
            //     return false;
            
            var racer = await _db.Racers.FindAsync(race.RacerId);
            if (racer == null)
                throw new KeyNotFoundException($"racer with name {p.racerId} does not exist");


            var parcitipation = new RaceParticipation
            {
                RacerId = p.racerId,
                TrackRaceId = track.TrackId,
                FinishTimeInSeconds = p.finishTimeInSeconds,

                Position = p.position,


            };
            _db.RaceParticipations.Add(parcitipation);


        }

        // 5. Zapisz wszystkie zmiany naraz
        await _db.SaveChangesAsync();
        return true;
    }    



}