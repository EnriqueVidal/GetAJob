/// <summary>
/// Checks user authentication using FormsAuthentication
/// And redirects to login url for the application on fail.
/// </summary>
public class RequiresAuthenticationAttribute : System.Web.Mvc.ActionFilterAttribute {
	public override void OnActionExecuting (System.Web.Mvc.ActionExecutingContext filterContext)
	{
		if (! filterContext.HttpContext.User.Identity.IsAuthenticated)
		{
			string redirects_on_success = filterContext.HttpContext.Request.Url.AbsolutePath;
			string redirect_url = string.Format("?ReturnUrl={0}", redirects_on_success);
			string login_url = "/Sessions/SignIn" + redirect_url;
			filterContext.HttpContext.Response.Redirect(login_url, true);
		}
	}
}