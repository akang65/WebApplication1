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
            try
            {
                string emailretrived = Session["email"].ToString();
                if (emailretrived != null)
                {
                    DataAccess db = new DataAccess();
                    db.ResetPassword(emailretrived, TextboxNewPass.Text, TextBoxOtp.Text);

                }
                else
                {
                    Response.Write("Cannot Retrive Email Details");
                }
                Response.Redirect("index.aspx");
            }
            catch
            {
                Response.Write("Cannot Retrive Email Details");
            }
            
            
            
        }
    } 
}