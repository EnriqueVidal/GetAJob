using System;
using System.Web;
using System.Web.Services;
using GetAJob.Core;
using GetAJob.Models;
using System.Collections.Generic;
using NHibernate.Criterion;

namespace GetAJob.WebService
{
	[WebService(Namespace = "http://www.getajob.org/", Description = "Get A Job WebService")]
	public class Service : System.Web.Services.WebService
	{
		public Service() { Initializer.OpenSession(); }

		[WebMethod]
		public List<JobOffer> getOffers(int page_index, int per_page) {
			var job_offers_repo = new Repository<JobOffer>();
			return (List<JobOffer>)job_offers_repo.GetRange(per_page, page_index, new Order("Id", false));
		}

		[WebMethod]
		public List<Person> getPeople(int page_index, int per_page) {
			var people_repo = new Repository<Person>();
			return (List<Person>)people_repo.GetRange(per_page, page_index, new Order("Id", false));
		}

		~Service() { Initializer.CloseSession(); }
	}
}
