using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Voyago_Backend.Models
{
    public class Owner : User
    {
        public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
        [JsonIgnore]
        public User User { get; set; } = null!; 

    }
}