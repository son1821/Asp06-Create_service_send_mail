using System.Net;
using System.Net.Mail;

namespace MailUtils
{
    public class MailUtils
    {
        public static async Task<string> SendMail(string _from, string _to, string _subject, string _body)
        {
            MailMessage message = new MailMessage(_from, _to, _subject, _body);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            message.ReplyToList.Add(new MailAddress(_from));
            message.Sender = new MailAddress(_from);

            using var smtpClient = new SmtpClient("localhost");
            try
            {
              await  smtpClient.SendMailAsync(message);
                return "Gui mail thanh cong";
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Gui mail that bai:"+ ex.Message;
            }

        }
        public static async Task<string> SendGmail(string _from, string _to, string _subject, string _body, string _gmail,string _password)
        {
            MailMessage message = new MailMessage(_from, _to, _subject, _body);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            message.ReplyToList.Add(new MailAddress(_from));
            message.Sender = new MailAddress(_from);

            using var smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(_gmail, _password);
            try
            {
                await smtpClient.SendMailAsync(message);
                return "Gui mail thanh cong";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Gui mail that bai:" + ex.Message;
            }

        }
    }
}
