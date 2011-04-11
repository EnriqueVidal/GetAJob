<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Application.master" Inherits="System.Web.Mvc.ViewPage<GetAJob.Models.JobOffer>" validateRequest="false" %>
<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
	<title>Post a new Job Offer</title>
</asp:Content>
<asp:Content ID="MainContentContent" ContentPlaceHolderID="MainContent" runat="server">
	<%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
	<h1>Post a Job Offer</h1>
	<p>Just fill in the form and you'll be all set.</p>
	<% using (Html.BeginForm()) { %>
		<%= Html.LabelFor(m => m.Company) %>
		<%= Html.TextBoxFor(m =>  m.Company) %>
		<%= Html.LabelFor(m => m.Contact) %>
		<%= Html.TextBoxFor(m => m.Contact) %>
		<%= Html.LabelFor(m => m.JobTitle) %>
		<%= Html.TextBoxFor(m => m.JobTitle) %>
		<%= Html.TextAreaFor(m => m.JobDescription, new { @class = "wymeditor" }) %>
		
		<input type="submit" value="Submit" class="wymupdate" />
	<% } %>
</asp:Content>
