using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.IO;

namespace FirstProj.Models
{
    public partial class FileSystem
    {
        public static string CacheDirectory
             =>  Xamarin.Essentials.FileSystem.CacheDirectory;

        public static string AppDataDirectory
            => Xamarin.Essentials.FileSystem.AppDataDirectory;

        public static Task<Stream> OpenAppPackageFileAsync(string filename)
            => Xamarin.Essentials.FileSystem.OpenAppPackageFileAsync(filename);
    }
}
