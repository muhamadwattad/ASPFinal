using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSharpFinal.Classes;

namespace CSharpFinal.Pages
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                getSubjects();
                Courses.Visible = false;
            }
        }
        private void getSubjects()
        {
            List<string> list = SQLdb.getSubjects();
            if (list == null || list.Count == 0)
            {
                Response.Write("<script> location.reload() </script>");
            }
            else
            {
                Subjects.Items.Insert(0, new ListItem("Choose a subject ", "0"));
                for (int i = 0; i < list.Count; i++)
                    Subjects.Items.Insert(i + 1, new ListItem(list[i], i + 1 + ""));
            }
        }
        private void getCourses(int value)
        {
            List<Course> list = SQLdb.GetCourses(value);

            if (list == null || list.Count == 0)
            {
                Response.Write("<script> alert('Failed to get data. Refresh The page ') </script>");
            }
            else
            {

                Courses.Items.Clear();


                for (int i = 0; i < list.Count; i++)
                {
                    Courses.Items.Insert(i, new ListItem(list[i].Course_Name, list[i].Course_ID + ""));

                }
                Courses.Visible = true;
            }

        }
        protected void Courses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Subjects_SelectedIndexChanged(object sender, EventArgs e)
        {

            int x = int.Parse(Subjects.SelectedItem.Value);
            if (x == 0)
                Courses.Visible = false;
            else
            {
                this.getCourses(x);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


        }

        protected void Courses_SelectedIndexChanged1(object sender, EventArgs e)
        {

            int count = 0;
            foreach (ListItem i in Courses.Items)
            {
                if (i.Selected)
                {
                    count++;
                }
            }

        }
        protected void LoginButton_Click1(object sender, EventArgs e){
            string Name = UsernameText.Text;
            string email = EmailText.Text;
            string Password = PasswordText.Text;
            string courseName = Subjects.SelectedItem.Text;
            List<string> Selectedlist = new List<string>();
            foreach (ListItem i in Courses.Items)
            {
                if (i.Selected)
                {
                    Selectedlist.Add(i.Value);
                }
            }

            if (Name.Length == 0 || email.Length == 0 || Password.Length == 0)
            {
                Response.Write("<script> alert('Please Dont keep anything empty.')" +
                    "</script>");

            }
            else
            {
                if (!(Name.Length >= 6 && Name.Length <= 12))
                {
                    Response.Write("<script> alert('Username length must be between 6-12')" + "</script>");
                    return;
                }

                string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                if (!regex.IsMatch(email))
                {
                    Response.Write("<script> alert('Please enter a valid email.')" +
                                     "</script>");
                    return;
                }

                if (!(Password.Length >= 4 && Password.Length <= 10))
                {
                    Response.Write("<script> alert('Password length must be between 4-10')" + "</script>");
                    return;
                }


                if (Selectedlist.Count != 3 || Selectedlist.Count == 0)
                {
                    Response.Write("<script> alert('Please only choose a subject and only 3 courses.')</script>");
                    return;
                }



                int res = SQLdb.Register(new User(email, Name, Password), Selectedlist);
                if (res == 3)
                {

                    Response.Write("<script> alert('Signed up successfully!')</script>");
                    Response.Redirect("Login.aspx");

                }
                else
                {
                    Response.Write("<script> alert('Username already taken. Choose another one')</script>");

                }

            }

        }
       
    }
}