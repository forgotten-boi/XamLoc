using System;
using System.IO;
using FirstProj.iOS;
using SQLite;
using Xamarin.Forms;


[assembly: Dependency(typeof(SQLiteDb))]

namespace FirstProj.iOS
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}

