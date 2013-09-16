<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="_03.Cookies.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        UserName: <asp:TextBox runat="server" ID="Username" />
        Password: <asp:TextBox runat="server" TextMode="Password" ID="pass" />
        <asp:Button ID="SendUserInfo" runat="server" OnClick="SendUserInfo_Click" Text="Login"/>
    </form>
</body>
</html>
