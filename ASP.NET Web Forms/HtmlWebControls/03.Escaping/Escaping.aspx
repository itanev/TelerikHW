<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Escaping.aspx.cs" Inherits="_03.Escaping.Escaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="txtBox" runat="server" />
        <asp:Button runat="server" OnClick="ShowText" Text="Show Text"/>
        <asp:Label ID="txt" runat="server"/>
    </form>
</body>
</html>
