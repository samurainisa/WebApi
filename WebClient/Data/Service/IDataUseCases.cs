using System.Collections.Generic;
using System.Threading.Tasks;
using WebClient.Data.Models;

namespace WebClient.Data.Service
{
    public interface IDataUseCases
    {
        Task<List<Sport>> GetSports(string token);
        Task<Sport> PostSport(Sport sport, string token);


        Task<List<Club>> GetClubs(string token);
        Task<Club> PostClub(Club club, string token);

        Task<List<SportPlaces>> GetSportPlaces(string token);
        Task<SportPlaces> PostSportPlace(SportPlaces sportplace, string token);

        Task<List<Trener>> GetTreners(string token);
        Task<Trener> PostTrener(Trener trener, string token);
        Task<TrenerDto> PostTrenerDto(TrenerDto trener, string token);

        Task<List<Athlete>> GetAthletes(string token);
        Task<Athlete> PostAthlete(Athlete athlete, string token);
        Task<AthleteDto> PostAthleteDto(AthleteDto athlete, string token);
    }
}