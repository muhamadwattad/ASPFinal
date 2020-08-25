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

          
           



            

        }
   

      

       

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            return;
        }

        protected void LinkButton2_Click1(object sender, EventArgs e)
        {
            Session.Remove("day");
            Server.Transfer("Classes.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session.Remove("day");
            Server.Transfer("Grades.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            //TODO
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

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            ResetColors();
            sun.BackColor = System.Drawing.Color.Turquoise;
            Session["day"] = "sunday";
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            ResetColors();
            mon.BackColor = System.Drawing.Color.Turquoise;
            Session["day"] = "monday";
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            ResetColors();
            the.BackColor = System.Drawing.Color.Turquoise;
            Session["day"] = "theusday";
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            ResetColors();
            wend.BackColor = System.Drawing.Color.Turquoise;
            Session["day"] = "wendsday";
        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            ResetColors();
            thu.BackColor = System.Drawing.Color.Turquoise;
            Session["day"] = "thursday";
        }

        protected void Unnamed6_Click(object sender, EventArgs e)
        {
            ResetColors();
            fri.BackColor = System.Drawing.Color.Turquoise;
            Session["day"] = "friday";
        }
        private void ResetColors()
        {
            fri.BackColor = thu.BackColor = wend.BackColor = the.BackColor = mon.BackColor = sun.BackColor = System.Drawing.Color.White;
        }

       
    }
}