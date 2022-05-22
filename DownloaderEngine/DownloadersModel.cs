using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderEngine
{
    public class DownloadersModel
    {
        private const string totalFormat = "Total: {0}";
        private const string inProgresFormat = "In Progress: {0}";
        private const string inQueueFormat = "In Queue: {0}";
        private const string completedFormat = "Completed: {0}  ({1})";
        private const string errorsFormat = "With Errors: {0}";

        private List<Downloader> downloaders;

        private string totalLength
        {
            get
            {
                int length = downloaders.Where(x => x.DownloadStatus == DownloadStatus.Completed).Sum(x => x.FileSize);
                return FileInfoManager.CreateSizeInfo(length);
            }
        }
        private int total
        {
            get
            {
                return downloaders.Count;
            }
        }

        private int inProgres
        {
            get
            {
                return downloaders.Count(x => x.DownloadStatus == DownloadStatus.InProgress);
            }
        }

        private int inQueue
        {
            get
            {
                return downloaders.Count(x => x.DownloadStatus == DownloadStatus.InQueue);
            }
        }

        private int completed
        {
            get
            {
                return downloaders.Count(x => x.DownloadStatus == DownloadStatus.Completed);
            }
        }

        private int withErrors
        {
            get
            {
                return downloaders.Count(x => x.DownloadStatus == DownloadStatus.Error);
            }
        }

        public string TotalStatusText 
        {
            get
            {
                return string.Format(totalFormat, total);
            }
        }

        public string InProgressStatusText
        {
            get
            {
                return string.Format(inProgresFormat, inProgres);
            }
        }

        public string InQueueStatusText
        {
            get
            {
                return string.Format(inQueueFormat, inQueue);
            }
        }

        public string CompletedStatusText
        {
            get
            {
                return string.Format(completedFormat, completed, totalLength);
            }
        }

        public string WithErrorsStatusText
        {
            get
            {
                return string.Format(errorsFormat, withErrors);
            }
        }

        public List<Downloader> Downloaders
        {
            get
            {
                return downloaders;
            }
        } 

        public DownloadersModel()
        {
            downloaders = new List<Downloader>();
        }

        public Downloader CreateDownloaderAndDownload(string url, string fileName)
        {
            try
            {
                Downloader downloader = Downloader.CreateDownloader(url, fileName);
                downloaders.Add(downloader);
                return downloader;
            }
            catch
            {
                throw;
            }
        }

        public void Download(Downloader downloader)
        {
            if(downloaders.Where(x => x.DownloadStatus == DownloadStatus.InProgress).Count() > ConfigManager.MaxDownloads)
            {
                Task.WaitAll(downloaders.Where(x => x.DownloadStatus == DownloadStatus.InProgress).Select(x => x.DownloadFileTask).ToArray());
            }

            downloader.Download();
        }
    }
}
