using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        [EmailAddress] public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
    }
}