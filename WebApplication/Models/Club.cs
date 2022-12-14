using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore] [NotMapped] public List<Athlete>? Athletes { get; set; }
    }
}