<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="LibrarySystem.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 runat="server" id="queryText"></h1>
    <asp:ListView ID="resultBooks" runat="server" ItemType="LibrarySystem.Models.BookModel"
        SelectMethod="booksListView_GetData" DataKeyNames="Id">
        <LayoutTemplate>
            <ul>
                <div runat="server" id="itemPlaceHolder"></div>
            </ul>
            <asp:DataPager ID="booksPager" runat="server"
                PagedControlID="resultBooks" PageSize="10">
                <Fields>
                    <asp:NextPreviousPagerField FirstPageText="&lt;&lt;" ShowFirstPageButton="True"
                        ShowNextPageButton="False" ShowPreviousPageButton="False" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField LastPageText="&gt;&gt;" ShowLastPageButton="True"
                        ShowNextPageButton="False" ShowPreviousPageButton="False" />
                </Fields>
            </asp:DataPager>
        </LayoutTemplate>
        <EmptyDataTemplate>
            <h3>Nothing found.</h3>
        </EmptyDataTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink runat="server" Text=<%#: Item.Title + " by " + Item.Author %>
                    NavigateUrl=<%#: "~/BookDetails.aspx?id=" + Item.Id %> />
                (Category: <%#: Item.Category %>)
            </li>
        </ItemTemplate>
    </asp:ListView>

    <asp:HyperLink runat="server" NavigateUrl="~/" />
</asp:Content>
