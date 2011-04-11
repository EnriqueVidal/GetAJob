<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Application.master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="page_head" ContentPlaceHolderID="head" runat="server">
	<title>Sign In</title>
</asp:Content>
<asp:Content ID="page_content" ContentPlaceHolderID="MainContent" runat="server">
	<div id="login_form">
		<h1>User Sign In</h1>
		<p>Sign in and look for the latest job offers.</p>
		<div id="user_signin">
			<% using (Html.BeginForm()) { %>
				<%= Html.Label("Username") %>
		    	<%= Html.TextBox("Username") %>
		    	<%= Html.ValidationMessage("Username") %>
		    
		    	<%= Html.Label("Password") %>
		    	<%= Html.Password("Password") %>
		    	<%= Html.ValidationMessage("Password") %>
		    	<input type="submit" value="Sig In" />
		    <% } %>
	    </div>
	</div>
</asp:Content>
