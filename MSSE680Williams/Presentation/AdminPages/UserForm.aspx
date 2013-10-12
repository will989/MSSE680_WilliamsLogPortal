<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="Presentation.AdminPages.UserForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>Manage Users</title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
        
                <table>
                    <tr>
                        <td>UserName</td>
                        <td><asp:TextBox ID="UserName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Password</td>
                        <td><asp:TextBox ID="Password" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>First Name</td>
                        <td><asp:TextBox ID="FirstName" runat="server" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Last Name</td>
                        <td><asp:TextBox ID="LastName" runat="server" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Organization</td>
                        <td> <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:andy680ConnectionString %>" SelectCommand="SELECT [OrganizationId], [Name] FROM [Organizations]"></asp:SqlDataSource>
                            <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="OrganizationId"></asp:ListBox>
                
                        </td>
                    </tr>
                    <tr>
                        <td>Admin Flag</td>
                        <td><asp:CheckBox ID="AdminFlag" runat="server"></asp:CheckBox></td>
                    </tr>
            
                    <tr>
                        <td>Active Date</td>
                        <td><asp:Calendar ID="ActiveDate" runat="server" ></asp:Calendar></td>
                    </tr>
            
                    <tr>
                        <td>Inactive Date</td>
                        <td><asp:Calendar ID="InactiveDate" runat="server" ></asp:Calendar></td>
                    </tr>
            

                </table>
                <br/>
                <br/>
        
                <asp:Button ID="Button1" runat="server" Text="Add User" OnClick="Button1_Click" />
        
                <br/>
                <br />
        
       
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                
                List of users:<br />

                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="DAL.User" InsertMethod="AddUser" SelectMethod="GetAllUsers" TypeName="Business.UserManager" UpdateMethod="UpdateUser" DeleteMethod="DeleteUser">
                </asp:ObjectDataSource>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                        <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
                        <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                        <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                        <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                        <asp:BoundField DataField="OrganizationId" HeaderText="OrganizationId" SortExpression="OrganizationId" />
                        <asp:CheckBoxField DataField="AdminFlag" HeaderText="AdminFlag" SortExpression="AdminFlag" />
                        <asp:BoundField DataField="ActiveDate" HeaderText="ActiveDate" SortExpression="ActiveDate" />
                        <asp:BoundField DataField="InactiveDate" HeaderText="InactiveDate" SortExpression="InactiveDate" />
                    </Columns>
                </asp:GridView>
                <br />
    </div>
    </form>
</body>
</html>
