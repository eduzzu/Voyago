using Voyago_Backend.Models;

namespace Voyago_Backend.DTOs
{
    public class TripDTO
    {
        public Guid TripId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public double Price { get; set; }
        public DateTime TripDate { get; set; }
        public string TripDescription { get; set; } = string.Empty;

        public List<UserDTO> UserTrips { get; set; } = new();


    }
}