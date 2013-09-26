<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="LibrarySystem.BookDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Book Details</h1>
    <asp:ListView runat="server" ID="bookDetails" ItemType="LibrarySystem.Models.Books">
        <LayoutTemplate>
            <div runat="server" id="itemPlaceHolder"> </div>
        </LayoutTemplate>
        <ItemTemplate>
            <h3><%#: Item.title %></h3>
            <p class="author"><%#: Item.author %></p>
            <p class="isbn"><%#: Item.isbn %></p>
            <a href="<%#: Item.webSite %>" class="website"><%#: Item.webSite %></a>
            <p class="descr"><%#: Item.description %></p>
            <a href="~/" runat="server">Back to books</a>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
