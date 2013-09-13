<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Todos.aspx.cs" Inherits="_04.TodoList.Todos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:EntityDataSource
            runat="server"
            ID="EntityDataSourceTodos"
            ConnectionString="name=TodoListEntities"
            DefaultContainerName="TodoListEntities"
            EntitySetName="Todos"
            EnableFlattening="false"
            EnableUpdate="true"
            EnableDelete="true"
            EnableInsert="true"
            Include="Categories">
        </asp:EntityDataSource>

        <h1>TODOs</h1>

        <asp:GridView
            runat="server"
            DataSourceID="EntityDataSourceTodos"
            ID="DataGridTodos"
            ItemType="_04.TodoList.Models.Todos"
            AutoGenerateColumns="false"
            DataKeyNames="id"
            AllowPaging="true"
            PageSize="5"
            AllowSorting="true"
            ShowFooter="true">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <th>
                            <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="title" Text="Title" />
                        </th>
                        <th>
                            <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="Categories.name" Text="Category name" />
                        </th>
                        <th>Body</th>
                        <th>
                            <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="lastChange" Text="Last Change" />
                        </th>
                        <th>Operations</th>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <td>
                            <%#: Item.title %>
                        </td>
                        <td>
                            <%#: Item.Categories.name %>
                        </td>
                        <td>
                            <%#: Item.body %>
                        </td>
                        <td>
                            <%#: Item.lastChange %>
                        </td>
                        <td>
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditBtnTodo" />
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteBtnTodo" />
                        </td>
                    </ItemTemplate>

                    <FooterTemplate>
                        <td>
                            <asp:TextBox runat="server" ID="TodoTitle" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="TodoBody" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="TodoCategory" />
                        </td>
                        <td>
                            <asp:Button runat="server" CommandName="Insert" Text="Insert Todo" ID="InsertTodo" OnClick="InsertTodo" />
                        </td>
                    </FooterTemplate>

                    <EditItemTemplate>
                        <td>
                            Title: 
                            <asp:TextBox runat="server" ID="todoTitleEdit" Text="<%#: BindItem.title %>" />
                        </td>
                        <td>
                            Body: 
                            <asp:TextBox runat="server" ID="todoBodyEdit" Text="<%#: BindItem.body %>" />
                        </td>
                        <td>
                            Category: 
                            <asp:TextBox runat="server" ID="countryPopulationEdit" Text="<%#: BindItem.catId %>" />
                        </td>
                        <td>
                            <asp:Button runat="server" CommandName="Update" Text="Update" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <%--<asp:Button runat="server" ID="CatEdit" Text="Edit Categories" OnClick="ShowCategoriesForEditing" />--%>
        
        <asp:EntityDataSource
            runat="server"
            ID="CategoriesDataSource"
            ConnectionString="name=TodoListEntities"
            DefaultContainerName="TodoListEntities"
            EntitySetName="Categories"
            EnableFlattening="false"
            EnableUpdate="true"
            EnableDelete="true"
            EnableInsert="true">
        </asp:EntityDataSource>

        <h1>Categories</h1>

        <asp:GridView
            runat="server"
            ID="CategoriesGridView"
            ItemType="_04.TodoList.Models.Categories"
            AutoGenerateColumns="false"
            DataSourceID = "CategoriesDataSource"
            DataKeyNames="id"
            AllowPaging="true"
            PageSize="5"
            AllowSorting="true"
            ShowFooter="true">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <th>
                            <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="name" Text="Name" />
                        </th>
                        <th>Operations</th>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <td>
                            <%#: Item.name %>
                        </td>
                        <td>
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditBtnTodo" />
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteBtnTodo" />
                        </td>
                    </ItemTemplate>

                    <FooterTemplate>
                        <td>
                            <asp:TextBox runat="server" ID="CategoryName" />
                        </td>
                        <td>
                            <asp:Button runat="server" CommandName="Insert" Text="Insert Category" ID="InsertCategory" OnClick="InsertCategory" />
                        </td>
                    </FooterTemplate>

                    <EditItemTemplate>
                        <td>
                            Name: 
                            <asp:TextBox runat="server" ID="todoTitleEdit" Text="<%#: BindItem.name %>" />
                        </td>
                        <td>
                            <asp:Button runat="server" CommandName="Update" Text="Update" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
