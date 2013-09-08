<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Generator.aspx.cs" Inherits="_02.RandomGeneratorWebControls.Generator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="secondNum" runat="server" />
        <asp:TextBox ID="firstNum" runat="server" />
        <asp:Button runat="server" OnClick="Generate" Text="Generate"/>
        <asp:Label ID="res" runat="server" />
    </form>
</body>
</html>
