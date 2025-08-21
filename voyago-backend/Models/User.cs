using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Voyago_Backend.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        private string HashedPassword { get; set; } = string.Empty;
        [Required]
        public DateOnly DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = string.Empty;
        
        public ICollection<Ticket>? Tickets { get; set; } = new List<Ticket>();
        public ICollection<Trip>? UserTrips { get; set; } = new List<Trip>();

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

         public string? ResetPasswordToken { get; set; }
         public DateTime? ResetPasswordTokenExpires { get; set; }

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