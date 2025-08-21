using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Voyago_Backend.Models
{
    public class Owner : User
    {
        public ICollection<Company>? Companies { get; set; } = new List<Company>();
    }
}