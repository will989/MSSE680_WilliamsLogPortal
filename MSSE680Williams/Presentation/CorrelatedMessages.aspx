<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorrelatedMessages.aspx.cs" Inherits="Presentation.CorrelatedMessages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
    
                Correlated messages:<br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="CorrelationId Selected: "></asp:Label>
                <asp:Label ID="Label2" runat="server"></asp:Label>
                <br />
    
            </div>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetCorrelatedMessages" TypeName="Business.MessageManager">
                <SelectParameters>
                    <asp:SessionParameter Name="correlationId" SessionField="Correlation" Type="Int32" />
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
        </form>
    </body>
</html>
