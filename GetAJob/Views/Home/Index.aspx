<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Views/Shared/Application.Master" %>
<asp:Content id="home_page" ContentPlaceHolderID="MainContent" runat="server">
	<h1>Welcome to Get a Job</h1>
	<%= Html.Encode(ViewData["Message"]) %>
</asp:Content>