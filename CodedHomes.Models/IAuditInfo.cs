using System;

namespace CodedHomes.Models
{
	public interface IAuditInfo
	{
		DateTime CreatedOn { get; set; }
		DateTime ModifiedOn { get; set; }
	}
}
