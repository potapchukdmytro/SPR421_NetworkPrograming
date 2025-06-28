using System.Net;
using System.Net.Mail;

namespace _04_smtp
{
    public class MailService
    {
        private SmtpClient smtpClient;
        private string host;
        private int port;
        private string email;
        private string password;

        public MailService(string host, int port, string email, string password)
        {
            this.host = host;
            this.port = port;
            this.email = email;
            this.password = password;
            smtpClient = new SmtpClient(host, port);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(email, password);
        }

        public async Task SendEmailAsync(MailMessage message)
        {
            await smtpClient.SendMailAsync(message);
        }

        public async Task SendEmailAsync(string[] to, string subject, string body, bool isHtml = false)
        {
            await SendEmailAsync(to, subject, body, new Attachment[0], isHtml);
        }

        public async Task SendEmailAsync(string[] to, string subject, string body, Attachment[] attachments, bool isHtml = false)
        {
            var message = new MailMessage();
            message.From = new MailAddress(email);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = isHtml;

            foreach (var t in to)
            {
                message.To.Add(t);
            }

            foreach (var a in attachments)
            {
                message.Attachments.Add(a);
            }

            await SendEmailAsync(message);
        }
    }
}
