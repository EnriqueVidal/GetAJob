using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace GetAJob.Persistence
{
    public static class Initializer
    {
		public static ISessionFactory session;
		public static Configuration config;

		public static ISessionFactory Session { get { return session; } }
		
        public static ISessionFactory OpenSession()
        {
			if ( session == null ) {
				config = new Configuration();
				config.Configure();
				config.AddAssembly("GetAJob.Persistence");
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
