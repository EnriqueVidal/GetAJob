using System;
using System.Web.Mvc;
using System.Web.Security;
using GetAJob.Core;
using NHibernate;
using Account = GetAJob.Models.User;

namespace GetAJob.Controllers
{
	[HandleError]
	public class RegistrationsController : Controller
	{
		IRepository<Account> user;
		ISessionFactory session_factory = Initializer.Session;

		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult SignUp()
		{
           if (this.User.Identity.IsAuthenticated)
                return Redirect("/");
			return View();
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult SignUp([Bind(Exclude = "Id")] Account new_user) {
			if (ModelState.IsValid)
			{
				try {
					this.user = new Repository<Account>(this.session_factory);
					this.user.Add(new_user);
	
		            Session.Add("current_user", new_user.Id);
		            FormsAuthentication.SetAuthCookie(new_user.UserName, true);
		            return RedirectToAction("SignIn");
		        } catch(Exception e) {
					System.Console.WriteLine(e.Message);
		            return View();
				}
			} else {
				return View(new_user);
			}
		}
	}
}