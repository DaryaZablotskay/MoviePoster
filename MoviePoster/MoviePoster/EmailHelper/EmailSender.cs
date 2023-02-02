using MailKit.Security;
using MimeKit;
using MoviePoster.EmailHelper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.EmailHelper
{
    public class EmailSender : IEmailSender
    {
        public async Task Send(string place, DateTime date, string userEmail, string film)
        {
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(MailboxAddress.Parse("dasaz659@gmail.com"));
            emailMessage.To.Add(MailboxAddress.Parse(userEmail));
            emailMessage.Subject = "Билет";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"Вы забронировали место {place} на {date} на {film}"
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("dasaz659@gmail.com", "nfpkbwchcrfmtilq");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
