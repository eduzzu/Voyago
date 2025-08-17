using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Voyago_Backend.Models
{
    public class Driver : User
    {
        public Car? DriverCar { get; set; }
        [JsonIgnore]
        public User User { get; set; } = null!; 
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = null!;

    }
}