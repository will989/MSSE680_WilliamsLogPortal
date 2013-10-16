using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using DAL;

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
                //if we get a good user, then put their userName, userId, and orgId into the Session:
                UserManager userManager = new UserManager();
                User user = userManager.GetUser(userName);
                string name = user.UserName;
                int usersOrgId = user.OrganizationId;
                int userId = user.UserId;
                Session["UserName"] = name;
                Session["usersOrgId"] = usersOrgId;
                Session["userId"] = userId;

                //and send them on to the next page
                FormsAuthentication.RedirectFromLoginPage(txtName.Text, false);
            }
            else
            {
                lblStatus.Text = "Try again.";
            }
        }
    }
}