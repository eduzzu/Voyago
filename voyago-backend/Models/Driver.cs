using System.ComponentModel.DataAnnotations;

namespace Voyago_Backend.Models
{
    public class Driver : User
    {
        public Car? DriverCar { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = null!;

    }
}