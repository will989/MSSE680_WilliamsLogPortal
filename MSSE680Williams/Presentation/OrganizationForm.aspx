<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrganizationForm.aspx.cs" Inherits="Presentation.OrganizationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>Manage Organizations</title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
        
                <table>
                    <tr>
                        <td>Organization Name</td>
                        <td><asp:TextBox ID="OrgName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Street Address</td>
                        <td><asp:TextBox ID="Street" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>City</td>
                        <td><asp:TextBox ID="City" runat="server" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>State</td>
                        <td><asp:TextBox ID="State" runat="server" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Zip Code</td>
                        <td><asp:TextBox ID="Zip" runat="server" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Start Date</td>
                        <td><asp:Calendar ID="StartDate" runat="server"></asp:Calendar></td>
                    </tr>
            
                    <tr>
                        <td>End Date</td>
                        <td><asp:Calendar ID="EndDate" runat="server" ></asp:Calendar></td>
                    </tr>
            

                </table>
                <br/>
                <br/>
                
                <asp:Button ID="Button1" runat="server" Text="Add Organization" OnClick="Button1_Click" />
        
                <br/>
                <br/>
                

    
                <br />
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="DAL.Organization" DeleteMethod="DeleteOrganization" InsertMethod="AddOrganization" SelectMethod="GetOrganization" TypeName="Services.OrganizationSvcImpl" UpdateMethod="UpdateOrganization">
                    <SelectParameters>
                        <asp:Parameter Name="id" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                        <asp:BoundField DataField="OrganizationId" HeaderText="OrganizationId" SortExpression="OrganizationId" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Street" HeaderText="Street" SortExpression="Street" />
                        <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                        <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                        <asp:BoundField DataField="Zip" HeaderText="Zip" SortExpression="Zip" />
                        <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" />
                        <asp:BoundField DataField="EndDate" HeaderText="EndDate" SortExpression="EndDate" />
                    </Columns>
                </asp:GridView>
                <br />
                

    
            </div>
        </form>
    </body>
</html>