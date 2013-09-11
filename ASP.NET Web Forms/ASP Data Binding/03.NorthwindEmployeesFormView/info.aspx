<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="info.aspx.cs" Inherits="_02.NorthwindEmployees.info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:FormView runat="server" ID="Details">
            <HeaderTemplate>  
                Employee 
            </HeaderTemplate>  
            <ItemTemplate>  
                First Name: <%#: Eval("FirstName") %><br />   
                Last Name: <%#: Eval("LastName") %><br />   
                Title: <%#: Eval("Title") %><br />   
                Title Of Courtesy: <%#: Eval("TitleOfCourtesy") %><br />   
                Birth Date: <%#: Eval("BirthDate") %><br />   
                Hire Date: <%#: Eval("HireDate") %><br />   
                Address: <%#: Eval("Address") %><br />   
                City: <%#: Eval("City") %><br />   
                Region: <%#: Eval("Region") %><br />   
                Postal Code: <%#: Eval("PostalCode") %><br />   
                Country: <%#: Eval("Country") %><br />   
                Home Phone: <%#: Eval("HomePhone") %><br />   
                Notes: <%#: Eval("Notes") %><br />   
                Reports To: <%#: Eval("ReportsTo") %><br />   
                Photo Path: <%#: Eval("PhotoPath") %><br />   
            </ItemTemplate> 
        </asp:FormView>
    </form>
</body>
</html>
