using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace REAL.Utils
{
    public class Email
    {

        public static Boolean EnviarOrdenEmail(OrdenCompra ordencompra, string adjunto)
        {
            bool resultado = true;

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpserver = new SmtpClient();

                //mail.From = new MailAddress("ezequielfabregues@colchoneriasreal.com");
                mail.To.Add(ordencompra.proveedor.proemail);
                mail.CC.Add("ezequielfabregues@colchoneriasreal.com");
                mail.CC.Add("alvarobuteler@colchoneriasreal.com");
                //mail.To.Add("martinfabregues@hotmail.com");
                mail.Subject = "ORDEN DE COMPRA - " + ordencompra.odcnumero;
                mail.Body = "";

                Attachment attachment = new Attachment(adjunto);
                mail.Attachments.Add(attachment);

                //smtpserver.Port = 255;
                //smtpserver.Credentials = new System.Net.NetworkCredential("ezequielfabregues@colchoneriasreal.com", "ezequiel2014");
                smtpserver.Send(mail);
            }
            catch (Exception)
            {
                resultado = false;
                throw;
            }

            return resultado;
        }

    }
}
