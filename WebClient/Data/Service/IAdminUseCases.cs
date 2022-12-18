using System.Collections.Generic;
using System.Threading.Tasks;
using WebClient.Data.Models;

namespace WebClient.Data.Service
{
    public interface IAdminUseCases : IBaseQuirues
    {
        //запросы для для удаления 
        Task<string> DeleteClub(Club clubname, string token);
        Task<List<UserData>> GetUsers(string token);
        Task<string> EditClub(Club club, string token);
        
        Task<string> DeleteSport(Sport sport, string token);
        Task<string> EditSport(Sport sport, string token);
        
        Task<string> DeleteSportPlace(SportPlaces sport, string token);
        Task<string> EditSportPlace(SportPlaces sport, string token);

        Task<string> DeleteTrener(Trener trener, string token);
        Task<string> EditTrener(Trener trener, string token);
        
        Task<string> DeleteAthlete(Athlete athlete, string token);
        Task<string> EditAthlete(Athlete athlete, string token);
        
        Task<string> DeleteUserLogins(UserData user, string token);
        Task<UserData> EditUserLogins(UserData user, string token);
    }
}