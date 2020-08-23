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

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

            int res = SQLdb.Login(Login1.UserName, Login1.Password);
            if(res==1)
            {
                e.Authenticated = true;

                Context.Items["Username"] = Login1.UserName;

                Server.Transfer("MainPage.aspx");
            }
            else
            {
                e.Authenticated = false;

            }


         
        }
    }
}