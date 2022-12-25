using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication.Models
{
    public class UserLogin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }
        public User? User { get; set; }
    }
}