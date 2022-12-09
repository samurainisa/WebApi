using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class UserLogin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Salt { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
        public User User { get; set; }
    }
}