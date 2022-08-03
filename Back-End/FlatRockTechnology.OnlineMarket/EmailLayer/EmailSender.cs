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

        public bool SendMail(string mail, string subject, string message)
        {
            try
            {
                MailMessage newMail = new MailMessage();
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                newMail.From = new MailAddress("dachiskhilasdasddze@gmail.com", "TicketMaster");

                newMail.To.Add(mail);

                newMail.Subject = subject;

                newMail.IsBodyHtml = true;

                newMail.Body = message;

                client.EnableSsl = true;

                client.Port = 587;

                client.Credentials = new System.Net.NetworkCredential("dachiskhiladze@gmail.com", "ofryyovqxbgyqbuf");

                client.Send(newMail);

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public string Send(string Email, string FirstName, string LastName, string origin)
        {
            try
            {
                string code = urlCode.Generate(300);


                StringBuilder content = new StringBuilder();
                content.Append($@"<div style='  width: 50 %;
                                                height: 100 %;
                                                margin: auto;' class='container'>
                                   <h1 style='      color: rgb(2, 108, 223);
                                                    text-align: center;
                                                    font-size: 40px;' class=''>Email Verification</h1> 
                                   <p style='       text-align: center;
                                                    font-size: 20px;'>Hello {FirstName}!</p>
                                   <p style='       text-align: center;
                                                    font-size: 20px;'>Nice to meet you.</p>
                                   <p style='       text-align: center;
                                                    font-size: 20px;'>Please verify your email by clicking the button below</p>
                                    <a href='{origin}?code={code}' >
                                     <input style=' display: block;
                                                    font-family: inherit;
                                                    font-weight: 600;
                                                    font-size: 14px;
                                                    line-height: 2.43;
                                                    width: 70%;
                                                    text-align: center;
                                                    margin: auto;
                                                    padding: 0px 12px;
                                                    min-width: 60px;
                                                    text-align: center;
                                                    border-radius: 2px;
                                                    cursor: pointer;
                                                    color: rgb(255, 255, 255);
                                                    background-color: rgb(2, 108, 223);
                                                    border: 1px solid transparent;
                                                    transition: background-color 0.3s cubic-bezier(0.455, 0.03, 0.515, 0.955) 0s;' type = 'Submit' value = 'Verify'/>
                                    </a>
                                  </div>");

                this.SendMail(Email, "Mail Confirmation", content.ToString());
                return code;
            }
            catch (Exception ex)
            {
                return "Error - " + ex;
            }
        }

        public string SendRecovery(string Email, string FirstName, string LastName, string origin)
        {
            try
            {
                string code = urlCode.Generate(300);
                StringBuilder content = new StringBuilder();
                content.Append($@"<div style='  width: 50 %;
                                                height: 100 %;
                                                margin: auto;' class='container'>
                                   <h1 style='      color: rgb(2, 108, 223);
                                                    text-align: center;
                                                    font-size: 40px;' class=''>Password Recovery</h1> 
                                   <p style='       text-align: center;
                                                    font-size: 20px;'>Hello {FirstName}!</p>
                                   <p style='       text-align: center;
                                                    font-size: 20px;'>Set new password by clicking the button below</p>
                                   <p style='       text-align: center;
                                                    font-size: 20px;'>If you have not requested password recovery, please ignore this email</p>
                                    <a href='{origin}?recovery={code}' >
                                     <input style=' display: block;
                                                    font-family: inherit;
                                                    font-weight: 600;
                                                    font-size: 14px;
                                                    line-height: 2.43;
                                                    width: 70%;
                                                    text-align: center;
                                                    margin: auto;
                                                    padding: 0px 12px;
                                                    min-width: 60px;
                                                    text-align: center;
                                                    border-radius: 2px;
                                                    cursor: pointer;
                                                    color: rgb(255, 255, 255);
                                                    background-color: rgb(2, 108, 223);
                                                    border: 1px solid transparent;
                                                    transition: background-color 0.3s cubic-bezier(0.455, 0.03, 0.515, 0.955) 0s;' type = 'Submit' value = 'Verify'/>
                                    </a>
                                  </div>");

                this.SendMail(Email, "Password Recovery", content.ToString());
                return code;
            }
            catch (Exception ex)
            {

                return "Error - " + ex;
            }
        }
    }
}