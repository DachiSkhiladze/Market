using System.Net;
using System.Net.Mail;

namespace EmailLayer
{
    public class EmailSender
    {
        public EmailSender()
        {

        }

        public string Send(string Email, string FirstName, string LastName)
        {
            try
            {
                MailMessage newMail = new MailMessage();

                SmtpClient client = new SmtpClient("smtp.gmail.com");
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                newMail.From = new MailAddress("dachiskhiladze@gmail.com", "Dachi");

                newMail.To.Add("dachi.skhiladze@flatrocktech.com");

                newMail.Subject = "My First Email";

                newMail.IsBodyHtml = true; newMail.Body = "<h1> This is my first Templated Email in C# </h1>";

                client.EnableSsl = true;

                client.Port = 587;

                client.Credentials = new System.Net.NetworkCredential("dachiskhiladze@gmail.com", "ofryyovqxbgyqbuf");

                client.Send(newMail);
                return "Email Sent";
            }
            catch (Exception ex)
            {
                return "Error - " + ex;
            }
        }
    }
}