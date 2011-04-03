using System;
using System.Web.Mvc;
using System.Web.Security;
using GetAJob.Core;
using NHibernate;
using Account = GetAJob.Models.User;

namespace GetAJob.Controllers
{
	[HandleError]
	public class SessionsController : Controller
	{
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult SignIn()
		{
			if (this.User.Identity.IsAuthenticated)
				return Redirect("/");
			return View();
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult SignIn(string Username, string Password)
		{
			var user_tried = (Account) Account.CheckLogin(Username, Password);
			if (user_tried != null) {
				Session.Add("current_user", user_tried.Id);
				FormsAuthentication.SetAuthCookie(user_tried.UserName, true);
				string return_url = this.Url.RequestContext.HttpContext.Request.QueryString["ReturnUrl"];

				if ( return_url != null && return_url.Trim() != String.Empty)
				{
					return Redirect(return_url);
				}
				return RedirectToAction("Index", "Home");
			} else {
				return View();
			}
		}

		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult SignOut()
		{
			Session.Remove("current_user");
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home");
		}

		~SessionsController() { Initializer.CloseSession(); }
	}
}

