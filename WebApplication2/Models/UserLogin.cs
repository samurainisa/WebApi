using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public class UserLogin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required, EmailAddress] public string Email { get; set; } = String.Empty;
        [Required] public string Password { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
        public User User { get; set; }
    }
}