using System;
using System.Web.Mvc;
using System.Web.Security;
using GetAJob.Core;
using NHibernate;
using Account = GetAJob.Models.User;
using System.Web;

namespace GetAJob.Controllers
{
	[HandleError]
	public class RegistrationsController : Controller
	{
		IRepository<Account> user;

		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult SignUp()
		{
			if (this.User.Identity.IsAuthenticated)
				return Redirect("/");
			return View();
		}

		[AcceptVerbs(HttpVerbs.Post)]
		[ValidateInput(false)]
		public ActionResult SignUp([Bind(Exclude = "Id")] Account new_user) {
			if (ModelState.IsValid)
			{
				try {
					this.user = new Repository<Account>();
					this.user.Add(new_user);
					Session.Add("current_user", new_user.Id);
					FormsAuthentication.SetAuthCookie(new_user.UserName, true);
					return RedirectToAction("Index", "Home");
				} catch {
					ViewData["ApplicationException"] = "There has been an error and we are aware of it, please try again later.";
					return View(new_user);
				}
			}
			return View(new_user);
		}

		~RegistrationsController() { Initializer.CloseSession(); }
	}
}
