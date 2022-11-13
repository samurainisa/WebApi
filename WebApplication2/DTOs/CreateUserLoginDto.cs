namespace Server.DTOs
{
    public class CreateUserLoginDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
    }
}
