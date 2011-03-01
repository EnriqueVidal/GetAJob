using System;
using System.Net;

namespace GetAJob.Persistence.Entities
{
	public partial class Resume
	{
		public virtual int Id { get; private set; }
		public virtual string LastEmployer { get; set; }
		public virtual string Content { get; set; }
		
		public virtual Person Person { get; set; }
		
		public Resume () { }
	}
}

