<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibrarySystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Books</h1>
    
    <asp:Button runat="server" OnClick="Search_Click" Text="Search" />
    <asp:TextBox runat="server" ID="searchTB" placeholder="Search by book title / author..." />

    <div class="row" id="content" runat="server">
    </div>

</asp:Content>
