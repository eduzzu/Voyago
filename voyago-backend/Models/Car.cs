using System.ComponentModel.DataAnnotations;

namespace Voyago_Backend.Models
{
    public class Car
    {
        public Guid CarId { get; set; }
        [Required]
        public string CarName { get; set; } = null!;
        [Required]
        public string CarPlate { get; set; } = null!;
        public string CarDescription { get; set; } = string.Empty;
        public Guid? DriverId { get; set; }
        public Driver? CarDriver { get; set; } = null!;
        

    }
}