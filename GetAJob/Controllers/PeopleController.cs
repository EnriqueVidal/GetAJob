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
		private IRepository<Person> person_factory;
		private Account user;

		[AcceptVerbs(HttpVerbs.Get)]
		[RequiresAuthentication]
		public ActionResult New()
		{
			this.Current.UserId = (int)Session["current_user"];
			this.user = this.Current.User();

			if ( this.user.Person != null )
				return RedirectToAction("Edit");
			return View();
		}

		[AcceptVerbs(HttpVerbs.Post)]
		[RequiresAuthentication]
		public ActionResult New([Bind(Exclude="Id")] Person new_person)
		{
			try
			{
				this.Current.UserId = (int)Session["current_user"];
				this.user = this.Current.User();
				this.person_factory = new Repository<Person>();
				new_person.User = this.user;
				this.person_factory.Add(new_person);

				return RedirectToAction("Edit");
			} catch {
				ViewData["ApplicationException"] = "There has been an error, please try again later.";
			}

			return View();
		}

		[AcceptVerbs(HttpVerbs.Get)]
		[RequiresAuthentication]
		public ActionResult Edit()
		{
			this.Current.UserId = (int)Session["current_user"];
			this.user = this.Current.User();

			if ( this.user.Person == null )
				return RedirectToAction("New");

			return View(this.user.Person);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		[RequiresAuthentication]
		public ActionResult Edit(Person new_person)
		{
			return View();
		}

		~PeopleController() { Initializer.CloseSession(); }
	}
}

