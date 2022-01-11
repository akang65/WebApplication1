using FormUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Account
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void req_password_Click(object sender, EventArgs e)
        {
            string emailretrived = Session["email"].ToString();
            //1.verify otp which is stored in database column as(TemporaryPassword)
            //2.update new password in the column (UserPassword)
            /* (procedure): IF EXISTS(SELECT * from People where EmailAddress=@EmailAddress and TemporaryPassword=@OTP)
      BEGIN
       update dbo.People 
       set UserPassword=@NewPassword
       where EmailAddress=@EmailAddress and OTP =@OTP
      END
             * */
            DataAccess db = new DataAccess();
            db.ResetPassword(emailretrived,TextBoxOtp.Text,TextboxNewPass.Text);
            
        }
    }
}