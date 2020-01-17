using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace B4.PE2.ManuVanLook.Domain.Services
{
    public class MailService
    {
        public async Task SendMail(MailMessage mailMessage)
        {
            try
            {
                //NetworkCredentials
                NetworkCredential networkCredential = new NetworkCredential
                {
                    //not secure
                    UserName = "random.thelegend27@gmail.com",
                    Password = "2156Manu"
                };

                // Mail message
                var _mailMessage = new MailMessage()
                {
                    From = new MailAddress(networkCredential.UserName),
                    Subject = mailMessage.Subject,
                    Body = mailMessage.Body
                };

                foreach (var receiver in mailMessage.To)
                {
                    _mailMessage.To.Add(receiver);
                }

                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = networkCredential
                };

                // Send it...         
                await client.SendMailAsync(_mailMessage);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
