<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CachableUserControl.ascx.cs" Inherits="_01.CatchingPage.CachableUserControl" %>

<%@ OutputCache Duration="3600" VaryByParam="none" Shared="true" %>

<h2>Hi, I'm a cachable user contol.</h2>
<h2>My time is: <%= DateTime.Now.ToString() %></h2>