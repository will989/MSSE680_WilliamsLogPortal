<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageFilter.aspx.cs" Inherits="Presentation.MessageFilter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Message Filtering</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
     <p>
                Filter Messages by Severity:</p>
            <p>
                <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetAllMessages" TypeName="Business.MessageManager"></asp:ObjectDataSource>
                <br/>
                <asp:ListBox ID="SeverityList" runat="server" AutoPostBack="True" Height="88px" OnSelectedIndexChanged="SeverityList_SelectedIndexChanged">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:ListBox>
                
            </p>
            <p>
                <br/>
                
            </p>
            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetAllMessagesAsDataSet"
                                  TypeName="Business.MessageManager"
                                  FilterExpression="Severity='{0}'" OnFiltering="ObjectDataSource3_Filtering">
               
                <filterparameters>

                    <asp:ControlParameter ControlID="SeverityList" Name ="Severity" PropertyName="SelectedValue"/>
                </filterparameters></asp:ObjectDataSource>
            
            <asp:GridView ID="GridView2" runat="server" AllowSorting="True" DataSourceID="ObjectDataSource3">
            </asp:GridView>
        
    </div>
    </form>
    
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/MessageForm.aspx">Message Form</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/AddMessage.aspx" Text="Add New Message"></asp:HyperLink>
</body>
</html>
