using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class MessageFilter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //adding for debug purposes - should show value of listbox
        protected void SeverityList_OnChange(object sender, EventArgs e)
        {
            string s = ("SeverityList.Text = " + Convert.ToInt32(this.SeverityList.Text));
            Label1.Text = s;
        }

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