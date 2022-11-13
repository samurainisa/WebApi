using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient.Data.Service
{
    public interface UserUseCases
    {
        Task<AuthInfo> LogIn(string login, string password);
        Task<string> Register(string login, string password);
    }
}