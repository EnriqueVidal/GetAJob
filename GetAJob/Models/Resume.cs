using System;

namespace GetAJob.Models
{
	public class Resume : EntityBase
	{
		public virtual string LastEmployer { get; set; }
		public virtual string Content { get; set; }
		
		public virtual Person Person { get; set; }
		
		public Resume () { }
	}
}

