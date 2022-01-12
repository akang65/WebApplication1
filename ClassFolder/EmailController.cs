using Azure;
using Microsoft.VisualBasic.Logging;
using System;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication1.ClassFolder

{
   
    public class EmailController
    {
        public void ConfirmEmail(string name, string email, string subject, string body,string message) {
            //Send Email
            MailMessage Msg = new MailMessage();
            try {
                Msg.From = new MailAddress("cabbooking65@gmail.com", "CabBoking");// Sender details here, replace with valid value
                Msg.Subject = subject; // subject of email
                Msg.To.Add(email); //Add Email id, to which we will send email
                Msg.Body =  "Hi" + name +message+ body;
                Msg.IsBodyHtml = true;
                Msg.Priority = MailPriority.High;
                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false; // to get rid of error "SMTP server requires a secure connection"
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("cabbooking65@gmail.com", "cabbooking@123");
                smtp.EnableSsl = true;
                smtp.Timeout = 20000;

                smtp.Send(Msg);
                //Response.Write("<script>alert('Submitted Successfully');</script>");
                   }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
               
            }
        }
    }
          
}