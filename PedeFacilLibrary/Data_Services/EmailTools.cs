using PedeFacilLibrary.Models;
using System;
using System.Net;
using System.Net.Mail;

namespace PedeFacilLibrary.Data_Services
{
    public class EmailTools
    {
        public bool sendEmail(string emailRemetente, string emailDestinatario, string tipoEmail, string mensagem)
        {
            try
            {
                //MailMessage mailMessage = new MailMessage();
                //mailMessage.From = new MailAddress("pedefacil@outlook.com", "Suporte PedeFácil");
                //mailMessage.To.Add(emailDestinatario);
                //mailMessage.IsBodyHtml = true;
                //mailMessage.Body = mensagem;
                //mailMessage.Priority = MailPriority.High;

                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp-mail.outlook.com";
                //smtp.Port = 587;
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.EnableSsl = true;
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new NetworkCredential("pedefacil@outlook.com", "tccsi2017");
                //smtp.Send(mailMessage);
                //return true;
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("recuperarsenha@pedefacil.somee.com", "Suporte PedeFácil");
                mailMessage.Subject = "Suporte PedeFácil";
                mailMessage.To.Add(emailDestinatario);
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = mensagem;
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                mailMessage.Priority = MailPriority.High;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.pedefacil.somee.com";
                smtp.Port = 26;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("recuperarsenha@pedefacil.somee.com", "tccsi2017");
                smtp.Send(mailMessage);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool sendEmailSAC(Entidade entidade, SAC_Log sac)
        {
            try
            {
                //MailMessage mailMessage = new MailMessage();
                //mailMessage.From = new MailAddress("pedefacil@outlook.com", "PedeFácil");
                //mailMessage.Subject = "SAC";
                //mailMessage.To.Add("pedefacil@outlook.com");
                //mailMessage.IsBodyHtml = true;
                //mailMessage.Body = "Remetente: " + entidade.Nome + "<br>" +
                //                   "Contato: " + entidade.Email + "<br>" +
                //                   "Assunto: " + sac.ds_Assunto + "<br>" +
                //                   "Mensagem: " + sac.ds_Mensagem;
                //mailMessage.Priority = MailPriority.High;
                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp-mail.outlook.com";
                //smtp.Port = 587;
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.EnableSsl = true;
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new NetworkCredential("pedefacil@outlook.com", "tccsi2017");
                //smtp.Send(mailMessage);
                //return true;
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("sac@pedefacil.somee.com", "SAC PedeFácil");
                mailMessage.Subject = "SAC";
                mailMessage.To.Add("pedefacil@outlook.com");
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = "Remetente: " + entidade.Nome + "<br>" +
                                   "Contato: " + entidade.Email + "<br>" +
                                   "Assunto: " + sac.ds_Assunto + "<br>" +
                                   "Mensagem: " + sac.ds_Mensagem;
                mailMessage.Priority = MailPriority.High;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.pedefacil.somee.com";
                smtp.Port = 26;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("sac@pedefacil.somee.com", "tccsi2017");
                smtp.Send(mailMessage);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}