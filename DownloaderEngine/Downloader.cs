using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DownloaderEngine
{
    public class Downloader
    {
        
        private Uri uri;
        private string fileSizeInfo;
        private int fileSize;
        private string fileName;
        private int totalReaded;

        private int portionLength
        {
            get
            {
                return fileSize / ConfigManager.PortionsAmount;
            }
        }

        public event EventHandler<ProgressChangedEventArgs> OnProgressChanged;
        public event EventHandler OnDownloadComplete;
        public event EventHandler OnDownloadStart;

        public Task DownloadFileTask;
        public string FileName 
        { 
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        public string FileSizeInfo
        {
            get
            {
                return fileSizeInfo;
            }
        }

        public DownloadStatus DownloadStatus { get; private set; } = DownloadStatus.InQueue;
        
        public int FileSize
        {
            get
            {
                return fileSize;
            }
        }

        public int Progress { get; private set; } = 0;
        public string Url
        {
            get
            {
                return uri.OriginalString;
            }
        }

        private Downloader(Uri uri, string fileName)
        {
            this.uri = uri;
            fileSize = FileInfoManager.GetFileSize(uri);
            if(fileSize == 0)
            {
                DownloadStatus = DownloadStatus.Error;
            }

            fileSizeInfo = FileInfoManager.CreateSizeInfo(fileSize);
            this.fileName = fileName;
        }

        public static Downloader CreateDownloader(string url, string fileName)
        {
            if(Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out Uri uri))
            {
                Downloader downloader = new Downloader(uri, fileName);
                if(downloader.DownloadStatus == DownloadStatus.Error)
                {
                    throw new InvalidOperationException("Connection not established");
                }

                return downloader;
            }
            else
            {
                throw new ArgumentException("It is not a file", nameof(url));
            }
        }

        private async void DownloadFile()
        {
            HttpClient client = new HttpClient();
            try
            {
                using (var response = await client.GetAsync(uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        using (var downloadStream = await response.Content.ReadAsStreamAsync())
                        {
                            string pathToFile = FileInfoManager.GetFileNameInDirectory(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%/downloads/"), FileName));
                            using (Stream saveStream = new FileStream(pathToFile, FileMode.Create, FileAccess.Write))
                            {
                                Task[] downloadPortionTasks = new Task[ConfigManager.PortionsAmount];
                                for(int i = 0; i < downloadPortionTasks.Length; i++)
                                {
                                    downloadPortionTasks[i] = SavePortionAsync(downloadStream, saveStream, i);
                                }
                                
                                Task.WaitAll(downloadPortionTasks);
                                //int current = 0;
                                //int total = 0;
                                //byte[] buffer = new byte[(int)DownloadPortions.Small];

                                //DownloadStatus = DownloadStatus.InProgress;
                                //DownloadStarted(this, new EventArgs());
                                //try
                                //{
                                //    while ((current = downloadStream.Read(buffer, 0, buffer.Length)) > 0)
                                //    {
                                //        saveStream.Write(buffer, 0, current);
                                //        total += current;
                                //        Progress = Convert.ToInt32(((double)total / (double)fileSize) * 100);
                                //        ProgressChanged(this, new ProgressChangedEventArgs(Progress, null));
                                //    }
                                //}
                                //catch
                                //{
                                //    OnError();
                                //    throw;
                                //}
                            }
                        }
                    }
                }
            }
            catch
            {
                OnError();
                throw;
            }

            DownloadStatus = DownloadStatus.Completed;
            DownloadComleted(this, new EventArgs());
        }

        private async Task SavePortionAsync(Stream downloadStream, Stream saveStream, int currentIndex)
        {
            int offset = currentIndex * portionLength;
            int bytesLeft = (int)downloadStream.Length - offset;
            int currentLength = Math.Min(portionLength, bytesLeft);

            byte[] buffer = new byte[currentLength];
            downloadStream.Position = offset;
            int readedBytes = 0;
            try
            {
                readedBytes = await downloadStream.ReadAsync(buffer, 0, currentLength);
            }
            catch
            {
                throw;
            }

            totalReaded += readedBytes;
            saveStream.Position = offset;
            await saveStream.WriteAsync(buffer, 0, currentLength);

            Progress = Convert.ToInt32(((double)totalReaded / (double)fileSize) * 100);
            ProgressChanged(this, new ProgressChangedEventArgs(Progress, null));
        }

        private void OnError()
        {
            Progress = 0;
            DownloadStatus = DownloadStatus.Error;
            DownloadComleted(this, new EventArgs());
        }

        public void Download()
        {
            DownloadFileTask = new Task(DownloadFile);
            DownloadFileTask.Start();
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            OnProgressChanged(sender, e);
        }

        private void DownloadComleted(object sender, EventArgs e)
        {
            OnDownloadComplete(sender, e);
        }

        private void DownloadStarted(object sender, EventArgs e)
        {
            OnDownloadStart(sender, e);
        }
    }
}
