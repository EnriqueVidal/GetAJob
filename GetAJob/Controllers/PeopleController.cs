using System;
using System.Web.Mvc;
using NHibernate;
using GetAJob.Core;
using GetAJob.Models;
using Account = GetAJob.Models.User;

namespace GetAJob.Controllers
{
	[HandleError]
	public class PeopleController : Controller
	{
		private Current Current = GetAJob.Current.Instance;
		private Account user;

		[AcceptVerbs(HttpVerbs.Get)]
		[RequiresAuthentication]
		public ActionResult Edit()
		{
			this.Current.UserId = (int)Session["current_user"];
			this.user = this.Current.User();

			if ( this.user.Person == null )
				return RedirectToAction("Index", "Home");

			return View(this.user.Person);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		[RequiresAuthentication]
		[ValidateInput(false)]
		public ActionResult Edit(Person new_person)
		{
			var person_factory = new Repository<Person>();
			person_factory.Update(new_person);
			return View();
		}

		~PeopleController() { Initializer.CloseSession(); }
	}
}
