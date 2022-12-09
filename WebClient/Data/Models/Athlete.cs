namespace WebClient.Data.Models
{
    public class Athlete
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ClubId { get; set; }
        public string ClubName { get; set; }
        public int SportId { get; set; }
        public string SportName { get; set; }
        public int TrenerId { get; set; }
        public string TrenerName { get; set; }
        public int SportPlaceId { get; set; }
        public string SportPlaceName { get; set; }
    }
}