using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
namespace MillageCalc
{
	public class MillageDb
	{
		public static MillageDb db;
		private SQLiteAsyncConnection connection;
		public MillageDb(SQLiteAsyncConnection connection)
		{
			this.connection = connection;
		}

		public static MillageDb GetDB(SQLiteAsyncConnection connection)
		{
			if (db == null)
			{
				db = new MillageDb(connection);
			}
			return db;
		}

		public Task<int> SaveAsync(MillageRd millageRd)
		{
			if (millageRd.Id > 0)
			{
				return this.connection.UpdateAsync(millageRd);
			}
			else
			{
				return this.connection.InsertAsync(millageRd);
			}
		}

		public Task<List<MillageRd>> GetListAsync()
		{
			return this.connection.Table<MillageRd>().ToListAsync();
		}
	}
}
