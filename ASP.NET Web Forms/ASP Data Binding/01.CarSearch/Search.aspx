<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="_01.CarSearch.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="CarSearch" runat="server">
        <asp:DropDownList runat="server" ID="Models" OnSelectedIndexChanged="OnModelChange" AutoPostBack="true" />
        <asp:DropDownList runat="server" ID="Producers" OnSelectedIndexChanged="OnProducerChange" AutoPostBack="true" />
        <asp:CheckBoxList runat="server" ID="Extras" AutoPostBack="true"/>
        <asp:Button runat="server" OnClick="OnSubmit" Text="Search"/>

        <asp:Literal runat="server" ID="info" />
    </form>
</body>
</html>
