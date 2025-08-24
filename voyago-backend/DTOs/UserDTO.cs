using Voyago_Backend.Models;

namespace Voyago_Backend.DTOs
{
    public class UserDTO
    {
        public Guid UserId { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = string.Empty;
        public List<TicketDTO> Tickets { get; set; } = new();
        public List<TripDTO> UserTrips { get; set; } = new();

    }
}