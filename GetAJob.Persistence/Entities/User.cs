using System;
using System.Net;

namespace GetAJob.Persistence.Entities
{
    /// <summary>
    /// Represent a user
    /// </summary>
    public partial class User
    {
		public virtual int Id { get; private set; }
		public virtual string Username { get; set; }
		public virtual string Email { get; set; }
		public virtual string PasswordHash { get; set; }
		public virtual string Salt { get; set; }
		
		public virtual Person Person { get; set; }
		
		public User() { }
    }
}

