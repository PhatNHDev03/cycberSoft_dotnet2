using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using session40_52.Interfaces;

namespace session40_52.Services
{
    public class EmailService : IEmailService
    {
        // interface giup minh load bien moi truong tu file appsetting.json
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Sends an email to the specified email address with the specified subject and message body.
        /// </summary>
        /// <param name="email">The email address to send the email to.</param>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="message">The message body of the email.</param>
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            // b1 khoi tao mine kit
            var email = new MimeMessage(); // cua mineKit

            //b2:setup thong tin ng gui (from)
            email.From.Add(MailboxAddress.Parse(_configuration["EmailSettings:From"]));
            //b3:set up nguoi nhan
            email.To.Add(MailboxAddress.Parse(to));
            //b4 thong tin tieu de subject
            email.Subject = subject;
            //b5: setup noi dung email (body)
            var builder = new BodyBuilder
            {
                HtmlBody = body
            };
            email.Body = builder.ToMessageBody();
            //b6: thiết lập SMTP Client
            var smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync(_configuration["EmailSettings:SmtpServer"],
           int.Parse(_configuration["EmailSettings:Port"]), SecureSocketOptions.StartTls);
            // b7 authentication
            await smtpClient.AuthenticateAsync(_configuration["EmailSettings:Username"],
            _configuration["EmailSettings:Password"]);
            //b8: gui email
            await smtpClient.SendAsync(email);

            //b9 ngat ket noi
            await smtpClient.DisconnectAsync(true);
        }
    }
}