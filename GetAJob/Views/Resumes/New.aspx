<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Application.master" Inherits="System.Web.Mvc.ViewPage<GetAJob.Models.Resume>" %>
<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="MainContentContent" ContentPlaceHolderID="MainContent" runat="server">
	<%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
	<% using (Html.BeginForm()) { %>
		<fieldset>
			<legend>Enter your resume info</legend>
			<%= Html.LabelFor(model => model.Content) %>
			<%= Html.ValidationMessageFor(model.Content) %>
			<%= Html.TextAreaFor( model => model.Content, "wymeditor" )
		</fieldset>
	<% } %>
</asp:Content>
