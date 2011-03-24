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
			if (new_user.UserName == null || new_user.UserName.Trim() == String.Empty)
	        {
	            ModelState.AddModelError("Username", "Username is required.");
	        }

	        if (new_user.Email == null || ! new_user.EmailIsValid()) {
	            ModelState.AddModelError("Email", "Email is required in proper format.");
	        }

	        if (new_user.Password == null || new_user.Password.Trim() == String.Empty || new_user.Password.Length < 6)
	        {
	            ModelState.AddModelError("Password", "Password is required, with minimum length of 6.");
	        }

	        if (!ModelState.IsValid)
	            return View();
			try
			{
				this.user = new Repository<Account>(this.session_factory);
	            new_user.PrepareForSave();
				this.user.Add(new_user);

	            Session.Add("current_user", new_user.Id);
	            FormsAuthentication.SetAuthCookie(new_user.UserName, true);
	            return RedirectToAction("SignIn");
	        }
			catch
			{
	            return View();
			}
		}
	}
}