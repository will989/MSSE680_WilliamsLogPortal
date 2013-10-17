<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMessage.aspx.cs" Inherits="Presentation.AddMessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Message</title>
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
                        <td class="auto-style3">Receiving Organization Id</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ListBox ID="ListBox2" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="OrganizationId"></asp:ListBox>   
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Severity
                        </td>
                        <td>
                            <asp:ListBox ID="SeverityList0" runat="server" AutoPostBack="False" Height="88px" OnSelectedIndexChanged="SeverityList_SelectedIndexChanged">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                            </asp:ListBox>
                
                        </td>
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
            
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/MessageForm.aspx">Message Form</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/MessageFilter.aspx">View/Filter Messages</asp:HyperLink>
        </p>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    </form>
</body>
</html>
