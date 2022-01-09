using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormUI;

namespace WebApplication1
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<Person> people = new List<Person>();
        public static string error = "Something Out Of Control";
        public string cookie_Email, cookie_Password;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Do something on page Load
            if (!IsPostBack)
            {
                if (Request.Cookies["cookie_Email"] != null)
                    TextBoxEmail.Text = Request.Cookies["cookie_Email"].Value;
                if (Request.Cookies["cookie_Password"] != null)
                    TextBoxpassword.Attributes.Add("value", Request.Cookies["cookie_Password"].Value);
                if (Request.Cookies["cookie_Email"] != null && Request.Cookies["cookie_Password"] != null)
                    CheckBox.Checked = true;
                {
                  // Response.Redirect("Index.aspx");
                }
            }else
            {
                Response.Redirect("Login.aspx");
            }
        }
     
        protected void Signin(object sender,EventArgs e)
        {
            try
            {
                //Opening Sql Connection
                DataAccess db = new DataAccess();
                people = db.GetPeople(TextBoxEmail.Text, TextBoxpassword.Text);

                //Checking if the returned values from database contains the user email and password
                if (people.Count <= 0)

                {
                    Response.Write(" Incorrect Email or Password");
                }
                else if (people.Count >= 1)
                {
                    if (CheckBox.Checked == true)
                    {
                        Response.Cookies["cookie_Email"].Value = TextBoxEmail.Text;
                        Response.Cookies["cookie_Password"].Value = TextBoxpassword.Text;
                        Response.Cookies["cookie_Email"].Expires = DateTime.Now.AddDays(5);
                        Response.Cookies["cookie_Password"].Expires = DateTime.Now.AddDays(5);
                    }
                    else
                    {
                        Response.Cookies["cookie_Email"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["cookie_Email"].Expires = DateTime.Now.AddDays(-1);
                    }
                    Response.Redirect("Index.aspx");
                }
            }
            catch
            {
                
                Response.Write(error);
               
            }

            
        }
    }
}