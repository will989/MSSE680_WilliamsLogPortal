using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using DAL;

namespace Presentation
{
    public partial class UserForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //set label 1 text to empty string when the page loads
            Label1.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            User user = new User();

            //convert input to integers where needed
            user.UserName = this.UserName.Text;
            user.Password = this.Password.Text;
            user.FirstName = this.FirstName.Text;
            user.LastName = this.LastName.Text;
            //list box choice should set this value
            user.OrganizationId = Convert.ToInt32(ListBox1.SelectedValue);
            var adminFlag = this.AdminFlag;
            if (adminFlag != null) user.AdminFlag = true;
            user.ActiveDate = this.ActiveDate.SelectedDate;
            user.InactiveDate = this.InactiveDate.SelectedDate;

            UserManager um = new UserManager();
            um.AddUser(user);

            if (Page.IsValid)
            {
                Label1.Text = "Your user has been added.";
            }
        }
    }
}