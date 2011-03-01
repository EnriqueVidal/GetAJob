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
        public static ISessionFactory GetSessionFactory(bool isNeedRecreateScheme)
        {
            Configuration config = new Configuration();
            config.Configure();
            config.AddAssembly("GetAJob.Persistence");

            if (isNeedRecreateScheme)
            {
                SchemaExport se = new SchemaExport(config);
                se.Execute(true, true, false);
            }

            return config.BuildSessionFactory();
        }
    }
}
