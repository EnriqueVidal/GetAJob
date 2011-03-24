using System;

namespace GetAJob.Models
{
	/// <summary>
    /// Represent a person
    /// </summary>
	public class Person : EntityBase
	{
		public virtual String FirstName { get; set; }
		public virtual String LastName { get; set; }

		public virtual Resume Resume { get; set; }
		public virtual User User { get; set; }

		public Person () { }
	}
}