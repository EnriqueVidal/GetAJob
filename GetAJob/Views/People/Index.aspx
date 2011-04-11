<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Application.master" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.IEnumerable<GetAJob.Models.Person>>" %>
<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="MainContentContent" ContentPlaceHolderID="MainContent" runat="server">
	<h1>Find the perfect person for the job</h1>
	<% foreach (GetAJob.Models.Person person in Model) { %>
		<div class="person">
			<h2><%= person.FullName %></h2>
			<p>Recently worked for <%= person.Resume.LastEmployer %></p>
			<%= person.Resume.Content %>
		</div>
	<% } %>
</asp:Content>
