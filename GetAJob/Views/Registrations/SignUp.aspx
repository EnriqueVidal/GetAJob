<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<GetAJob.Persistence.Entities.User>" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<div>
		<%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %> 
		
		<h1>Register for an account</h1>
		<div class="column">
		 <% using (Html.BeginForm()) {%> 
			<fieldset>
				<legend>Register a new account</legend>
				<label for="Username">Username</label>
				<%= Html.TextBoxFor(model => model.Username) %>
				<%= Html.ValidationMessageFor(model => model.Username) %>
				
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

	</div>
</body>
