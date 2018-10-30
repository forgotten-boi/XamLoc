using FirstProj.Droid;
using FirstProj.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileAccessHelper))]
namespace FirstProj.Droid
{
        public  class FileAccessHelper : IFileAccessHelper
        {
            public string GetLocalFilePath(string filename)
            {
                // Storing the database here is a best practice.
                string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                return System.IO.Path.Combine(path, filename);
            }

            public void CopyFile(string sourceFilename, string destinationFilename, bool overwrite)
            {
                var sourcePath = GetLocalFilePath(sourceFilename);
                var destinationPath = GetLocalFilePath(destinationFilename);

                System.IO.File.Copy(sourcePath, destinationPath, overwrite);
            }

            public bool DoesFileExist(string filename)
            {
                var fullPath = GetLocalFilePath(filename);
                return System.IO.File.Exists(fullPath);
            }

           


        }
    
}

