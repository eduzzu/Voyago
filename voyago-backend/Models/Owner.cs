using System.ComponentModel.DataAnnotations;

namespace Voyago_Backend.Models
{
    public class Owner : User
    {
        public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
        public User User { get; set; } = null!; 

    }
}