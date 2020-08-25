using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSharpFinal.Pages
{
    public partial class Classes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                GridView2.Visible = false;
                Button1.Visible = false;
            }
        }
     

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            GridView2.Visible = true;
            int code = int.Parse(row.Cells[1].Text);
            Session["Code"] = code;

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;
            string day = row.Cells[1].Text;
            Button1.Visible = true;
        }

        protected void text_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;
            if (row == null)
            {
               Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please choose a Course and a day.');", true);
                return;
            }
            string day = row.Cells[1].Text;
            GridViewRow row2 = GridView1.SelectedRow;
            int code = int.Parse(row2.Cells[1].Text);
            HttpCookie cookie = Request.Cookies["Username"];
            string username = cookie.Value;
           int res= SQLdb.SaveDayForCourse(code, day, username);
            if(res==0)
            {
                Response.Write("<script> alert('Something went wrong try again.') </script>");
            }
            else
            {
                Response.Write("<script> alert('Saved Succesfully!') </script>");
            }
        }

        protected void LinkButton2_Click1(object sender, EventArgs e)
        {
            return;
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Server.Transfer("MainPage.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Server.Transfer("Grades.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            //TODO
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            if(Request.Cookies["Username"] != null){
             
                Response.Cookies["Username"].Expires = DateTime.Now.AddDays(-1);
            }

            Response.Redirect("Login.aspx");
        }
    }
}