<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<GetAJob.Models.User>" MasterPageFile="~/Views/Shared/Application.Master" validateRequest="false" %>
<asp:Content id="page_header" ContentPlaceHolderID="head" runat="server">
	<title>Sign Up</title>
	<script type="text/javascript">
		$(function () {
			$("textarea").wymeditor({
    			skin: 		'compact',
    			logoHtml: 	''
			});
		});
    </script>
</asp:Content>
<asp:Content id="sign_in_form" ContentPlaceHolderID="MainContent" runat="server">
	<%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
	<% using (Html.BeginForm()) {%>
		<div id="personal_info">
			<%= Html.LabelFor(model => model.Person.FirstName) %>
			<%= Html.TextBoxFor(model => model.Person.FirstName) %>
			<%= Html.LabelFor(model => model.Person.LastName) %>
			<%= Html.TextBoxFor(model => model.Person.LastName) %>
			<%= Html.LabelFor(model => model.Person.Resume.LastEmployer) %>
			<%= Html.ValidationMessageFor(model => model.Person.Resume.LastEmployer) %>
			<%= Html.TextBoxFor(model => model.Person.Resume.LastEmployer) %>
			<%= Html.ValidationMessageFor(model => model.Person.Resume.Content) %>
			<%= Html.TextAreaFor(model => model.Person.Resume.Content) %>

			<a href="#account_info" class="link_button green_button">Continue to account info »</a>
			<div class="clear"></div>
		</div>

		<div id="account_info" style="display: none;">
			<%= Html.LabelFor(model => model.UserName) %>
			<%= Html.ValidationMessageFor(model => model.UserName) %>
			<%= Html.TextBoxFor(model => model.UserName) %>

			<%= Html.LabelFor(model => model.Email) %>
			<%= Html.ValidationMessageFor(model => model.Email) %>
			<%= Html.TextBoxFor(model => model.Email, new { @type = "email" }) %>

			<%= Html.LabelFor(model => model.Password) %>
			<%= Html.ValidationMessageFor(model => model.Password) %>
			<%= Html.PasswordFor(model => model.Password) %>
			<a href="#personal_info" class="link_button blue_button">« Back to Personal Info</a>
			<input type="submit" value="Submit" class="wymupdate" />
		</div>
	<% } %>
</asp:Content>
