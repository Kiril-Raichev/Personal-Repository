using System;

namespace Task5
{
    class Program
    {
        public interface IFileLogger
        {
            void Info();
            void Debug();
            void Check();
        }
        public class FileLogger : IFileLogger
        {

            public void Logger()
            {
                // Code for initialization i.e. Creating Log file with specified  
                // details
            }
            public void Check()
            {
                /// log check result to file
            }
            public void Debug()
            {
                /// log debug result to file
            }
            public void Info()
            {
                /// log info result to file
            }
        }
        public class MailSender
        {
            public string From { get; set; }
            public string To { get; set; }
            public string Subject { get; set; }

            public void SendEmail(string mailMessage)
            {
                Console.WriteLine("Sending Email: {0}", mailMessage);
                // Code for getting Email setting and send invoice mail

            }
        }
        public class Invoice
        {
            public long Amount { get; set; }
            public DateTime InvoiceDate { get; set; }
            private IFileLogger fileLogger;
            private MailSender mailSender;
            public Invoice()
            {
                fileLogger = new FileLogger();
                mailSender = new MailSender();
            }
            public void Add()
            {
                Console.WriteLine("Adding amount...");
                // Code for adding invoice
                // Once Invoice has been added , send mail 
                string mailMessage = "Your invoice is ready.";
                mailSender.SendEmail(mailMessage);
            }
            public void Delete()
            {
                Console.WriteLine("Deleting amount...");
                // Code for Delete invoice
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
