using GetAJob.Persistence.Entities;

namespace GetAJob.Persistence.Entities
{
	public partial class Resume : EntityBase
	{
		public virtual string LastEmployer { get; set; }
		public virtual string Content { get; set; }
		
		public virtual Person Person { get; set; }
	}
}