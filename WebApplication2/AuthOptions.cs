using Microsoft.IdentityModel.Tokens;
using System.Text;

public class AuthOptions
{
    public const int LIFETIME = 10000;
    public const string ISSUER = "MyAuthServer"; // издатель токена
    public const string AUDIENCE = "MyAuthClient"; // потребитель токена
    const string KEY = "jCa5bmzMmUFolC5HiTC9QdImIteo7gmulrC28RMI";   // ключ для шифрования
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}