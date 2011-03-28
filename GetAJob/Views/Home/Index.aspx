<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Views/Shared/Application.Master" %>
<asp:Content id="home_page" ContentPlaceHolderID="MainContent" runat="server">
	<%= Html.Encode(ViewData["Message"]) %>
</asp:Content>