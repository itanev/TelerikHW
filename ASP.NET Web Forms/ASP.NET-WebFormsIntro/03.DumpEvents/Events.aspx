<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="_03.DumpEvents.Events" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btn" runat="server" Text="OK" OnClick="ButtonOK_Click" OnInit="ButtonOK_Init"
            OnLoad="ButtonOK_Load" OnPreRender="ButtonOK_PreRender" OnUnload="ButtonOK_Unload"/>
        <asp:Label runat="server" ID="msg" />
    </div>
    </form>
</body>
</html>
