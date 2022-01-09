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
             DataAccess db = new DataAccess();
             db.InsertPerson(TextBoxFirstName.Text, TextBoxLastName.Text, TextBoxEmail.Text,TextBoxPhoneNumber.Text, TextBoxpassword.Text);
             TextBoxFirstName.Text = "";
             TextBoxLastName.Text = "";
            TextBoxEmail.Text = "";
             TextBoxPhoneNumber.Text = "";
             TextBoxpassword.Text = "";
            SmsApi smsApi = new SmsApi();
            smsApi.GetNumber(TextBoxPhoneNumber.Text);
            TextBoxPhoneNumber.Text = "";
       //     Response.Redirect("Verify.aspx");
            


        }
    }
}