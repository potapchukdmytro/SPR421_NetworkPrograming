using Quartz;

namespace _04_smtp
{
    internal class MailJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            string host = "smtp.gmail.com";
            int port = 587;
            string fromEmail = "";
            string password = "";

            MailService mailService = new MailService(host, port, fromEmail, password);
            return mailService.SendEmailAsync(new string[] { fromEmail }, "test", "test");
        }
    }
}
