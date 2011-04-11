using System;
using System.Web.Mvc;
using NHibernate;
using GetAJob.Core;
using GetAJob.Models;
using Account = GetAJob.Models.User;
using NHibernate.Criterion;

namespace GetAJob.Controllers
{
	[HandleError]
	public class PeopleController : Controller
	{
		private Current Current = GetAJob.Current.Instance;
		private Account user;
		private int per_page = 5;

		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Index(int page)
		{
			var people_repo = new Repository<Person>();
			var people = people_repo.GetRange(this.per_page, page, new Order("Id", false));
			return View(people);
		}

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
			if (ModelState.IsValid) {
				var person_factory = new Repository<Person>();
				person_factory.Update(new_person);
			}

			return View();
		}

		~PeopleController() { Initializer.CloseSession(); }
	}
}
