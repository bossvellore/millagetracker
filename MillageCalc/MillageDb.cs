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
            connection.CreateTableAsync<MillageRd>();
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
        public void CreateTable()
        {
            this.connection.CreateTableAsync<MillageRd>();
        }
		public Task<int> SaveAsync(MillageRd millageRd)
		{
            millageRd.ComputeMillage();
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
            try
            {
                return this.connection.Table<MillageRd>().OrderByDescending(xx => xx.Id).ToListAsync();
            }
            catch(Exception ex)
            {
                var a = ex;

            }
            return this.connection.Table<MillageRd>().OrderByDescending(xx => xx.Id).ToListAsync();
        }

        public Task<MillageRd> Find(int id)
        {
            return this.connection.GetAsync<MillageRd>(id);
        }
        public Task<int> Delete(MillageRd item)
        {
            return this.connection.DeleteAsync(item);
        }
	}
}
