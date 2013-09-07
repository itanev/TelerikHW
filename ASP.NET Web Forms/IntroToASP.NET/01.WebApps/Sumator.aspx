<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sumator.aspx.cs" Inherits="_01.WebApps.Sumator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="secondNum" runat="server" />
        <asp:TextBox ID="firstNum" runat="server" />

        <asp:Button runat="server" ID="sumBtn" Text="Sum" OnClick="SumHandler"/>
        
        <asp:Label ID="result" runat="server" />
    </div>
    </form>
</body>
</html>
