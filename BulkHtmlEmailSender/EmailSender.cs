using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BulkHtmlEmailSender
{
    public class EmailSender
    {
        List<Person> Receipients;
        MailMessage MailMsg;
        SmtpClient Client = new SmtpClient();
        string HtmlFile;
        public EmailSender()
        {
            Receipients = new List<Person>();
            MailMsg = new MailMessage();
        }

        public void SetupReceipients(List<Person> receipients)
        {
            Receipients = receipients;
        }

        public void ComposeEmail(string path, string subject)
        {
            try
            {
                using var sr = new StreamReader(path);
                HtmlFile = sr.ReadToEnd();
                //Console.WriteLine(HtmlFile);
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            MailMsg.Subject = subject;
            MailMsg.IsBodyHtml = true;
        }

        public void Initialize(string username, string password)
        {
            MailMsg.From = new MailAddress(username);
            /*Following is the configuration for Outlook Mail Server*/
            
            Client.UseDefaultCredentials = true;
            Client.Host = "smtp-mail.outlook.com";
            Client.Port = 587;
            Client.EnableSsl = true;
            Client.DeliveryMethod = SmtpDeliveryMethod.Network;
            Client.Credentials = new NetworkCredential(username, password);
            Client.Timeout = 20000;
        }

        public void Send()
        {
            try
            {
                Console.WriteLine($"\nMail has been successfully sent to following:");
                foreach (var receipient in Receipients)
                {
                    MailMsg.To.Clear();
                    string tempEmail = HtmlFile.Replace("[[Name]]", receipient.Name);
                    //Console.WriteLine(tempEmail);
                    MailMsg.Body = tempEmail;
                    MailMsg.To.Add(receipient.EmailAddress);
                    Client.Send(MailMsg);
                    Console.WriteLine(receipient.EmailAddress);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending messages: ");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                MailMsg.Dispose();
            }
        }
    }
}
