namespace Server.DTOs
{
    public class AuthResponseDto
    {
        public string access_token { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string? userID { get; set; }
    }
}