<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Generator.aspx.cs" Inherits="_01.RandomNumberGenerator.Generator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
        <input type="text" id="topBorder" runat="server" />
        <input type="text" id="bottomBorder" runat="server" />
        <input type="button" runat="server" value="Generate" OnServerClick="GenerateHandler"/>
        <input type="text" id="res" runat="server" />
    </form>
</body>
</html>
