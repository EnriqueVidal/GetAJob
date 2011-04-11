using System;
using System.ComponentModel.DataAnnotations;

namespace GetAJob.Models
{
	/// <summary>
    /// Represent a person
    /// </summary>
	public class Person : EntityBase
	{
		[Required(ErrorMessage = "Firstname is Required")]
		public virtual String FirstName { get; set; }

		[Required(ErrorMessage = "Lastname is Required")]
		public virtual String LastName { get; set; }

		public virtual Resume Resume { get; set; }
		public virtual User User { get; set; }

		public Person () { }

		public string FullName {
			get { return string.Format("{0} {1}", this.FirstName, this.LastName); }
		}
	}
}
