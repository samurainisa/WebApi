namespace Server.DTOs
{
    public class CreateSportPlaceDto
    {
        public int Capacity { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CoverType { get; set; }
    }
}