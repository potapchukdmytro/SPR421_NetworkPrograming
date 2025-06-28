using Quartz;
using Quartz.Impl;
using System.Net;
using System.Net.Mail;

namespace _04_smtp
{
    class Customer
    {
        public required string Email { get; set; }
        public required string Name { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer {Email = "dmytro.potapchuk22@gmail.com", Name = "Dmyto" },
                new Customer {Email = "mokruicode@gmail.com", Name = "Vyacheslav" },
                new Customer {Email = "domaksym69@gmail.com", Name = "Maksym" },
                new Customer {Email = "staddycase@gmail.com", Name = "Luka" }
            };

            string host = "smtp.gmail.com";
            int port = 587;
            string fromEmail = "";
            string password = "";

            SmtpClient smtpClient = new SmtpClient(host, port);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(fromEmail, password);

            // smtpClient.Send(fromEmail, fromEmail, "Test message", "Hello i'm");


            // Відправка листа багатьом користувачам
            //MailMessage message = new MailMessage();
            //message.From = new MailAddress(fromEmail);

            //message.To.Add("dmytro.potapchuk22@gmail.com");
            //message.To.Add("mokruicode@gmail.com");
            //message.To.Add("domaksym69@gmail.com");
            //message.To.Add("staddycase@gmail.com");

            //message.Subject = "SMTP and HTML message";
            //message.IsBodyHtml = true;

            //string html = File.ReadAllText("message.html");
            //message.Body = html;

            //smtpClient.Send(message);




            // Відправка листів із різними іменами
            //foreach (var customer in customers)
            //{
            //    MailMessage message = new MailMessage();
            //    message.From = new MailAddress(fromEmail);
            //    message.Subject = "SMTP and HTML message";
            //    message.IsBodyHtml = true;

            //    string html = File.ReadAllText("message.html");
            //    html = html.Replace("{userName}", $"{customer.Name}");
            //    message.Body = html;

            //    message.To.Add(customer.Email);
            //    smtpClient.Send(message);
            //}





            // Відправка листа із файлом
            //foreach (var customer in customers)
            //{
            //    MailMessage message = new MailMessage();
            //    message.From = new MailAddress(fromEmail);
            //    message.Subject = "SMTP and HTML message";
            //    message.IsBodyHtml = true;

            //    string html = File.ReadAllText("message.html");
            //    html = html.Replace("{userName}", $"{customer.Name}");
            //    message.Body = html;

            //    // file
            //    string filePath = @"C:\itstep\HTML_logo.png";
            //    var attachment = new Attachment(filePath);
            //    message.Attachments.Add(attachment);

            //    message.To.Add(customer.Email);
            //    smtpClient.Send(message);
            //}




            MailService mailService = new MailService(host, port, fromEmail, password);
            mailService.SendEmailAsync(new string[] { fromEmail }, "test", "test").Wait();



            // StdSchedulerFactory factory = new StdSchedulerFactory();
            // IScheduler scheduler = factory.GetScheduler().Result;

            // scheduler.Start().Wait();

            // IJobDetail job = JobBuilder.Create<MailJob>()
            //.WithIdentity("mailJob", "group1")
            //.Build();

            // ITrigger trigger = TriggerBuilder.Create()
            // .WithIdentity("mailJobTrigger", "group1")
            // .StartNow()
            // .WithCronSchedule("0/5 * * * * ?")
            // .Build();

            // scheduler.ScheduleJob(job, trigger).Wait();

            // Console.ReadLine();
        }
    }
}
