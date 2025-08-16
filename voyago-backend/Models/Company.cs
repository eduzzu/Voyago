namespace Voyago_Backend.Models
{
    public class Company
    {
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;

        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; } = null!;
        public ICollection<Driver> Drivers { get; set; } = new List<Driver>();
    }
}