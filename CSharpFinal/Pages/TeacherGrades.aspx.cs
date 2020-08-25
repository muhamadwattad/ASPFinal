using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSharpFinal.Pages
{
    public partial class TeacherGrades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            return;
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Server.Transfer("TeacherMain.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["Teacher"] != null)
            {

                Response.Cookies["Teacher"].Expires = DateTime.Now.AddDays(-1);
            }
            Session.Remove("day");
            Response.Redirect("Login.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Remove("name");
            int code=int.Parse(GridView1.SelectedRow.Cells[1].Text);
            Session["id"] = code;
          

        }

       
    }
}