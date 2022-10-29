using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class UserRegisterRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; } = String.Empty;
        [Required, MinLength(6)]
        public string Password { get; set; } = String.Empty;
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = String.Empty;
    }
}