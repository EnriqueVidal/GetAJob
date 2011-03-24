using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace GetAJob
{
    public static class Initializer
    {
		private static ISessionFactory session;
		private static Configuration config;
		public static ISessionFactory Session { get { return session; } }
		
        public static ISessionFactory OpenSession()
        {
			if ( session == null ) {
				config = new Configuration();
				config.Configure();
				config.AddAssembly(Assembly.GetCallingAssembly());
				session = config.BuildSessionFactory();
			}

            return session;
        }
		
		public static void SchemaExport()
		{
			SchemaExport se = new SchemaExport(config);
			se.Execute(true, true, false);
		}
		
		public static void CloseSession()
		{
			session.Close();
			session.Dispose();
		}
    }
}
