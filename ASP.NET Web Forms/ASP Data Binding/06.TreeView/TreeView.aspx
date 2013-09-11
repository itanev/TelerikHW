<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreeView.aspx.cs" Inherits="_06.TreeView.TreeView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:XmlDataSource ID="XmlDataSource" runat="server" DataFile="~/App_Data/AspNetControls.xml"></asp:XmlDataSource>
        <asp:TreeView ID="TreeView1" runat="server" DataSourceID="XmlDataSource" ShowCheckBoxes="Leaf">
            <DataBindings>
                <asp:TreeNodeBinding DataMember="ToolBox" Text="Asp.Net ToolBox" />
                <asp:TreeNodeBinding DataMember="Item" TextField="Name" />
                <asp:TreeNodeBinding DataMember="Option" TextField="Control" />
            </DataBindings>
        </asp:TreeView>
    </form>
</body>
</html>
