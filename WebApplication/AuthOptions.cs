using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication;

public class AuthOptions
{
    public const int LIFETIME = 200;
    public const string ISSUER = "MyAuthServer"; // издатель токена
    public const string AUDIENCE = "MyAuthClient"; // потребитель токена
    public const string KEY = "jCa5bmzMmUFolC5HiTC9QdImIteo7gmulrC28RMI";   // ключ для шифрования
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}