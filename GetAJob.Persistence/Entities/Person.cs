using System;

namespace GetAJob.Persistence.Entities
{
	/// <summary>
    /// Represent a person
    /// </summary>
	public partial class Person
	{
		
		public virtual int Id { get; private set; }
		public virtual String FirstName { get; set; }
		public virtual String LastName { get; set; }
		
		public virtual Resume Resume { get; set; }
		public virtual User User { get; set; }
		
		public Person () { }
	}
}