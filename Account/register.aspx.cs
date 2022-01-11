using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormUI;
using WebApplication1.ClassFolder;

/* on CLICKING REGISTER BUTTON
 * 1. Check Existing Email 
 * 2. Check Existing email with otp verified
 * if true show email already in use
 * 3. Check Existing email withOUT otp verified
 * 4.Delete Existing User from database without Email Verified
 * 5..Create New user AND generate a fresh otp
 * 6. Redirect User to otp Verification Page
 * 7. wait user for 2 min and invalidate the otp or redirect user to register page
 */

namespace WebApplication1
{
    
    public partial class register : System.Web.UI.Page
      
    {
        List<Person> checkEV = new List<Person>();
        public string body;
        public static string email;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void ButtonRegister_Click(object sender, EventArgs e)
        {
           
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
                    Response.Write("Email already Registered!");
                    
                }
                else if (checkEV.Count >= 0)
                {
                    DeleteUnverifiedUser();
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
            try
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
                db.InsertPerson(TextBoxFirstName.Text, TextBoxLastName.Text, TextBoxEmail.Text, TextBoxPhoneNumber.Text, TextBoxpassword.Text, body);
                //TextBoxFirstName.Text = "";
                //TextBoxEmail.Text = "";
                Session["email"] = TextBoxEmail.Text;

                EmailVerifOTP();
            }
            catch(Exception e)
            {
                Response.Write(e);
            }
        }
 
        public void EmailVerifOTP()
        {               
            EmailController ec = new EmailController();
            string sub = "Email Verification";
            string message = "Your OTP(One Time Password) for email verification on CabBooking is: ";
            ec.ConfirmEmail(TextBoxFirstName.Text, TextBoxEmail.Text, sub, body,message);
            TextBoxFirstName.Text = "";
            TextBoxEmail.Text = "";
            Response.Redirect("Verify.aspx");
        }
        public void DeleteUnverifiedUser()
        {
            try
            {
                DataAccess db = new DataAccess();
                List<Person> Delete = new List<Person>();
                Delete = db.DeleteExistingUser(TextBoxEmail.Text);

                if (Delete.Count <= 0)
                {
                    RegUser();
                }
                else
                {
                    DeleteUnverifiedUser();
                }
           
            }
            catch(Exception e)
            {
                Response.Write(e);
            }
          
        }
    }
}




