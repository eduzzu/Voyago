using Voyago_Backend.Models;

namespace Voyago_Backend.DTOs
{
    public class TicketDTO
    {
        public Guid TicketId { get; set; }
        public TripDTO TicketTrip { get; set; } = new();
        public DateTime BuyDate { get; set; }

        public Guid UserId { get; set; }
        public UserDTO User { get; set; } = new();

    }
}