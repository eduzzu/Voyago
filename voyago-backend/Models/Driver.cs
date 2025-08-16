using System.ComponentModel.DataAnnotations;

namespace Voyago_Backend.Models
{
    public class Driver : User
    {
        public ICollection<Trip> DriverTrips { get; set; } = new List<Trip>();
        public Car? DriverCar { get; set; }
        public User User { get; set; } = null!; 
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = null!;

    }
}