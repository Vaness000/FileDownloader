using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderEngine
{
    public class ConfigManager
    {
        public static int PortionsAmount
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["portionsAmount"]);
            }
        }

        public static int MaxDownloads
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["maxDownloads"]);
            }
        }
    }
}
