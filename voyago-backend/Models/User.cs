using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Voyago_Backend.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        private string HashedPassword { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.User;
        public Driver? Driver { get; set; }
        public Owner? Owner { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
         public ICollection<Trip> Trips { get; set; } = new List<Trip>();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public void SetPassword(string password)
        {
            HashedPassword = new PasswordHasher<User>().HashPassword(this, password);
        }

        public bool VerifyPassword(string password)
        {
            return new PasswordHasher<User>().VerifyHashedPassword(this, HashedPassword, password) == PasswordVerificationResult.Success;
        }
    }
    
}