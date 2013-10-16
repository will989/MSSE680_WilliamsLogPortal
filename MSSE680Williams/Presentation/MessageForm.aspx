<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageForm.aspx.cs" Inherits="Presentation.MessageForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>Manage Messages</title>
        </head>
    <body>
        <form id="form1" runat="server">
            <div>
        
                <table style="height: 278px; width: 524px">
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CorrelationId" Display="Dynamic" ErrorMessage="Correlation Id is required.">*</asp:RequiredFieldValidator>
                            Correlation Identifier</td>
                        <td><asp:TextBox ID="CorrelationId" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="CorrelationId" Display="Dynamic" ErrorMessage="Correlation Id must be an integer" ValidationExpression="\d+">Must be an integer.</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Sending Organization Id</td>
                    </tr>
                    <tr>
                        <td> 
                            <asp:ListBox ID="ListBox1" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="OrganizationId"></asp:ListBox>
                
                        </td>
                    </tr>   
                    <tr>
                        <td>Receiving Organization Id</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ListBox ID="ListBox2" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="OrganizationId"></asp:ListBox>   
                        </td>
                    </tr>
                    <tr>
                        <td>Severity
                        </td>
                        <td><asp:TextBox ID="Severity" runat="server" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Organization Message</td>
                        <td><asp:TextBox ID="Message" runat="server" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>TimeStamp</td>
                        <td>(This is auto-assigned when Add Message is clicked)</td>
                    </tr>
           

                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllOrganizations" TypeName="Business.OrganizationManager"></asp:ObjectDataSource>
           

                </table>
        
                <br/>
            </div>
            <p>
        
                <asp:Button ID="Button1" runat="server" Text="Add Message" OnClick="Button1_Click" />
            </p>
            <p>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </p>
            <p>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetAllMessages" TypeName="Business.MessageManager"></asp:ObjectDataSource>
            </p>
            <p>
                List of Messages:</p>
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2">
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
