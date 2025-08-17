
using System.Net;
using System.Net.Mail;

namespace Voyago_Backend.Services
{
    public class EmailService(IConfiguration configuration) : IEmailService
    {
        public async Task SendEmail(string toEmail, string subject, string body)
        {
            var from = configuration["EmailSettings:From"];
            var smtpServer = configuration["EmailSettings:SmtpServer"];
            var port = int.Parse(configuration["EmailSettings:Port"]!);
            var username = configuration["EmailSettings:Username"];
            var password = configuration["EmailSettings:Password"];

            var message = new MailMessage(from!, toEmail, subject, body);
            message.IsBodyHtml = true;

            using var client = new SmtpClient(smtpServer, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };

            await client.SendMailAsync(message);
        }
    }
}