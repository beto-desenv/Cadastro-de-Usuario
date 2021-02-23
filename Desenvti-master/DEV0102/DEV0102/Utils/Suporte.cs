using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace DEV0102.Utils
{
    public class Suporte
    {
        public void EnviarEmail(string Assunto, string emailDestinatario, string corpoEmail)
        {
            
            MailMessage objmail = new MailMessage();
            objmail.To.Add(emailDestinatario);
            objmail.From = new MailAddress("beto.vieiracarlos@gmail.com");
            objmail.Body = corpoEmail;
            objmail.Subject = Assunto;

            SmtpClient objsmtp = new SmtpClient();
            objsmtp.Host = "smtp.gmail.com";
            objsmtp.Port = 587;
            objsmtp.UseDefaultCredentials = false;
            objsmtp.Credentials = new NetworkCredential("beto.vieiracarlos@gmail.com", "Roberto042612");
            objsmtp.EnableSsl = true;
            objsmtp.Send(objmail);
        }
    }
}