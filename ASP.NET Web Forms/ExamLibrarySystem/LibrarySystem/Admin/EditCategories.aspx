<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="LibrarySystem.Admin.EditCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Categories</h1>
    <asp:GridView runat="server" ID="catsGridView" AutoGenerateColumns="false"
        SelectMethod="catsGridView_GetData" AllowPaging="true" AllowSorting="true"
        DataKeyNames="id" PageSize="5" ItemType="LibrarySystem.Models.Categories" CellPadding="10">
        <Columns>
            <asp:BoundField DataField="name" HeaderText="Category name" SortExpression="name" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="Edit" CommandArgument="<%#: Item.id %>" OnCommand="Edit_Command" CssClass="btn"/>
                    <asp:LinkButton runat="server" Text="Delete" CommandArgument="<%#: Item.id %>" OnCommand="Delete_Command_Confurm" CssClass="btn"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:LinkButton ID="createNewCat" runat="server" Text="Create New Category" OnClick="createNewCat_Click" />

    <asp:Panel runat="server" ID="deleteConfirmationBox" Visible="false">
        <h3>Confirm Category Deletion?</h3>
        Name: <asp:TextBox runat="server" ID="categoryName" />
        <asp:LinkButton runat="server" Text="Yes" ID="deleteCatBtn" OnCommand="Delete_Command" CssClass="btn"/>
        <asp:LinkButton runat="server" Text="No" OnClick="CancelBtn_Click" CssClass="btn"/>
    </asp:Panel>

    <asp:Panel runat="server" ID="catEdit" Visible="false">
        <h3>Edit Category</h3>
        Category: <asp:TextBox runat="server" ID="catName" />
        <asp:LinkButton runat="server" Text="Save" ID="updateCat" OnCommand="SaveBtn_Click" />
        <asp:LinkButton runat="server" Text="Cancel" OnClick="CancelBtn_Click" />
    </asp:Panel>

    <asp:Panel runat="server" ID="catNew" Visible="false">
        <h3>Create New Category</h3>
        Category: <asp:TextBox runat="server" ID="newCatName" Text="Enter category name..." />
        <asp:LinkButton runat="server" Text="Create" OnClick="CreateCat_Click" CssClass="btn"/>
        <asp:LinkButton runat="server" Text="Cancel" OnClick="CancelBtn_Click" CssClass="btn"/>
    </asp:Panel>

</asp:Content>
