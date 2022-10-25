using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WebApplication2;
using static System.String;

namespace Server.Models
{
    public class SportPlace
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; } = Empty;
        public string Address { get; set; } = Empty;
        public string City { get; set; } = Empty;
        public string Country { get; set; } = Empty;
        public string CoverType { get; set; } = Empty;
        [JsonIgnore] [NotMapped] public List<Athlete>? Athletes { get; set; }
    }
}