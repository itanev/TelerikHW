<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="_04.StudentRegistration.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="registrationForm" runat="server" onsubmit="FillContent">
        <label for="firstName">First name:</label>
        <asp:TextBox ID="firstName" runat="server" />
        
        <label for="lastName">Last name:</label>
        <asp:TextBox ID="lastName" runat="server" />

        <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" 
            ControlToValidate="facultyNum" ErrorMessage="Faculty number must be a number!" />

        <label for="facultyNum">Faculty number:</label>
        <asp:TextBox ID="facultyNum" runat="server"/>
        
        <label for="uni">University:</label>
        <asp:DropDownList ID="uni" runat="server">
            <asp:ListItem Value="SU">SU</asp:ListItem>
            <asp:ListItem Value="TU">TU</asp:ListItem>
            <asp:ListItem Value="UNSS">UNSS</asp:ListItem>
        </asp:DropDownList>

        <label for="speciality">Speciality:</label>
        <asp:DropDownList ID="speciality" runat="server">
            <asp:ListItem Value="IT">IT</asp:ListItem>
            <asp:ListItem Value="Electronics">Electronics</asp:ListItem>
            <asp:ListItem Value="Iconomics">Iconomics</asp:ListItem>
        </asp:DropDownList>
        
        <label for="courses">List of courses:</label>
        <asp:ListBox ID="courses" runat="server" SelectionMode="Multiple">
            <asp:ListItem Value="Math">Math</asp:ListItem>
            <asp:ListItem Value="Buisness">Buisness</asp:ListItem>
            <asp:ListItem Value="Phisics">Phisics</asp:ListItem>
        </asp:ListBox>

        <asp:Button runat="server" OnClick="Submit" Text="Submit"/>
    </form>
    
    <div runat="server" id="contentArea">

    </div>
</body>
</html>
