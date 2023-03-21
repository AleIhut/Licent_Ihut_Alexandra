using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Common;
using System.Net.Mail;
using System.Net;
using System.Xml.Linq;

namespace Licent_Ihut_Alexandra.Pages
{
    public class ContactModel : PageModel
    {
        public void OnGet()
        {
            //protected void btnSubmit_Click(object sender, EventArgs e)
            //{
            //    MailMessage mail = new MailMessage();
            //    mail.To.Add("youremail@example.com");
            //    mail.From = new MailAddress(txtEmail.Text);
            //    mail.Subject = "Contact Form Submission";
            //    mail.Body = "Name: " + txtName.Text + "<br/>"
            //              + "Email: " + txtEmail.Text + "<br/>"
            //              + "Message: " + txtMessage.Text;
            //    mail.IsBodyHtml = true;

            //    SmtpClient smtp = new SmtpClient();
            //    smtp.Host = "smtp.gmail.com";
            //    smtp.Port = 587;
            //    smtp.UseDefaultCredentials = false;
            //    smtp.Credentials = new NetworkCredential("youremail@example.com", "password");
            //    smtp.EnableSsl = true;
            //    smtp.Send(mail);

            //    lblMessage.Text = "Thank you for contacting us!";
            //    ClearForm();
            //}

            //private void ClearForm()
            //{
            //    txtName.Text = "";
            //    txtEmail.Text = "";
            //    txtMessage.Text = "";
            //}
        }

    }
}
