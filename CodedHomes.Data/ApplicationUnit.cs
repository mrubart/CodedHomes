using System;
using CodedHomes.Models;

namespace CodedHomes.Data
{
	public class ApplicationUnit:IDisposable
	{
		private DataContext _context = new DataContext();

		private IRepository<Home> _homes = null;
		private IRepository<User> _users = null;

		public IRepository<Home> Homes
		{
			get
			{
				if (this._homes == null)
				{
					this._homes = new GenericRepository<Home>(this._context);
				}
				return this._homes;
			}
		}

		public IRepository<User> Users
		{
			get
			{
				if (this._users == null)
				{
					this._users = new GenericRepository<User>(this._context);
				}
				return this._users;
			}
		}

		public void SaveChanges()
		{
			this._context.SaveChanges();
		}

		public void Dispose()
		{
			if (this._context != null)
			{
				this._context.Dispose();
			}
		}
	}

}
