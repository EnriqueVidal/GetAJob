using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using GetAJob.Windsor;

namespace GetAJob
{
	public class MvcApplication : System.Web.HttpApplication
	{	
		private static IWindsorContainer container;
		
		private static void BootstrapContainer()
		{
			container = new WindsorContainer().Install(FromAssembly.This());
			var controller_factory = new WindsorControllerFactory(container.Kernel);
			ControllerBuilder.Current.SetControllerFactory(controller_factory);
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
		
		protected void Application_End()
		{
			container.Dispose();
		}
	}
}

