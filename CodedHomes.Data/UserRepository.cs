using System.Data.Entity;
using CodedHomes.Models;

namespace CodedHomes.Data
{
	public class UserRepository : GenericRepository<User>
	{
		public UserRepository(DbContext context)
			: base(context)
		{ }
	}
}
