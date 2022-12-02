using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Data.Models;

namespace WebApiClient.Data.Service
{
    public interface DataUseCases
    {
        Task<List<Sport>> GetSports(string token);

        Task<Sport> PostSport(Sport sport, string token);

        Task<List<Club>> GetClubs(string token);

        //post clubs
        Task<Club> PostClub(Club club, string token);
    }
}