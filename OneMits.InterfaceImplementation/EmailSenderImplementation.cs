//using Microsoft.AspNetCore.Identity.UI.Services;
//using MimeKit;
//using System;
//using System.Collections.Generic;
//using System.Net.Mail;
//using System.Text;
//using System.Threading.Tasks;

//namespace OneMits.InterfaceImplementation
//{
//    public class EmailSenderImplementation : IEmailSender
//    {
//        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
//        {
//            var emailMessage = new MimeMessage();

//            emailMessage.From.Add(new MailboxAddress("Joe Bloggs", "jbloggs@example.com"));
//            emailMessage.To.Add(new MailboxAddress("", email));
//            emailMessage.Subject = subject;
//            emailMessage.Body = new TextPart("plain") { Text = htmlMessage };
//        }


//            internal class Example
//        {
//            private static void Main()
//            {
//                Execute().Wait();
//            }

//            static async Task Execute()
//            {
//                var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
//                var client = new SendGridClient(apiKey);
//                var from = new EmailAddress("test@example.com", "Example User");
//                var subject = "Sending with SendGrid is Fun";
//                var to = new EmailAddress("test@example.com", "Example User");
//                var plainTextContent = "and easy to do anywhere, even with C#";
//                var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
//                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
//                var response = await client.SendEmailAsync(msg);
//            }
//        }
//    }
//}
