using System.Net.Mail;
using AppTask.Models;

namespace AppTask.API.Libraries.Emails
{
    public class EmailsAccessToken
    {
        private SmtpClient Client { get; set; }

        public EmailsAccessToken(SmtpClient smtp)
        {
            Client = smtp;
        }

        public void SendEmail(UserModel user)
        {
            var mailMessage = new MailMessage()
            {
                From = new MailAddress("angel_mata@estudante.sesisenai.org.br"),
                Subject = "AppTask - Access Token",
                Body = $@"
                <html>
                <body style='font-family: Arial, sans-serif;'>
                    <div style='background-color: #f4f4f4; padding: 20px; border-radius: 10px;'>
                        <h2 style='color: #333;'>App Task - Access Token</h2>
                        <p style='color: #555;'>This is your access token:</p>
                        <p style='font-size: 18px; color: #000;'><strong>{user.AcccessToken}</strong></p>
                        <p style='color: #777;'>Please use this token to access your account.</p>
                        <p style='color: #777;'>If you did not request this token, please ignore this email.</p>
                    </div>
                </body>
                </html>",
                IsBodyHtml = true,
            };
            mailMessage.To.Add(user.Email);
            Client.Send(mailMessage);
        }
    }
}
