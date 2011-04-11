using System;
using System.Web.Mvc;
using GetAJob.Core;
using GetAJob.Models;
using NHibernate.Criterion;
using System.Collections.Generic;
using System.Web.Routing;

namespace GetAJob.Controllers
{
	[HandleError]
	public class JobOffersController : Controller
	{	
		private int per_page = 5;
		
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Index(int page)
		{
			var job_offer_repo = new Repository<JobOffer>();
			var offers = job_offer_repo.GetRange(this.per_page, page, new Order("Id", false));
		 	return View(offers);
		}
		
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult New()
		{
			return View();
		}
		
		[AcceptVerbs(HttpVerbs.Post)]
		[ValidateInput(false)]
		public ActionResult New([Bind(Exclude="Id")] JobOffer new_job_offer)
		{
			var job_offer_repo = new Repository<JobOffer>();
			if (ModelState.IsValid)
			{
				try {
					job_offer_repo.Add(new_job_offer);
					return Redirect("/JobOffers?page=1");
				} catch {
					return View(new_job_offer);
				}
			}
			
			return View(new_job_offer);
		}
	}
}

