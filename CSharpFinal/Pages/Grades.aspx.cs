using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSharpFinal.Pages
{
    public partial class Grades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Server.Transfer("MainPage.aspx");
        }

        protected void LinkButton2_Click1(object sender, EventArgs e)
        {
            Server.Transfer("Classes.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            return;
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["Username"] != null)
            {

                Response.Cookies["Username"].Expires = DateTime.Now.AddDays(-1);
            }
            Session.Remove("day");
            Response.Redirect("Login.aspx");
        }

        
    }
}