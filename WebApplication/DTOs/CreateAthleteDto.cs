namespace WebApplication.DTOs
{
    public class CreateAthleteDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ClubId { get; set; }
        public int SportId { get; set; }
        public int TrenerId { get; set; }
        public int SportPlaceId { get; set; }
    }
}