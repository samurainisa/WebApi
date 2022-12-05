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

        Task<List<SportPlaces>> GetSportPlaces(string token);

        Task<Sport> PostSport(Sport sport, string token);

        Task<List<Club>> GetClubs(string token);

        Task<Club> PostClub(Club club, string token);
        Task<SportPlaces> PostSportPlace(SportPlaces sportplace, string token);
    }
}