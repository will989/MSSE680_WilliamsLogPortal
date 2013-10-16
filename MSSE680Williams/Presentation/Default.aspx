<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentation.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="auto-style1">
                <h1>Log Management Portal Home Page</h1>
            </div>
            
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo.jpg" />

            <div>
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label><br />
                <br />
                <br />
                <asp:Button ID="cmdSignOut" runat="server" OnClick="cmdSignOut_Click" Text="Sign Out" />
            </div>
        
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AdminPages/UserForm.aspx">UserForm</asp:HyperLink>
            <p>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/AdminPages/OrganizationForm.aspx">OrganizationForm</asp:HyperLink>
            </p>
            <p>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/MessageForm.aspx">MessageForm</asp:HyperLink>
            </p>
        </form>
    </body>
</html>