<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_02.NorthwindEmployees.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:GridView ID="Employess" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:HyperLink 
                                runat="server"
                                Text='<%#: Eval("Name") %>'
                                Target="_blank" 
                                NavigateUrl='<%# "info.aspx?id=" + Eval("Id")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
