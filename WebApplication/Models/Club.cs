using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        [JsonIgnore] [NotMapped] public List<Athlete>? Athletes { get; set; }
    }
}