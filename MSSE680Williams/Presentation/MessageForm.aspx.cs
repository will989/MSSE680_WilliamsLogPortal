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
    public partial class MessageForm : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label2.Text = "User's org id is:" + Convert.ToInt32(Session["usersOrgId"]);
        }


    //With Select enabled in the GridView save the selected correlationId
        //NOTE - arguments changed from EventArgs to GridViewSelectEventArgs
        //per http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.gridview.selectedindexchanged.aspx
        protected void GridView1_SelectedIndexChanging(Object sender, GridViewSelectEventArgs e)
        {
            // Get the currently selected row using the SelectedRow property.
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

           
            // With the Select column enabled, the third column (index 2) contains
            // the correlation id.
            //SelectedIndexChangingLabel.Text = "You selected " + row.Cells[2].Text + ".";
            int correlationId = Convert.ToInt32(row.Cells[2].Text);
            Session["Correlation"] = correlationId;
            Response.Redirect("CorrelatedMessages.aspx");

        }

        /* Some different things I tinkered with to transfer info to another page:
         
        //try passing info in a Session State http://msdn.microsoft.com/en-us/library/6ad7zeeb%28v=vs.90%29.aspx
        //but probably better to just pass the userId or orgId instead of a list
        protected void Button2_Click(Object sender, EventArgs e)
        {

            //get the orgId and put it into the Session:
            int orgId = Convert.ToInt32(ListBox3.SelectedValue);
            Session["orgId"] = orgId;
            var mm = new MessageManager();
            List<Message> orgMessages = mm.GetOrganizationMessages(orgId);
            Session["OrgMessages"] = orgMessages;
            Server.Transfer("OrganizationMessages.aspx", true);

        }

   
        //trying to pass value based on this article: http://msdn.microsoft.com/en-us/library/6c3yckfw%28v=vs.90%29.aspx
        public int SelectedOrg
        {
            get
            {
                return Convert.ToInt32(ListBox3.SelectedValue);
            }
        }
        */
        
        protected void ObjectDataSource3_Filtering(object sender, ObjectDataSourceFilteringEventArgs e)
        {
           /* if (SeverityList.Text == "")
            {
                e.ParameterValues.Clear();
                e.ParameterValues.Add("Severity", "3");
            }
            */
        }

        protected void SeverityList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}