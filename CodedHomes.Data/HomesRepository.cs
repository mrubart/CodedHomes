using System.Data.Entity;
using CodedHomes.Models;

namespace CodedHomes.Data
{
	public class HomesRepository:GenericRepository<Home>
	{
		public HomesRepository(DbContext context) : base(context)
		{}
	}
}
