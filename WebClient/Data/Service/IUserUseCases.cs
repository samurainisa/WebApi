using System.Threading.Tasks;
using WebClient.Data.Models;

namespace WebClient.Data.Service
{
    public interface IUserUseCases
    {
        Task<AuthInfo> LogIn(string login, string password);
        Task<string> Register(string login, string password);
    }
}