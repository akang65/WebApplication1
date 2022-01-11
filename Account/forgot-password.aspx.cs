using FormUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.ClassFolder;

namespace WebApplication1
{
    public partial class forgot_password : System.Web.UI.Page
    {
        List<Person> Checkemail = new List<Person>();
        protected string temp; 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void req_password_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            Checkemail = db.CheckEmailVerification(Textboxemail.Text);
            if (Checkemail.Count <=0)
            {
                Response.Write("Email Not Registered");
            }
            else if (Checkemail.Count>=1)
            {
                SetTempPass();

            }
            else
            {
                Response.Write("Database out of order");
            }
        }
        public void SetTempPass()
        {
            try
            {
                //Set temp password and send it for temp login
                var char1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890*%$#@!abcdefghijklmnopqrstuvwxyz";
                var Stringchar = new char[5];
                var random = new Random();
                for (int i = 0; i < Stringchar.Length; i++)
                {
                    Stringchar[i] = char1[random.Next(char1.Length)];

                }
                temp = new String(Stringchar);

                EmailController ec = new EmailController();
                string Subject = "Temporary password";
                string Message = "Your Temporary password is";
                string Name = "";
                ec.ConfirmEmail(Name, Textboxemail.Text, Subject, temp, Message);
                DataAccess dataaccess = new DataAccess();
                dataaccess.ReqNewPasswordOTP(Textboxemail.Text, temp);
                Session["email"] = Textboxemail.Text;
                Response.Redirect("Recoverpassword");
            }
            catch(Exception e)
            {
                Response.Write(e);
            }
        }
    }
}