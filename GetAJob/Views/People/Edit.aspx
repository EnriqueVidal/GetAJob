<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Application.master" Inherits="System.Web.Mvc.ViewPage<GetAJob.Models.Person>" %>
<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="MainContentContent" ContentPlaceHolderID="MainContent" runat="server">
	<%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
	<% using (Html.BeginForm()) { %>
		<fieldset>
			<legend>Please enter your personal information</legend>
			<%= Html.LabelFor(model => model.FirstName) %>
			<%= Html.ValidationMessageFor(model => model.FirstName) %>
			<%= Html.TextBoxFor(model => model.FirstName) %>

			<%= Html.LabelFor(model => model.LastName) %>
			<%= Html.ValidationMessageFor(model => model.LastName) %>
			<%= Html.TextBoxFor(model => model.LastName) %>

			<input type="submit" value="Update" />
		</fieldset>
	<% } %>
</asp:Content>
