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
                    //Response.Redirect("Index.aspx"); activate later
                }
            }
            else
            {
                CheckBox.Checked = false;
            }
            
        }
        protected void Signin(object sender, EventArgs e)
        {     
            DataAccess db = new DataAccess();
            people = db.GetPeople(TextBoxEmail.Text, TextBoxpassword.Text);

            if (people.Count >= 1)
            {
               // string combindedString = string.Join(Environment.NewLine, people);
               // if (combindedString.Contains("Temp"))
              
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
                        //Response.Redirect("index.aspx");
                    }

              Response.Redirect("index.aspx");

            }
            else
            {
                Response.Write("Incorrect Emailm or address");
            }
          
        }
    }
}