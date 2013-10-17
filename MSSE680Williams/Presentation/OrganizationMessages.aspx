<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrganizationMessages.aspx.cs" Inherits="Presentation.OrganizationMessages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
    
                Messages for user&#39;s organization id:</div>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetOrganizationMessages" TypeName="Business.MessageManager">
                <SelectParameters>
                    <asp:SessionParameter Name="organizationId" SessionField="usersOrgId" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
                <Columns>
                    <asp:BoundField DataField="MessageId" HeaderText="MessageId" SortExpression="MessageId" />
                    <asp:BoundField DataField="CorrelationIdentifier" HeaderText="CorrelationIdentifier" SortExpression="CorrelationIdentifier" />
                    <asp:BoundField DataField="SendingOrgId" HeaderText="SendingOrgId" SortExpression="SendingOrgId" />
                    <asp:BoundField DataField="ReceivingOrgId" HeaderText="ReceivingOrgId" SortExpression="ReceivingOrgId" />
                    <asp:BoundField DataField="Severity" HeaderText="Severity" SortExpression="Severity" />
                    <asp:BoundField DataField="OrgMessage" HeaderText="OrgMessage" SortExpression="OrgMessage" />
                    <asp:BoundField DataField="Timestamp" HeaderText="Timestamp" SortExpression="Timestamp" />
                </Columns>
            </asp:GridView>
            <p>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/MessageForm.aspx">Message Form</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/MessageFilter.aspx">View/Filter Messages</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/AddMessage.aspx.aspx">Add New Messages</asp:HyperLink>
            </p>
        </form>
    </body>
</html>
