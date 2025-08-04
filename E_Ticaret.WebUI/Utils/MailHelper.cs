using E_Ticaret.Core.Entities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using System.Net;
using System.Net.Mail;

namespace E_Ticaret.WebUI.Utils
{
    public class MailHelper
    {
        public static async Task SendMailAsync(Contact contact)
        {
            SmtpClient smtpClient = new SmtpClient("mail.siteadi.com", 587);
            smtpClient.Credentials = new NetworkCredential("prepective.sefa@gmail.com","mail-sifre");
            smtpClient.EnableSsl = true;

            MailMessage message = new MailMessage();
            message.From = new MailAddress("prepective.sefa@gmail.com");
            message.To.Add("prepective.sefa@gmail.com"); // Mailin gönderileceği adres
            message.Subject = "Siteden mesaj geldi"; // Mailin konu başlığı
            message.Body = $"İsim: {contact.Name} - Soyisim: {contact.SurName} - Email : {contact.Email} - Telefon : {contact.Phone} - Mesaj : {contact.Message}"; 
            // MESAJ GÖNDERENİN BİLGİLERİ
            message.IsBodyHtml = true; // html kodlarını desteklemiş olucak
            await smtpClient.SendMailAsync(message);
            smtpClient.Dispose();

        }
    }
}
