using System;
using System.Collections.Generic;
using System.Text;

namespace FirstProj.Helper
{
        public interface IFileAccessHelper
        {
            string GetLocalFilePath(string fileName);
            void CopyFile(string sourceFilename, string destinationFilename, bool overwrite);
            bool DoesFileExist(string fileName);
        }
    
}
