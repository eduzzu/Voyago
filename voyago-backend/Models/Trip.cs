using System.ComponentModel.DataAnnotations;

namespace Voyago_Backend.Models
{
    public class Trip
    {
        public Guid TripId { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime Finish { get; set; }
        [Required]
        public double Price { get; set; }
        public DateTime TripDate { get; set; }
        public string TripDescription { get; set; } = string.Empty;
        public ICollection<User>? UserTrips{ get; set; } = new List<User>();
    }
}