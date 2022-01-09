using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormUI;
using WebApplication1.ClassFolder;

namespace WebApplication1
{
    
    public partial class register : System.Web.UI.Page
      
    {
        List<Person> checkEV = new List<Person>();
        public string body;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void ButtonRegister_Click(object sender, EventArgs e)
        {
           ;
            checkEmailVerification();

        }

        private void checkEmailVerification()
        {
            try
            {
                DataAccess db = new DataAccess();
                checkEV = db.CheckEmailVerification(TextBoxEmail.Text);
                if (checkEV.Count >= 1)
                {
                    Response.Write("Email already Registered! Please Login /n Or Register using different Email Address ");
                    
                }
                else if (checkEV.Count >= 0)
                {
                    RegUser();
                }
                else
                {
                    Response.Write("Please Check the Log File IDK What went wrong");
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex);
            }
        }

        public void RegUser()
        {
            var char1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var Stringchar = new char[5];
            var random = new Random();
            for (int i = 0; i < Stringchar.Length; i++)
            {
                Stringchar[i] = char1[random.Next(char1.Length)];

            }
             body = new String(Stringchar);
            DataAccess db = new DataAccess();
            db.InsertPerson(TextBoxFirstName.Text, TextBoxLastName.Text, TextBoxEmail.Text, TextBoxPhoneNumber.Text, TextBoxpassword.Text,body);
            TextBoxFirstName.Text = "";
            TextBoxLastName.Text = "";
            TextBoxEmail.Text = "";
            TextBoxPhoneNumber.Text = "";
            TextBoxpassword.Text = "";
            EmailVerifOTP();
        }

 
        public void EmailVerifOTP()
        {               
            EmailController ec = new EmailController();
            string sub = "Email Verification";
            ec.ConfirmEmail(TextBoxFirstName.Text, TextBoxEmail.Text, sub, body);
            TextBoxFirstName.Text = "";
            TextBoxEmail.Text = "";
            Response.Redirect("Verify.aspx");
        }
    }
}