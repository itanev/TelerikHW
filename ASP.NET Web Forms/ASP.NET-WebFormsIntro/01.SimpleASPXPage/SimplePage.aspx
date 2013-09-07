<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimplePage.aspx.cs" Inherits="_01.SimpleASPXPage.SimplePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" Text="Enter your name" />
        <asp:TextBox runat="server" ID="nameHolder" />
        <asp:Button runat="server" ID="submitBtm" Text="Submit" OnClick="SubmitHandler" />
        
        <asp:Label runat="server" ID="theName" />
    </div>
    </form>
</body>
</html>
