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
                /*var debug=Android.OS.Environment.DataDirectory.AbsolutePath;
                var debug1 = Android.OS.Environment.DirectoryDocuments;
                var debug2 = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);
                var debug3 = Android.OS.Environment.ExternalStorageDirectory;
                var debug5 = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
                debug = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var debug4 = Android.OS.Environment.DataDirectory;
                */
                var location = Android.OS.Environment.GetExternalStoragePublicDirectory("Android/data/com.sad.millagecalc/files");
                //location = Android.OS.Environment.DataDirectory;
                if(location.Exists() == false)
                {
                    System.IO.DirectoryInfo fi = System.IO.Directory.CreateDirectory(location.AbsolutePath);
                }
                string path = Path.Combine(location.AbsolutePath, "millage.db");
				dataConnection = new SQLiteAsyncConnection(path);
			}
			return dataConnection;
		}
	}
}
