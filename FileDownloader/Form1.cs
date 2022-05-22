using DownloaderEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileDownloader
{
    //links
    //https://download.virtualbox.org/virtualbox/6.1.26/VirtualBox-6.1.26-145957-Win.exe
    //http://dl.google.com/chrome/install/1500.95/chrome_installer.exe
    //
    public partial class MainForm : Form
    {
        private bool cleared = false;
        private const int statusColumn = 1;
        private const int progressColumn = 3;
        private DownloadersModel model = new DownloadersModel();

        public MainForm()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            InitializeComponent();
            downloadBtn.Enabled = false;
            DoubleBuffered = true;
            CreateColumns();
            UpdateStatus();
        }

        private void CreateColumns()
        {
            DataGridViewTextBoxColumn fileNameColumn = new DataGridViewTextBoxColumn();
            fileNameColumn.HeaderText = "File";
            DataGridViewProgressBarColumn progressColumn = new DataGridViewProgressBarColumn();
            progressColumn.HeaderText = "Progress";
            DataGridViewTextBoxColumn fileSizeColumn = new DataGridViewTextBoxColumn();
            fileSizeColumn.HeaderText = "File Size";
            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.HeaderText = "Status";
            DataGridViewTextBoxColumn urlColumn = new DataGridViewTextBoxColumn();
            urlColumn.HeaderText = "Url";
            dataGridView1.Columns.Add(fileNameColumn);
            dataGridView1.Columns.Add(statusColumn);
            dataGridView1.Columns.Add(fileSizeColumn);
            dataGridView1.Columns.Add(progressColumn);
            dataGridView1.Columns.Add(urlColumn);
        }

        private void AddRow(Downloader downloader)
        {
            DataGridViewTextBoxCell fileNameCell = new DataGridViewTextBoxCell();
            fileNameCell.Value = downloader.FileName;
            DataGridViewTextBoxCell statusCell = new DataGridViewTextBoxCell();
            statusCell.Value = downloader.DownloadStatus;
            DataGridViewTextBoxCell fileSizeCell = new DataGridViewTextBoxCell();
            fileSizeCell.Value = downloader.FileSizeInfo;
            DataGridViewTextBoxCell urlCell = new DataGridViewTextBoxCell();
            urlCell.Value = downloader.Url;
            DataGridViewProgressBarCell progressCell = new DataGridViewProgressBarCell();
            DataGridViewRow row = new DataGridViewRow();
            row.Cells.Add(fileNameCell);
            row.Cells.Add(statusCell);
            row.Cells.Add(fileSizeCell);
            row.Cells.Add(progressCell);
            row.Cells.Add(urlCell);
            dataGridView1.Rows.Add(row);
        }

        private void GetFileName()
        {
            if (cleared)
            {
                cleared = false;
                return;
            }

            if (!string.IsNullOrEmpty(urlTB.Text) && Uri.TryCreate(urlTB.Text, UriKind.Absolute, out Uri uri))
            {
                fileNameTB.Text = Path.GetFileName(uri.LocalPath);
                downloadBtn.Enabled = true;
            }
            else
            {
                MessageBox.Show("It is not a file");
                downloadBtn.Enabled = false;
            }

            cleared = false;
        }

        private void UpdateStatus()
        {
            totalStatusLabel.Text = model.TotalStatusText;
            inProgressStatusLabel.Text = model.InProgressStatusText;
            inQueueStatusLabel.Text = model.InQueueStatusText;
            completedStatusLabel.Text = model.CompletedStatusText;
            errorStatusLabel.Text = model.WithErrorsStatusText;
        }

        private void urlTB_TextChanged(object sender, EventArgs e)
        {
            GetFileName();
        }

        private void urlTB_Click(object sender, EventArgs e)
        {
            urlTB.SelectAll();
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            DownloadFile();
        }

        private void DownloadFile()
        {
            CreateDownloaderAndDownload();
            ClearFields();
        }

        private void ClearFields()
        {
            cleared = true;
            urlTB.Clear();
            fileNameTB.Clear();
            downloadBtn.Enabled = false;
        }

        private void CreateDownloaderAndDownload()
        {
            Downloader downloader = null;
            try
            {
                downloader = model.CreateDownloaderAndDownload(urlTB.Text, fileNameTB.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            Subscribe(downloader);
            AddRow(downloader);
            UpdateStatus();

            try
            {
                downloader.Download();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            UpdateStatus();
        }

        private void Subscribe(Downloader downloader)
        {
            downloader.OnProgressChanged += Downloader_OnProgressChanged;
            downloader.OnDownloadComplete += Downloader_OnDownloadComplete;
            downloader.OnDownloadStart += Downloader_OnDownloadStart;
        }

        private void Downloader_OnDownloadStart(object sender, EventArgs e)
        {
            UpdateDownloaderInfo(sender, statusColumn);
        }

        private void Downloader_OnDownloadComplete(object sender, EventArgs e)
        {
            UpdateDownloaderInfo(sender, statusColumn);
        }

        private void Downloader_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Downloader downloader = sender as Downloader;
            int index = model.Downloaders.IndexOf(downloader);
            DataGridViewProgressBarCell cell = dataGridView1.Rows[index].Cells[progressColumn] as DataGridViewProgressBarCell;
            cell.Progress = e.ProgressPercentage;
            Invoke((MethodInvoker)delegate
            {
                dataGridView1.InvalidateCell(progressColumn, index);
                UpdateStatus();
            });
        }

        private void UpdateDownloaderInfo(object sender, int column)
        {
            Downloader downloader = sender as Downloader;
            int index = model.Downloaders.IndexOf(downloader);
            UpdateCurrentCell(column, index, downloader.DownloadStatus);
        }

        private void UpdateCurrentCell(int column, int row, object value)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    dataGridView1.Rows[row].Cells[column].Value = value;
                    UpdateStatus();
                });
            }
            else
            {
                dataGridView1.InvalidateCell(column, row);
                UpdateStatus();
            }
        }
    }
}
