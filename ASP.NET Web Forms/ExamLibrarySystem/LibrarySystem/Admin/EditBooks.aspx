<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBooks.aspx.cs" Inherits="LibrarySystem.Admin.EditBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Books</h1>
    <asp:GridView runat="server" ID="booksGridView" AutoGenerateColumns="false"
        SelectMethod="booksGridView_GetData" AllowPaging="true" AllowSorting="true"
        DataKeyNames="Id" PageSize="5" ItemType="LibrarySystem.Models.BookModel" CellPadding="10">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"/>
            <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
            <asp:BoundField DataField="Isbn" HeaderText="ISBN" SortExpression="Isbn" />
            <asp:BoundField DataField="WebSite" HeaderText="Web Site" SortExpression="WebSite" />
            <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="Edit" CommandArgument="<%#: Item.Id %>" OnCommand="Edit_Command"/>
                    <asp:LinkButton runat="server" Text="Delete" CommandArgument="<%#: Item.Id %>" OnCommand="Delete_Command_Confirm"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:LinkButton ID="createNewBook" runat="server" Text="Create New Book" OnClick="createNewBook_Click" />

    <asp:Panel runat="server" ID="bookEdit" Visible="false">
        <h3>Edit Book</h3>
        <ul>
            <li>Title:
            <asp:TextBox runat="server" ID="bookTitle" />
            </li>
            <li>Author(s):
            <asp:TextBox runat="server" ID="bookAuthor" />
            </li>
            <li>ISBN:
            <asp:TextBox runat="server" ID="bookIsbn" />
            </li>
            <li>Web Site:
            <asp:TextBox runat="server" ID="bookWebSite" />
            </li>
            <li>Description:
            <asp:TextBox runat="server" ID="bookDescr" TextMode="MultiLine" />
            </li>
            <li>Category:
            <asp:DropDownList runat="server" ID="bookCats" DataValueField="name" />
            </li>
            <li>
                <asp:LinkButton runat="server" Text="Save" ID="updateBook" OnCommand="SaveBtn_Click" />
                <asp:LinkButton runat="server" Text="Cancel" OnClick="CancelBtn_Click" />
            </li>
        </ul>
    </asp:Panel>

    <asp:Panel runat="server" ID="deleteConfirmationBox" Visible="false">
        <h3>Confirm Book Deletion?</h3>
        Title: <asp:TextBox runat="server" ID="categoryName" />
        <asp:LinkButton runat="server" Text="Yes" ID="deleteCatBtn" OnCommand="Delete_Command" />
        <asp:LinkButton runat="server" Text="No" OnClick="CancelBtn_Click" />
    </asp:Panel>

    <asp:Panel runat="server" ID="bookNew" Visible="false">
        <h3>Create New Book</h3>
        <ul>
            <li>Title:
        <asp:TextBox runat="server" ID="bookNewTitle" />
            </li>
            <li>Author(s):
        <asp:TextBox runat="server" ID="bookNewAuthor" />
            </li>
            <li>ISBN:
        <asp:TextBox runat="server" ID="bookNewIsbn" />
            </li>
            <li>Web Site:
        <asp:TextBox runat="server" ID="bookNewWebSite" />
            </li>
            <li>Description:
        <asp:TextBox runat="server" ID="bookNewDescr" TextMode="MultiLine" />
            </li>
            <li>Category:
        <asp:DropDownList runat="server" ID="bookNewCat" DataValueField="name" />
            </li>
            <li>
                <asp:LinkButton runat="server" Text="Create" OnClick="CreateBook_Click" />
                <asp:LinkButton runat="server" Text="Cancel" OnClick="CancelBtn_Click" />
            </li>
        </ul>
    </asp:Panel>
</asp:Content>
