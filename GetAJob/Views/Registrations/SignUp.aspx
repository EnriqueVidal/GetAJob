<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<GetAJob.Models.User>" MasterPageFile="~/Views/Shared/Application.Master" validateRequest="false" %>
<asp:Content id="page_header" ContentPlaceHolderID="head" runat="server">
	<title>Sign Up</title>
</asp:Content>
<asp:Content id="sign_in_form" ContentPlaceHolderID="MainContent" runat="server">
	<%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
	<h1>Getting Started</h1>
	<p>To help you find the perfect work place we need to know more of yourself. The more you tell us, The more your success rate at finding a job.</p>
	<p>Getting a job is simply following these 3 steps:</p>
	<% using (Html.BeginForm()) {%>
		<div id="personal_info">
			<p>Why not start by telling us who you are.</p>
			<%= Html.LabelFor(model => model.Person.FirstName) %>
			<%= Html.TextBoxFor(model => model.Person.FirstName) %>
			<%= Html.LabelFor(model => model.Person.LastName) %>
			<%= Html.TextBoxFor(model => model.Person.LastName) %>

			<a href="#professional_info" class="link_button green_button">Continue to Professional Info »</a>
		</div>

		<div id="professional_info" style="display:none">
			<p>Tell us all the skills that make you a valuable asset.</p>
			<%= Html.LabelFor(model => model.Person.Resume.LastEmployer) %>
			<%= Html.TextBoxFor(model => model.Person.Resume.LastEmployer) %>
			<%= Html.TextAreaFor(model => model.Person.Resume.Content, new { @class = "wymeditor" }) %>
			<a href="#personal_info" class="link_button blue_button">« Back to Personal Info</a>
			<a href="#account_info" class="link_button green_button">Continue to account info »</a>
		</div>

		<div id="account_info" style="display: none;">
			<p>We're almost there, just fill in the logins you'd like to use to Get A Job!</p>
			<%= Html.LabelFor(model => model.UserName) %>
			<%= Html.TextBoxFor(model => model.UserName) %>
			<%= Html.LabelFor(model => model.Email) %>
			<%= Html.TextBoxFor(model => model.Email, new { @type = "email" }) %>
			<%= Html.LabelFor(model => model.Password) %>
			<%= Html.PasswordFor(model => model.Password) %>
			<a href="#professional_info" class="link_button blue_button">« Back to Professional Info</a>
			<input type="submit" value="Submit" class="wymupdate" />
		</div>
	<% } %>
</asp:Content>
