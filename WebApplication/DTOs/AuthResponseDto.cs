namespace WebApplication.DTOs
{
    public class AuthResponseDto
    {
        public string access_token { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string? userID { get; set; }
    }
}