using BkServer.Models;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;
using System.Threading.Tasks;
namespace BkServer.Service
{
    public class EmailSender  
    {
          System.Net.Mail.MailMessage mail ;
      
         public Task SendEmailAsync(string email, string subject, string message)
        {
           
            return Execute(subject, message, email);
        }
         public async Task  Execute( string subject, string message, string email)
        {
            System.Net.Mail.MailMessage mail= new System.Net.Mail.MailMessage() ;
           mail.To.Add(email);
           mail.From=new System.Net.Mail.MailAddress("jetec.cloud@gmail.com","久德電子-信箱驗證服務",System.Text.Encoding.UTF8);
           mail.Subject=subject;
           mail.SubjectEncoding=System.Text.Encoding.UTF8;
           mail.Body=message;
           mail.BodyEncoding=System.Text.Encoding.UTF8;
           mail.IsBodyHtml=true;

           SmtpClient client = new SmtpClient();
           client.Credentials = new System.Net.NetworkCredential("jetec.cloud@gmail.com","jetec2028");
           client.Host="smtp.gmail.com";
           client.Port=25;
           client.EnableSsl=true;
            await client.SendMailAsync(mail);
           client.Dispose();
           mail.Dispose();
        }
    }
}