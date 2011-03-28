<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Application.master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="page_head" ContentPlaceHolderID="head" runat="server">
	<title>Sign In</title>
</asp:Content>
<asp:Content ID="page_content" ContentPlaceHolderID="MainContent" runat="server">
	<div id="login_form">
	<%= Html.ValidationSummary(true, "Login was unsuccessful.") %>
		<fieldset>
			<legend>Sign In</legend>
			<% using (Html.BeginForm()) { %>
				<%= Html.Label("Username") %>
		    	<%= Html.TextBox("Username") %>
		    	<%= Html.ValidationMessage("Username") %>
		    
		    	<%= Html.Label("Password") %>
		    	<%= Html.Password("Password") %>
		    	<%= Html.ValidationMessage("Password") %>
		    	<input type="submit" value="Sig In" />
		    <% } %>
	    </fieldset>
	</div>
</asp:Content>
