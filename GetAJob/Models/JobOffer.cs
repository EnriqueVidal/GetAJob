using System;
using System.ComponentModel.DataAnnotations;

namespace GetAJob.Models
{
	public class JobOffer : EntityBase
	{
		[Required(ErrorMessage="The company name is a mandatory attribute.")]
		[RegularExpression("[\\S]{3,}", ErrorMessage = "Must be at least 3 characters.")]
		public virtual string Company { get; set; }
		
		[Required(ErrorMessage="The job description is essential to complete this step.")]
		[RegularExpression("[\\S]{3,}", ErrorMessage = "Must be at least 3 characters.")]
		public virtual string JobDescription { get; set; }
		
		[RegularExpression(@"^([\w\.%\+\-]+)@([\w\-]+\.)+([\w]{2,})$", ErrorMessage = "Not valid Email")]
		public virtual string Contact { get; set; }
		
		[Required(ErrorMessage="Job Title is mandatory to submit a Job Offer")]
		[RegularExpression("[\\S]{4,}", ErrorMessage = "Must be at least 4 characters.")]
		public virtual string JobTitle { get; set; }
	}
}

