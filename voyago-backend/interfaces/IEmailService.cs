namespace Voyago_Backend.Services
{
      public interface IEmailService
    {
        Task SendEmail(string toEmail, string subject, string body);
    }
}