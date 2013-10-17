<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageForm.aspx.cs" Inherits="Presentation.MessageForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>Manage Messages</title>
        <style type="text/css">
            .auto-style1 {
                text-align: center;
            }
        </style>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <h1 class="auto-style1">Message Management Form<br/>
                </h1>
            </div>
            <p class="auto-style1">
        
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/AddMessage.aspx">Add New Message</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="OrganizationMessages.aspx">View User's Organization Messages</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/MessageFilter.aspx">Filter Messages by Severity</asp:HyperLink>
                    </p>
            <p>
        
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            &nbsp;</p>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetAllMessages" TypeName="Business.MessageManager"></asp:ObjectDataSource>
            <p>
                List of Messages:</p>
            <br />
            Select a row to view a list of messages with the same
            correlation id (the list of correlated messages):<br />
&nbsp;<asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2" onselectedindexchanging="GridView1_SelectedIndexChanging"
                >
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="MessageId" HeaderText="MessageId" SortExpression="MessageId" />
                    <asp:BoundField DataField="CorrelationIdentifier" HeaderText="CorrelationIdentifier" SortExpression="CorrelationIdentifier" />
                    <asp:BoundField DataField="SendingOrgId" HeaderText="SendingOrgId" SortExpression="SendingOrgId" />
                    <asp:BoundField DataField="ReceivingOrgId" HeaderText="ReceivingOrgId" SortExpression="ReceivingOrgId" />
                    <asp:BoundField DataField="Severity" HeaderText="Severity" SortExpression="Severity" />
                    <asp:BoundField DataField="OrgMessage" HeaderText="OrgMessage" SortExpression="OrgMessage" />
                    <asp:BoundField DataField="Timestamp" HeaderText="Timestamp" SortExpression="Timestamp" />
                </Columns>
            </asp:GridView>

            <br />
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/AddMessage.aspx">Add New Message</asp:HyperLink>
            <br />
            <br />
            View Messages for a user&#39;s Organization:&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="OrganizationMessages.aspx">View User's Organization Messages</asp:HyperLink>
                    <br />
            <br />
        
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                    </td>
                </tr>
  
        
            <p>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/MessageFilter.aspx">Filter Messages by Severity</asp:HyperLink>
                    </p>
  
        
        </form>
    </body>
</html>
