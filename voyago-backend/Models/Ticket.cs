using System.ComponentModel.DataAnnotations;

namespace Voyago_Backend.Models
{
    public class Ticket
    {
        public Guid TicketId { get; set; }
        [Required]
        public Trip TicketTrip { get; set; } = null!;
        public DateTime BuyDate { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;


    }
}