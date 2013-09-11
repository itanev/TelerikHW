<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_05.ListView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ListView runat="server" ID="employees">
            <LayoutTemplate>
                <table border="1">
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Title</th>
                        <th>Title Of Courtesy</th>
                        <th>Birth Date</th>
                        <th>Hire Date</th>
                        <th>Address</th>
                        <th>City</th>
                        <th>Region</th>
                        <th>Postal Code</th>
                        <th>Country</th>
                        <th>Home Phone</th>
                        <th>Notes</th>
                    </tr>
                    <tbody runat="server" id="itemPlaceholder">
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label runat="server"><%#: Eval("FirstName") %></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server"><%#: Eval("LastName") %></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server"><%#: Eval("Title") %></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server"><%#: Eval("TitleOfCourtesy") %></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server"><%#: Eval("BirthDate") %></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server"><%#: Eval("HireDate") %></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server"><%#: Eval("Address") %></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server"><%#: Eval("City") %></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server"><%#: Eval("Region") %></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server"><%#: Eval("PostalCode") %></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server"><%#: Eval("Country") %></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server"><%#: Eval("HomePhone") %></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server"><%#: Eval("Notes") %></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </form>
</body>
</html>
