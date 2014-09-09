using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SupplyChain.Web.Models
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            //// Plug in your email service here to send an email.
            //return Task.FromResult(0);




            //MailMessage myMessage = new MailMessage();
            //myMessage.Subject = "Response from web site";
            //myMessage.Body = "Hello, this is a sample email";
            //myMessage.From = new MailAddress("randel1_23@yahoo.com", System.Web.Configuration.WebConfigurationManager.AppSettings["MailFrom"]);
            //myMessage.To.Add(new MailAddress("randel1_23@hotmail.com", "Receiver Name"));
            //SmtpClient mySmtpClient = new SmtpClient();
            //mySmtpClient.Host = System.Web.Configuration.WebConfigurationManager.AppSettings["MailServer"];
            //mySmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            ////Authenticate Username and Password of the smtp
            //System.Net.NetworkCredential cred = new System.Net.NetworkCredential(System.Web.Configuration.WebConfigurationManager.AppSettings["MailUsername"], System.Web.Configuration.WebConfigurationManager.AppSettings["MailPassword"]);
            //mySmtpClient.Port = 587;
            //mySmtpClient.Credentials = cred;

            //mySmtpClient.Send(myMessage);
            //Response.Write("Email sent!");


            // Credentials:
            var credentialUserName = "randelramirez1@gmail.com";
            var sentFrom = "randelramirez.com";
            var pwd = "randel1_23";

            // Configure the client:
            System.Net.Mail.SmtpClient client =
                new System.Net.Mail.SmtpClient("smtp.gmail.com");

            client.Port = 587;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            
            // Create the credentials:
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential(credentialUserName, pwd);

            client.EnableSsl = true;
            client.Credentials = credentials;

            // Create the message:
            var mail =
                new System.Net.Mail.MailMessage(sentFrom, message.Destination);

            mail.Subject = message.Subject;
            mail.Body = message.Body;

            // Send:
            return client.SendMailAsync(mail);
        }


    }
}