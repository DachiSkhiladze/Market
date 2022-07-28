using EmailLayer.Abstractions;
using EmailLayer.URL;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace EmailLayer
{
    public class EmailSender : IEmailSender
    {
        RandomURLGenerator urlCode;
        public EmailSender()
        {
            urlCode = new RandomURLGenerator();
        }

        public string Send(string Email, string FirstName, string LastName)
        {
            try
            {
                string code = urlCode.Generate(300);
                MailMessage newMail = new MailMessage();

                SmtpClient client = new SmtpClient("smtp.gmail.com");
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                newMail.From = new MailAddress("dachiskhiladze@gmail.com", "Dachi");

                newMail.To.Add(Email);

                newMail.Subject = "Shop - Password Verification";

                newMail.IsBodyHtml = true; 
                StringBuilder content = new StringBuilder();
                content.Append($"<h1> Hello {FirstName}! </h1>");
                content.Append($"<h3> Nice to meet you. <h2>");
                content.Append($"<h3> Please verify email by clicking the button <h3>");
                content.Append($"<form action='https://localhost:7201/User/ConfirmEmail/{code}'> <input type = 'Submit' value = 'Verify'/> </form>");
                newMail.Body = content.ToString();

                client.EnableSsl = true;

                client.Port = 587;

                client.Credentials = new System.Net.NetworkCredential("dachiskhiladze@gmail.com", "ofryyovqxbgyqbuf");

                client.Send(newMail);
                return code;
            }
            catch (Exception ex)
            {
                return "Error - " + ex;
            }
        }
    }
}