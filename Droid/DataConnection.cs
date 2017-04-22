using System;
using System.IO;
using SQLite;
namespace MillageCalc.Droid
{
	public class DataConnection
	{
		static SQLiteAsyncConnection dataConnection;

		public static SQLiteAsyncConnection GetConnection()
		{
			if (dataConnection == null)
			{
				string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db.db");
				dataConnection = new SQLiteAsyncConnection(path);
			}
			return dataConnection;
		}
	}
}
