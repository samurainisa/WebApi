using System.Text.Json.Serialization;
using static System.String;

namespace WebApplication.Models
{
    public class Athlete
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = Empty;
        public string LastName { get; set; } = Empty;
        
        [JsonIgnore] public Club? Club { get; set; }
        public int ClubId { get; set; }

        [JsonIgnore] public Sport? Sport { get; set; }
        public int SportId { get; set; }

        [JsonIgnore] public Trener? Trener { get; set; }
        public int TrenerId { get; set; }

        [JsonIgnore] public SportPlace? SportPlace { get; set; }

        public int SportPlaceId { get; set; }
    }
}