using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static System.String;

namespace WebApplication.Models
{
    public class Trener
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = Empty;
        public string LastName { get; set; } = Empty;
        [JsonIgnore] public Sport? Sport { get; set; }
        public int SportId { get; set; }
        [JsonIgnore] [NotMapped] public List<Athlete>? Athletes { get; set; }
    }
}