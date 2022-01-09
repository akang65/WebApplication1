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
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
           
            /* DataAccess db = new DataAccess();
             db.InsertPerson(TextBoxFirstName.Text, TextBoxLastName.Text, TextBoxEmail.Text,TextBoxPhoneNumber.Text, TextBoxpassword.Text);
             TextBoxFirstName.Text = "";
             TextBoxLastName.Text = "";
             TextBoxEmail.Text = "";
             TextBoxPhoneNumber.Text = "";
             TextBoxpassword.Text = "";
            */ 
            EmailController ec = new EmailController();
            string sub = "Email Verification";
            string body = "test123otp";
            ec.ConfirmEmail(TextBoxFirstName.Text, TextBoxEmail.Text,sub,body);
            TextBoxFirstName.Text = "";
            TextBoxEmail.Text = "";
            //     Response.Redirect("Verify.aspx");



        }
    }
}