using System;
using Castle.Core.Internal;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.ByteCode.Castle;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using MySql;
using MySql.Data.MySqlClient;
using GetAJob.Persistence.Entities;

namespace GetAJob.Windsor
{
	public class PersistenceFacility : AbstractFacility
	{
		protected override void Init ()
		{
			var config = BuildDatabaseConfiguration();
			
			Kernel.Register(
			                Component.For<ISessionFactory>().UsingFactoryMethod(config.BuildSessionFactory),
			                Component.For<ISession>()
			                .UsingFactoryMethod( k => k.Resolve<ISessionFactory>().OpenSession())
			                .LifeStyle.PerWebRequest
			                );
		}
		
		private Configuration BuildDatabaseConfiguration ()
		{
			return Fluently.Configure()
				.Database(SetupDatabase)
				.Mappings(m => m.AutoMappings.Add(CreateMappingModel()))
				.ExposeConfiguration(ConfigurePersistence)
				.BuildConfiguration();
		}
		
		protected virtual AutoPersistenceModel CreateMappingModel()
		{
			AutoPersistenceModel m = AutoMap.Assembly(typeof (EntityBase).Assembly)
				.Where(IsDomainEntity)
				.IgnoreBase<EntityBase>();
			
			return m;
		}
		
		protected virtual IPersistenceConfigurer SetupDatabase()
		{
			return MySQLConfiguration.Standard
				.ConnectionString( c => c.Database("get_a_job").Server("localhost").Username("get_a_job").Password("development"))
				.ShowSql();
		}
		
		protected virtual bool IsDomainEntity(Type t)
		{
			return typeof (EntityBase).IsAssignableFrom(t);
		}
		
		public virtual void ConfigurePersistence(Configuration config)
		{
			SchemaMetadataUpdater.QuoteTableAndColumns(config);
		}
	}
}