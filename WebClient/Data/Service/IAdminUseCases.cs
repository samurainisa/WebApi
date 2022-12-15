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
        
        
    }
}