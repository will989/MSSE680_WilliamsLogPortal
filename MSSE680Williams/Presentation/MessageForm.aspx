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
                        <td> <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:andy680ConnectionString %>" SelectCommand="SELECT [OrganizationId], [Name] FROM [Organizations]"></asp:SqlDataSource>
                            <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="OrganizationId"></asp:ListBox>
                
                        </td>
                    </tr>   
                    <tr>
                        <td>Receiving Organization Id</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ListBox ID="ListBox2" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="OrganizationId"></asp:ListBox>   
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
                &nbsp;</p>
            <p>
                List of Messages:</p>
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="MessageId" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:BoundField DataField="MessageId" HeaderText="MessageId" InsertVisible="False" ReadOnly="True" SortExpression="MessageId" />
                    <asp:BoundField DataField="CorrelationIdentifier" HeaderText="CorrelationIdentifier" SortExpression="CorrelationIdentifier" />
                    <asp:BoundField DataField="SendingOrgId" HeaderText="SendingOrgId" SortExpression="SendingOrgId" />
                    <asp:BoundField DataField="ReceivingOrgId" HeaderText="ReceivingOrgId" SortExpression="ReceivingOrgId" />
                    <asp:BoundField DataField="Severity" HeaderText="Severity" SortExpression="Severity" />
                    <asp:BoundField DataField="Timestamp" HeaderText="Timestamp" SortExpression="Timestamp" />
                    <asp:BoundField DataField="OrgMessage" HeaderText="OrgMessage" SortExpression="OrgMessage" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" DataSourceMode="DataSet" ConnectionString="<%$ ConnectionStrings:andy680ConnectionString %>" SelectCommand="SELECT [MessageId], [CorrelationIdentifier], [SendingOrgId], [ReceivingOrgId], [Severity], [Timestamp], [OrgMessage] FROM [Messages]"></asp:SqlDataSource>

        </form>
    </body>
</html>
