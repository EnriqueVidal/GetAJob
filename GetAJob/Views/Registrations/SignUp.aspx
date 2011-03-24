<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<GetAJob.Models.User>" MasterPageFile="~/Views/Shared/Application.Master" %>

<asp:Content id="page_header" ContentPlaceHolderID="head" runat="server">
	<title>Sign Up</title>
</asp:Content>
<asp:Content id="sign_in_form" ContentPlaceHolderID="MainContent" runat="server">
	<div>
		<%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %> 
		
		<h1>Register for an account</h1>
		<div class="column">
		 <% using (Html.BeginForm()) {%> 
			<fieldset>
				<legend>Register a new account</legend>
				<label for="Username">Username</label>
				<%= Html.TextBoxFor(model => model.UserName) %>
				<%= Html.ValidationMessageFor(model => model.UserName) %>
				
				<label for="Email">Email</label>
				<%= Html.TextBoxFor(model => model.Email, new { @type = "email" }) %>
				<%= Html.ValidationMessageFor(model => model.Email) %>
				
				<label for="Password">Password</label>
				<%= Html.PasswordFor(model => model.Password) %>
				<%= Html.ValidationMessageFor(model => model.Password) %>
				
				<input type="submit" value="Submit" />
			</fieldset>
		<% } %>
	</div>
</asp:Content>