using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace Login.Models
{
    public class Correo
    {
        public static void SendEmailAsync(string correo, string contenido)
        {
            try
            {
                // Credentials
                var credentials = new NetworkCredential("epb@ecopartnersbank.org", "ecopartnersbank");
                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress("lmonsalve22@gmail.com", "Comprobante de aporte final"),
                    Subject = "Comprobante de aporte final",
                    Body = "<html><head></head><body><p>Correo prueba</p>"+
                    contenido+
                    "</body></html>",
                    IsBodyHtml = true
                };

                mail.To.Add(new MailAddress(correo));

                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 25,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "mail.ecopartnersbank.org",
                    EnableSsl = false,
                    Credentials = credentials
                };

                // Send it...         
                client.Send(mail);
            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }

            //return Task.Com;
        }
    }
}