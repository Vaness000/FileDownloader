using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderEngine
{
    public class FileInfoManager
    {
        private const int killobyte = 1024;
        private const int megabyte = 1024 * 1024;
        private const int gigabyte = 1024 * 1024 * 1024;

        public static string GetFileNameInDirectory(string fullPathToFile)
        {
            int i = 1;
            string result = fullPathToFile;
            while (File.Exists(result))
            {
                string name = Path.GetFileNameWithoutExtension(fullPathToFile);
                result = fullPathToFile.Replace(name, string.Format("{0}({1})", name, i));
                i++;
            }

            return result;
        }

        public static int GetFileSize(Uri uri)
        {
            WebRequest webRequest = WebRequest.Create(uri);
            webRequest.Method = "HEAD";
            try
            {
                using (var webResponse = webRequest.GetResponse())
                {
                    string contentLength = webResponse.Headers.Get("Content-Length");
                    return Convert.ToInt32(contentLength);
                }
            }
            catch
            {
                return 0;
            }
            
        }

        public static string CreateSizeInfo(int fileSize)
        {
            string sizeFormat = "{0:f2} {1}b";
            if (fileSize < killobyte)
            {
                return string.Format(sizeFormat, fileSize, string.Empty);
            }

            if (fileSize < megabyte)
            {
                return string.Format(sizeFormat, ((double)fileSize / 1024), "K");
            }

            if (fileSize < gigabyte)
            {
                return string.Format(sizeFormat, (double)fileSize / 1024 / 1024, "M");
            }

            return string.Format(sizeFormat, (double)fileSize / 1024 / 1024 / 1024, "G");
        }

        public static string GetFileName(Uri uri)
        {
            return Path.GetFileName(uri.LocalPath);
        }
    }
}
