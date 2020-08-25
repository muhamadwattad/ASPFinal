using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSharpFinal.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

      

       

        protected void LoginButton_Click1(object sender, EventArgs e)
        {
            string username = UsernameText.Text;
            string password = PasswordText.Text;

            if (CheckBox1.Checked)
            {
                int res=SQLdb.TeacherLogin(username, password);
                if(res==1)
                {
                    DateTime now = DateTime.Now;
                    HttpCookie httpCookie = new HttpCookie("Teacher");
                    httpCookie.Value = username;
                    httpCookie.Expires = now.AddYears(50);
                    Response.Cookies.Add(httpCookie);
                    Response.Redirect("TeacherMain.aspx");
                }
                else
                {
                    Response.Write("<script> alert('Login Failed.') </script>");
                }
            }
            else
            {

                int res = SQLdb.Login(username, password);
                if (res == 1)
                {
                    DateTime now = DateTime.Now;
                    HttpCookie httpCookie = new HttpCookie("Username");
                    httpCookie.Value = username;
                    httpCookie.Expires = now.AddYears(50);
                    Response.Cookies.Add(httpCookie);

                    Response.Redirect("MainPage.aspx");
                }
                else
                {
                    Response.Write("<script> alert('Login Failed.') </script>");

                }
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

        }
    }
}