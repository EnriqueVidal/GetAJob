using System;
using System.Web.Mvc;
using NHibernate;
using GetAJob.Core;
using Account = GetAJob.Models.User;

namespace GetAJob
{
	/// <summary>
	/// Represent an Object of Current objects set by instance values
	/// </summary>
	public class Current
	{
		private static Current self_instance;
		private Account user;
		private int user_id;
		
		public int UserId {
			set { this.user_id = value; }
		}
		
		public static Current Instance
		{
			get {
				if ( self_instance == null ) {
					self_instance = new Current();
				}
				return self_instance;
			}
		}
		
		private Current () { }
		
		public Account User()
		{
			if ( user != null )
				return user;

			var user_repository = new Repository<Account>();
			user =  user_repository.Find(this.user_id);
			return user;
		}
	}
}