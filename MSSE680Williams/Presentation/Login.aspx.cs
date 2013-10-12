using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace Presentation
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdLogin_Click(Object sender, EventArgs e)
        {
            string userName = txtName.Text;
            string password = txtPassword.Text;
            bool result = AuthenticateUser.AuthUser(userName, password);
            if (result)
            {
                FormsAuthentication.RedirectFromLoginPage(txtName.Text, false);
            }
            else
            {
                lblStatus.Text = "Try again.";
            }
        }
    }
}