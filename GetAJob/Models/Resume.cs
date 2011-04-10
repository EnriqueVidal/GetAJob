using System;
using System.ComponentModel.DataAnnotations;

namespace GetAJob.Models
{
	public class Resume : EntityBase
	{
		public virtual string LastEmployer { get; set; }

		[Required(ErrorMessage="The body of your resume is essential to complete this step.")]
		public virtual string Content { get; set; }
		
		public virtual Person Person { get; set; }
		
		public Resume () { }
	}
}

