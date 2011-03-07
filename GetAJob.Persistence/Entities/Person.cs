using GetAJob.Persistence.Entities;

namespace GetAJob.Persistence.Entities
{
	/// <summary>
    /// Represent a person
    /// </summary>
	public partial class Person : EntityBase
	{
		public virtual string FirstName { get; set; }
		public virtual string LastName { get; set; }
		
		public virtual Resume Resume { get; set; }
		public virtual User User { get; set; }
	}
}