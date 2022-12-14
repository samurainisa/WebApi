using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication;

public class AuthOptions
{
    public const int LIFETIME = 200;
    public const string ISSUER = "MyAuthServer"; // �������� ������
    public const string AUDIENCE = "MyAuthClient"; // ����������� ������
    public const string KEY = "jCa5bmzMmUFolC5HiTC9QdImIteo7gmulrC28RMI";   // ���� ��� ����������
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}