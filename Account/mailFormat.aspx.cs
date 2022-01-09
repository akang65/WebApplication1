using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Account
{
    public partial class mailFormat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SendEmail(object sender, EventArgs e)
        {
            //Send Email
            MailMessage Msg = new MailMessage();
            try
            {


                Msg.From = new MailAddress("cabbooking65@gmail.com", "CabBoking");// Sender details here, replace with valid value
                Msg.Subject = Subject.Text; // subject of email
                Msg.To.Add(To.Text); //Add Email id, to which we will send email
                Msg.Body = EmailMessage.Text;
                Msg.IsBodyHtml = true;
                Msg.Priority = MailPriority.High;
                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false; // to get rid of error "SMTP server requires a secure connection"
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("cabbooking65@gmail.com", "cabbooking@123");// replace with valid value
                smtp.EnableSsl = true;
                smtp.Timeout = 20000;

                smtp.Send(Msg);
            }
            catch(Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}