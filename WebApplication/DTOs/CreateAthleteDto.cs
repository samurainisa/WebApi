using System.Text.Json.Serialization;

namespace WebApplication.DTOs
{
    public class CreateAthleteDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClubName { get; set; }
        public string SportName { get; set; }
        public string TrenerName { get; set; }
        public string SportPlaceName { get; set; }

        [Newtonsoft.Json.JsonIgnore][JsonIgnore] public int SportId { get; set; }
        [Newtonsoft.Json.JsonIgnore][JsonIgnore] public int SportPlaceId { get; set; }
        [Newtonsoft.Json.JsonIgnore][JsonIgnore] public int ClubId { get; set; }
        [Newtonsoft.Json.JsonIgnore][JsonIgnore] public int TrenerId { get; set; }
    }
}