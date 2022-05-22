using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderEngine
{
    public enum DownloadPortions
    {
        Small = 1024 * 8,
        Middle = 1024 * 512,
        Large = 1024 * 1024
    }
}
