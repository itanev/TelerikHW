<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_04.Repeater.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Repeater runat="server" ID="employees">
            <HeaderTemplate>
                <h1>Employees</h1>
            </HeaderTemplate>
            <ItemTemplate>
                <hr />
                Name: <%#: DataBinder.Eval(Container.DataItem, "FirstName") + " "
                        + DataBinder.Eval(Container.DataItem, "LastName") 
                %>
                <br />
                Title: <%#: DataBinder.Eval(Container.DataItem, "Title") %>
                <br />
                Birth Date: <%#: DataBinder.Eval(Container.DataItem, "BirthDate") %>
                <br />
                Hire Date: <%#: DataBinder.Eval(Container.DataItem, "HireDate") %>
                <br />
                Address: <%#: DataBinder.Eval(Container.DataItem, "Address") %>
                <br />
                City: <%#: DataBinder.Eval(Container.DataItem, "City") %>
                <br />
                Region: <%#: DataBinder.Eval(Container.DataItem, "Region") %>
                <br />
                Postal Code: <%#: DataBinder.Eval(Container.DataItem, "PostalCode") %>
                <br />
                Country: <%#: DataBinder.Eval(Container.DataItem, "Country") %>
                <br />
                Home Phone: <%#: DataBinder.Eval(Container.DataItem, "HomePhone") %>
                <br />
                Notes: <%#: DataBinder.Eval(Container.DataItem, "Notes") %>
                <hr />
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
