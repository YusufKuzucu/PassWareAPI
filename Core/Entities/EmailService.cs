using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class EmailService
    {
        public void EmailGdr(string htmlString,string email)
        {

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("ysfkzc@yandex.com");
            message.To.Add(new MailAddress(email));
            message.Subject = "Şifre Sıfırlama Talebine Bulundunuz ";
            message.IsBodyHtml = true; //to make message body as html
            message.Body = $"Parola Sıfırlama İçin Doğrulama Kodunuz: {htmlString}";
            smtp.Port = 587;
            smtp.Host = "smtp.yandex.com"; //for gmail host
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            //smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential("ysfkzc@yandex.com", "ysfkzc75=^!?");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);

        }
    }
}
