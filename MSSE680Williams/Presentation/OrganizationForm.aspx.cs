using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using DAL;

namespace Presentation
{
    public partial class OrganizationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Organization organization = new Organization();
            organization.Name = this.OrgName.Text;
            organization.Street = this.Street.Text;
            organization.City = this.City.Text;
            organization.State = this.State.Text;
            organization.Zip = this.Zip.Text;
            organization.StartDate = this.StartDate.SelectedDate;
            organization.EndDate = this.EndDate.SelectedDate;

            OrganizationManager om = new OrganizationManager();
            om.AddOrganization(organization);
        }
    }
}