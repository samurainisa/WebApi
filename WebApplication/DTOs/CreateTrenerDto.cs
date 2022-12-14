using System.Text.Json.Serialization;

namespace WebApplication.DTOs
{
    public class CreateTrenerDto
    {
        public string sportname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [JsonIgnore]
        public int SportId { get; set; }
    }
}