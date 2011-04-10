using System;
using System.Web.Mvc;

namespace GetAJob
{
	public class ResumesController : Controller
	{
		GetAJob.Current Current = GetAJob.Current.Instance;
		
		[AcceptVerbs(HttpVerbs.Get)]
		[RequiresAuthentication]
		public ActionResult New() {
			this.Current.UserId = (int)Session["user_id"];
			if ( this.Current.User().Person.Resume != null )
				return RedirectToAction("Index", "Home");

			return View();
		}
	}
}

