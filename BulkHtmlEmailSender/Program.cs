using System;

namespace BulkHtmlEmailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Bulk Html Email Sender!");

            Console.WriteLine("\nPlease enter the path to the Distribution List .csv file below:");
            string listPath = Console.ReadLine();
            DistributionList distributionList = new DistributionList();
            Console.WriteLine("Reading the distribution list...");
            distributionList.Initialize(listPath);
            Console.WriteLine($"Found {distributionList.TotalCount()} people.");
            var peopleList = distributionList.GetPeopleList();

            EmailSender emailSender = new EmailSender();
            emailSender.SetupReceipients(peopleList);
            Console.WriteLine("\nPlease enter the path to the Email Template .html file below:");
            string HtmlPath = Console.ReadLine();
            Console.WriteLine("\nPlease enter the Email's subject below:");
            string subject = Console.ReadLine();
            emailSender.ComposeEmail(HtmlPath, subject);

            Console.WriteLine("\nAcquiring user's Email credentials");
            Console.WriteLine("Please enter your email address below:");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter your password below:");
            string password = Password.ReadPassword();
            emailSender.Initialize(email, password);
            emailSender.Send();
        }
    }
}
