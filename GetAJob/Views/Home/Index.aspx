<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content id="home_page_content" ContentPlaceHolderID="MainContent">
	<div>
		<%= Html.Encode(ViewData["Message"]) %>
	</div>
</asp:Content>