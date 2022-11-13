using Microsoft.IdentityModel.Tokens;
using System.Text;

public class AuthOptions
{
    public const int LIFETIME = 1000;
    public const string ISSUER = "MyAuthServer"; // �������� ������
    public const string AUDIENCE = "MyAuthClient"; // ����������� ������
    const string KEY = "jCa5bmzMmUFolC5HiTC9QdImIteo7gmulrC28RMI";   // ���� ��� ��������
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}