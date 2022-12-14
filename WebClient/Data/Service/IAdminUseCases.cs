using System.Collections.Generic;
using System.Threading.Tasks;
using WebClient.Data.Models;

namespace WebClient.Data.Service
{
    public interface IAdminUseCases : IBaseQuirues
    {
        //запросы для для удаления 
        Task<string> DeleteClub(Club clubname, string token);
    }
}