
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace EmailProject.Service
{

    public class EmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendWellcomeEmailAsync(string email, string username)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Your App", _configuration["Email:From"]));
            message.To.Add(new MailboxAddress(username, email));
            message.Subject = "Welcome to Our App!";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $@"
                <h1>Welcome to Our App!</h1>
                <p>Dear {username},</p>
                <p>Thank you for registering with us. We're excited to have you on board!</p>
                <p>Best regards,<br>Your App Team</p>"
            };

            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync(
                _configuration["Email:SmtpServer"],
                int.Parse(_configuration["Email:Port"]),
                SecureSocketOptions.StartTls
            );

            await client.AuthenticateAsync(
                _configuration["Email:Username"],
                _configuration["Email:Password"]
            );

            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}