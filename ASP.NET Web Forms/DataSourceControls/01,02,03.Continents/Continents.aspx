<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Continents.aspx.cs" Inherits="_01.Continents.Continents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:EntityDataSource
            runat="server"
            ID="EntityDataSourceContinents"
            ConnectionString="name=ContinentsEntities"
            DefaultContainerName="ContinentsEntities"
            EntitySetName="Continents"
            EnableUpdate="true" />

        <asp:ListBox
            runat="server"
            DataSourceID="EntityDataSourceContinents"
            DataTextField="name"
            DataValueField="id"
            ID="ListBoxContinents"
            AutoPostBack="true" />

        <asp:EntityDataSource
            runat="server"
            ID="EntityDataSourceCountries"
            ConnectionString="name=ContinentsEntities"
            DefaultContainerName="ContinentsEntities"
            EntitySetName="Countries"
            Include="Continents"
            Where="it.continentId=@contId"
            EnableFlattening="false"
            EnableUpdate="true"
            EnableDelete="true"
            EnableInsert="true">
            <WhereParameters>
                <asp:ControlParameter Name="contId" Type="Int32" ControlID="ListBoxContinents" />
            </WhereParameters>
        </asp:EntityDataSource>

        <asp:GridView
            runat="server"
            DataSourceID="EntityDataSourceCountries"
            ID="DataGridCountries"
            ItemType="_01.Continents.Models.Countries"
            AutoGenerateColumns="false"
            DataKeyNames="id"
            AllowPaging="true"
            PageSize="1"
            AllowSorting="true"
            ShowFooter="true">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <th>
                            <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="name" Text="Name" />
                        </th>
                        <th>
                            <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="Continents.name" Text="Continent" />
                        </th>
                        <th>
                            <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="language" Text="Language" />
                        </th>
                        <th>
                            <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="population" Text="Population" />
                        </th>
                        <th>Operations</th>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <td>
                            <%#: Item.name %>
                        </td>
                        <td>
                            <%#: Item.Continents.name %>
                        </td>
                        <td>
                            <%#: Item.language %>
                        </td>
                        <td>
                            <%#: Item.population %>
                        </td>
                        <td>
                            <asp:Button runat="server" CommandName="Select" Text="Select" ID="SelectBtnCountry" />
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditBtnCountry" />
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteBtnCountry" />
                        </td>
                    </ItemTemplate>

                    <FooterTemplate>
                        <td>
                            <asp:TextBox runat="server" ID="CountryName" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="CountryContinentName" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="CountryLanguage" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="CountryPopulation" />
                        </td>
                        <td>
                            <asp:Button runat="server" CommandName="Insert" Text="Insert Country" ID="InsertCountry" OnClick="InsertCountry" />
                        </td>
                    </FooterTemplate>

                    <EditItemTemplate>
                        <td>Country Name: 
                            <asp:TextBox runat="server" ID="countryNameEdit" Text="<%#: BindItem.name %>" />
                        </td>
                        <td>Continent: 
                            <asp:TextBox runat="server" ID="countryContinentEdit" Text="<%#: BindItem.continentId %>" />
                        </td>
                        <td>Language: 
                            <asp:TextBox runat="server" ID="countryLanguageEdit" Text="<%#: BindItem.language %>" />
                        </td>
                        <td>Population: 
                            <asp:TextBox runat="server" ID="countryPopulationEdit" Text="<%#: BindItem.population %>" />
                        </td>
                        <td>
                            <asp:Button runat="server" CommandName="Update" Text="Update" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:EntityDataSource
            runat="server"
            ID="EntityDataSourceTowns"
            ConnectionString="name=ContinentsEntities"
            DefaultContainerName="ContinentsEntities"
            EntitySetName="Towns"
            Include="Countries"
            Where="it.countryId=@currCountryId"
            EnableFlattening="false"
            EnableUpdate="true"
            EnableDelete="true"
            EnableInsert="true">
            <WhereParameters>
                <asp:ControlParameter Type="Int32" ControlID="DataGridCountries" Name="currCountryId" />
            </WhereParameters>
        </asp:EntityDataSource>

        <asp:ListView
            id="TownsListView"
            runat="server"
            DataSourceID="EntityDataSourceTowns"
            DataKeyNames="id"
            ItemType="_01.Continents.Models.Towns"
            InsertItemPosition="LastItem"
            OnItemInserting="InsertTown">
            <LayoutTemplate>
                <ul>
                    <li>
                        <asp:Button runat="server" CommandName="Sort" CommandArgument="name" Text="Sort By Name" />
                        <asp:Button runat="server" CommandName="Sort" CommandArgument="population" Text="Sort By Population" />
                        <asp:Button runat="server" CommandName="Sort" CommandArgument="Countries.name" Text="Sort By Country" />
                    </li>
                    <li>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </li>
                    <li>
                        <asp:DataPager runat="server" PageSize="3">
                            <Fields>
                                <asp:NextPreviousPagerField
                                    ShowFirstPageButton="true" ShowLastPageButton="true"
                                    ShowNextPageButton="true" ShowPreviousPageButton="true"/>
                            </Fields>
                        </asp:DataPager>
                    </li>
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <ul>
                    <li>Name: <%#: Item.name %></li>
                    <li>Country Name: <%#: Item.Countries.name %></li>
                    <li>Population: <%#: Item.population %></li>
                    <li>
                        <asp:Button runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button runat="server" CommandName="Delete" Text="Delete" />
                    </li>
                </ul>
            </ItemTemplate>
            <EditItemTemplate>
                <ul>
                    <li>Name: 
                        <asp:TextBox runat="server" Text="<%#: BindItem.name %>" ID="TownName" />
                    </li>
                    <li>Country: 
                        <asp:TextBox runat="server" Text="<%#: BindItem.countryId %>" ID="TownCountryId" />
                    </li>
                    <li>Population: 
                        <asp:TextBox runat="server" Text="<%#: BindItem.population %>" ID="TownPopulation" />
                    </li>
                </ul>
                <asp:Button runat="server" CommandName="Update" Text="Update" />
                <asp:Button runat="server" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                <ul>
                    <li>
                        Name: 
                        <asp:TextBox runat="server" ID="TownName" />
                    </li>
                    <li>
                        Country: 
                        <asp:TextBox runat="server" ID="TownCountryName" />
                    </li>
                    <li>
                        Population: 
                        <asp:TextBox runat="server" ID="TownPopulation" />
                    </li>
                </ul>
                <asp:Button runat="server" CommandName="Insert" Text="Insert" />
                <asp:Button runat="server" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
        </asp:ListView>
    </form>
</body>
</html>
