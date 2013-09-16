<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Session.aspx.cs" Inherits="_02.Session.Session" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox runat="server" ID="Content" />
        <asp:Button runat="server" ID="SendToSession" Text="Send" OnClick="SendToSession_Click" />
        <asp:Button runat="server" ID="PrintSession" Text="Print Session" OnClick="PrintSession_Click" />
        <asp:Label runat="server" ID="SessionContent" />
    </form>
</body>
</html>
