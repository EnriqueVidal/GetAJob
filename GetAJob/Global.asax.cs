using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GetAJob;

namespace GetAJob
{
	public class MvcApplication : System.Web.HttpApplication
	{
		private void Application_BeginRequest(object sender, EventArgs e)
		{
			Initializer.OpenSession();
		}

		public static void RegisterRoutes (RouteCollection routes)
		{
			routes.IgnoreRoute ("{resource}.axd/{*pathInfo}");

			routes.MapRoute ("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = "" });

		}

		protected void Application_Start ()
		{
			RegisterRoutes (RouteTable.Routes);
		}

		private void Application_EndRequest(object sender, EventArgs e)
		{
			//Initializer.CloseSession();
		}
	}
}

