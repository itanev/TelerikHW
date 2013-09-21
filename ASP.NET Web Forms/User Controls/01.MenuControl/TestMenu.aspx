<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestMenu.aspx.cs" Inherits="_01.MenuControl.TestMenu" %>

<%@ Register Src="~/Menu.ascx" TagPrefix="myMenu" TagName="Menu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <myMenu:Menu runat="server" id="Menu" Font="Verdana" FontColor="blue" />
    </form>
</body>
</html>
