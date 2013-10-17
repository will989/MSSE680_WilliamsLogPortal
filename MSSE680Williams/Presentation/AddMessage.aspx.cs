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
    public partial class AddMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Message message = new Message();

            //convert input to integers where needed
            message.CorrelationIdentifier = Convert.ToInt32(this.CorrelationId.Text);

            //list box to select sending org id
            System.Diagnostics.Debug.WriteLine("ListBox1.Text = " + Convert.ToInt32(this.ListBox1.Text));

            //system prompted to change my if/else to this format and it seems to work fine
            //if a value has been selected from the drop-down, use it, otherwise use what is entered
            //in the text box
            message.SendingOrgId = Convert.ToInt32(ListBox1.SelectedValue); //!= null ? this.ListBox1.Text : this.SendingOrgId.Text);
            message.ReceivingOrgId = Convert.ToInt32(ListBox2.SelectedValue); //!= null ? this.ListBox2.Text : this.ReceivingOrgId.Text);

            //message.ReceivingOrgId = Convert.ToInt32(this.ReceivingOrgId.Text);
            //message.Severity = Convert.ToInt32(this.Severity.Text);
            message.Severity = Convert.ToInt32(SeverityList0.SelectedValue);
            message.OrgMessage = this.Message.Text;

            //Set the timestamp automatically
            DateTime currentDate = DateTime.Now;
            message.Timestamp = currentDate;

            var mm = new MessageManager();
            mm.AddMessage(message);

            if (Page.IsValid)
            {
                Label1.Text = "Your message has been added.";
            }

        }

        protected void SeverityList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //adding for debug purposes - should show value of listbox
        protected void SeverityList_OnChange(object sender, EventArgs e)
        {
            //string s = ("SeverityList.Text = " + Convert.ToInt32(this.SeverityList0.Text));
            //Label1.Text = s;
        }
    }
}