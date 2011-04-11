<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Application.master" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.IEnumerable<GetAJob.Models.JobOffer>>" %>
<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
	<title>Find a Job in our list</title>
</asp:Content>
<asp:Content ID="MainContentContent" ContentPlaceHolderID="MainContent" runat="server">
	<h1>Navigate through our list of job offers</h1>
	<% foreach (GetAJob.Models.JobOffer offer in Model) { %>
		<div class="job_offer">
			<h2><%= offer.Company %> - <%= offer.JobTitle %></h2>
			<%= offer.JobDescription %>
			<p>Contact: <span class="contact_info"><%= offer.Contact %></span></p>
		</div>
	<% } %>
</asp:Content>
