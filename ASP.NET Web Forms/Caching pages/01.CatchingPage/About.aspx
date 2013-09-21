<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="_01.CatchingPage.About" %>

<%@ OutputCache Duration="3600" VaryByParam="None"%>
<%@ Register Src="~/CachableUserControl.ascx" TagPrefix="uc1" TagName="CachableUserControl" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h1><%: Title %></h1>
        <p class="lead">Your app description page.</p>
        <uc1:CachableUserControl runat="server" ID="CachableUserControl" />
    </header>

    <div class="row-fluid">
        <div class="span12">
            <p>Use this area to provide additional information.</p>
        </div>
    </div>

</asp:Content>
