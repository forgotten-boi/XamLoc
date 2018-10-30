using System;
using System.IO;
using FirstProj.Droid;
using SQLite;
using Xamarin.Forms;
using Java.IO;

using FirstProj;
using FirstProj.Helper;

[assembly: Dependency(typeof(SQLiteDb))]

namespace FirstProj.Droid
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            //var dbFile = new Java.IO.File(System.IO.Path.Combine(System.Environment.GetFolderPath‌​(Syst‌​em.Environmen‌​t.Speci‌​alFolder.Pe‌​rsonal), "MySQLite.db3"));
            //var dbFile = new Java.IO.File(path);

            //Java.IO.File sdCard = Android.OS.Environment.ExternalStorageDirectory;
            //Java.IO.File dir = new Java.IO.File(sdCard.AbsoluteFile + "/" + "MyFolder");
            //dir.Mkdir();

            //var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            //var filePath = Path.Combine(dir.AbsolutePath, "mypath");



            //System.IO.File.Copy(dbFile.AbsolutePath, filePath);


            // Automatically uses the implementation you defined in your platform project.
            var fileAccessHelper = DependencyService.Get<IFileAccessHelper>();
            var dbFileName = "DatabaseFilename.db3";

            // In my code, the repository class creates the SQLite datbase and schema in the ctor using SQLiteAsyncConnection.
            //Repository yourSQliteRepository = new Repository(fileAccessHelper.GetLocalFilePath(dbFileName));

            // Now that the file is created, we can do a backup copy.
            //var dbBackupFileName = $"DatabaseBackup{DateTime.Today.ToString("DD-MMM-YYYY")}.db3";
            //fileAccessHelper.CopyFile(path, dbBackupFileName, true);

            //var fileExists = fileAccessHelper.DoesFileExist(dbBackupFileName);



            return new SQLiteAsyncConnection(path);
        }


    }
}

