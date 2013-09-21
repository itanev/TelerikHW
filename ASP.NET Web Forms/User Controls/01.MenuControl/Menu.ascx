<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="_01.MenuControl.Menu" %>

<asp:DataList runat="server" id="menu" GridLines="Both">
    <ItemTemplate>
        <a runat="server" href=<%#: Eval("Url") %>><%#: Eval("Name") %></a> 
    </ItemTemplate>
</asp:DataList>
