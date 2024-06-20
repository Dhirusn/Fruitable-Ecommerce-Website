using System.Net.Mail;
using System.Net;
using Fruitable.Data.Models;

namespace Fruitable.Repositry.Email
{
    public class EmailRepositry : IEmailRepositry
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            // Implement email sending logic using SMTP, SendGrid, etc.
            // Example using SMTP (you'll need to configure your SMTP settings):
            try
            {
                using var client = new SmtpClient();
                var emailMessage = new MailMessage
                {
                    From = new MailAddress("Dhirendra.academy@outlook.com"),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true,
                };
                emailMessage.To.Add(email);

                // Configure your SMTP settings here
                client.Host = "smtp.outlook.com";
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("Dhirendra.academy@outlook.com", "15042001Dd#");
                client.EnableSsl = true;

                await client.SendMailAsync(emailMessage);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task SendEmailConfirmationAsync(ApplicationUser user, string otp)
        {
            // Construct the email message with OTP
            string emailSubject = "Email Confirmation OTP";
            string emailMessage = $"Your OTP for email confirmation is: {otp}";

            // Send email using your email sender service
            await SendEmailAsync(user.Email!, emailSubject, emailMessage);
        }
    }
}
