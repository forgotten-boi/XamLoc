using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Essentials;
using System.Threading.Tasks;
using System.IO;

namespace Xamarin.Essentials
{
    public partial class FileSystem
    {
        public static string PlatformCacheDirectory
            => Xamarin.Essentials.FileSystem.PlatformCacheDirectory;

        public static string PlatformAppDataDirectory
            => Xamarin.Essentials.FileSystem.PlatformAppDataDirectory;

        public static Task<Stream> PlatformOpenAppPackageFileAsync(string filename)
        {
            if (filename == null)
                throw new ArgumentNullException(nameof(filename));

            filename = filename.Replace('\\', Path.DirectorySeparatorChar);
            try
            {
                return Xamarin.Essentials.FileSystem.PlatformOpenAppPackageFileAsync(filename);
            }
            catch (Java.IO.FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message, filename, ex);
            }
        }
    }
}