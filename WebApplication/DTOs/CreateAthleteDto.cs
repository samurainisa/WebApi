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
        
        public int SportId { get; set; }
        public int SportPlaceId { get; set; }
        public int ClubId { get; set; }
        public int TrenerId { get; set; }
    }
}