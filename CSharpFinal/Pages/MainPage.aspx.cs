using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSharpFinal
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["Username"];
            if(cookie!=null)
            {
                Label5.Text = "Hello " + cookie.Value;
            }
            else
            {
                Label5.Text = "Hello " + (string)Context.Items["Username"] ?? "";
                DateTime now = DateTime.Now;
                HttpCookie httpCookie = new HttpCookie("Username");
                httpCookie.Value = (string)Context.Items["Username"] ?? "";
                httpCookie.Expires = now.AddYears(50);
                Response.Cookies.Add(httpCookie);
            }
           



            

        }
   

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("Classes.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

        }

        
    }
}