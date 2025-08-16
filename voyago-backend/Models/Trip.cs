using System.ComponentModel.DataAnnotations;

namespace Voyago_Backend.Models
{
    public class Trip
    {
        public Guid TripId { get; set; }
        [Required]
        public string Start { get; set; } = string.Empty;
        [Required]
        public string Finish { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }
        public DateTime TripDate { get; set; }
        public string TripDescription { get; set; } = string.Empty;

        public Guid DriverId { get; set; }
        public User Driver { get; set; } = null!;
        public ICollection<User> UsersTrip { get; set; } = new List<User>();

        
    }
}