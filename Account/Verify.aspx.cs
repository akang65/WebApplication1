using FormUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using  WebApplication1;

namespace WebApplication1.Account
{
    public partial class Verify : System.Web.UI.Page
    {
        // List<Person> otp = new List<Person>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonVerify_Click(object sender, EventArgs e)
        {
            Verifyotp();
        }
        protected void ButtonResendOTP_Click(object sender, EventArgs e)
        {
            string emailretrived = Session["email"].ToString();
            DataAccess dataAccess = new DataAccess();
            dataAccess.InsertOtp(emailretrived, TextBoxOTP.Text);
        }
        public void Verifyotp()
        {        
            string emailretrived = Session["email"].ToString();
            DataAccess dataAccess = new DataAccess();
            dataAccess.InsertOtp(emailretrived,TextBoxOTP.Text);
        }

    }
}