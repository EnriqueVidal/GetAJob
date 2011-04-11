<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Application.master" Inherits="System.Web.Mvc.ViewPage<GetAJob.Models.Person>" validateRequest="false" %>
<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="MainContentContent" ContentPlaceHolderID="MainContent" runat="server">
	<%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
	<% using (Html.BeginForm()) { %>
		<h1>Profile Update</h1>
		<p>Update enter your personal information</p>
		<div id="personal_info">
			<%= Html.HiddenFor(model => model.Id) %>
			<%= Html.LabelFor(model => model.FirstName) %>
			<%= Html.TextBoxFor(model => model.FirstName) %>

			<%= Html.LabelFor(model => model.LastName) %>
			<%= Html.TextBoxFor(model => model.LastName) %>
			
			<a href="#resume_info" class="link_button green_button">Continue to Edit Resume »</a>
			<input type="submit" value="Update" />
		</div>
		
		<div id="resume_info" style="display:none;">
			<%= Html.HiddenFor(model => model.Resume.Id) %>
			<%= Html.LabelFor(model => model.Resume.LastEmployer) %>
			<%= Html.TextBoxFor(model => model.Resume.LastEmployer) %>
			<%= Html.TextAreaFor(model => model.Resume.Content, new { @class = "wymeditor" }) %>
			
			<a href="#personal_info" class="link_button blue_button">« Go back to Personal Info</a>
			<input type="submit" value="Update" />
		</div>
	<% } %>
</asp:Content>
