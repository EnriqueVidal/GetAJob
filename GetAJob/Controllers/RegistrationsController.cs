using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

using GetAJob.Persistence.Entities;

namespace GetAJob.Controllers
{
	[HandleError]
	public class RegistrationsController : Controller
	{
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult SignUp()
		{
           if (this.User.Identity.IsAuthenticated)
                return Redirect("/");
			return View();
		}
	}
}