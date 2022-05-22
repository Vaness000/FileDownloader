
namespace FileDownloader
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.urlTB = new System.Windows.Forms.TextBox();
            this.downloadBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fileNameTB = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.totalStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.completedStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.inProgressStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.inQueueStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.downloaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downloaderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Url:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "File Name:";
            // 
            // urlTB
            // 
            this.urlTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.urlTB.Location = new System.Drawing.Point(76, 19);
            this.urlTB.Name = "urlTB";
            this.urlTB.Size = new System.Drawing.Size(557, 20);
            this.urlTB.TabIndex = 2;
            this.urlTB.Click += new System.EventHandler(this.urlTB_Click);
            this.urlTB.TextChanged += new System.EventHandler(this.urlTB_TextChanged);
            // 
            // downloadBtn
            // 
            this.downloadBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.downloadBtn.Location = new System.Drawing.Point(650, 19);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(106, 55);
            this.downloadBtn.TabIndex = 4;
            this.downloadBtn.Text = "Download";
            this.downloadBtn.UseVisualStyleBackColor = true;
            this.downloadBtn.Click += new System.EventHandler(this.downloadBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.fileNameTB);
            this.groupBox1.Controls.Add(this.urlTB);
            this.groupBox1.Controls.Add(this.downloadBtn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 90);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // fileNameTB
            // 
            this.fileNameTB.Location = new System.Drawing.Point(76, 50);
            this.fileNameTB.Name = "fileNameTB";
            this.fileNameTB.Size = new System.Drawing.Size(557, 20);
            this.fileNameTB.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totalStatusLabel,
            this.completedStatusLabel,
            this.inProgressStatusLabel,
            this.inQueueStatusLabel,
            this.errorStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // totalStatusLabel
            // 
            this.totalStatusLabel.Name = "totalStatusLabel";
            this.totalStatusLabel.Size = new System.Drawing.Size(35, 17);
            this.totalStatusLabel.Text = "Total:";
            // 
            // completedStatusLabel
            // 
            this.completedStatusLabel.Name = "completedStatusLabel";
            this.completedStatusLabel.Size = new System.Drawing.Size(62, 17);
            this.completedStatusLabel.Text = "Comleted:";
            // 
            // inProgressStatusLabel
            // 
            this.inProgressStatusLabel.Name = "inProgressStatusLabel";
            this.inProgressStatusLabel.Size = new System.Drawing.Size(65, 17);
            this.inProgressStatusLabel.Text = "InProgress:";
            // 
            // inQueueStatusLabel
            // 
            this.inQueueStatusLabel.Name = "inQueueStatusLabel";
            this.inQueueStatusLabel.Size = new System.Drawing.Size(58, 17);
            this.inQueueStatusLabel.Text = "In Queue:";
            // 
            // errorStatusLabel
            // 
            this.errorStatusLabel.Name = "errorStatusLabel";
            this.errorStatusLabel.Size = new System.Drawing.Size(118, 17);
            this.errorStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // downloaderBindingSource
            // 
            this.downloaderBindingSource.DataSource = typeof(DownloaderEngine.Downloader);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 108);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(775, 316);
            this.dataGridView1.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "MainForm";
            this.Text = "Downloader";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downloaderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button downloadBtn;
        private System.Windows.Forms.TextBox urlTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel totalStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel completedStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel inProgressStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel inQueueStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel errorStatusLabel;
        private System.Windows.Forms.BindingSource downloaderBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox fileNameTB;
    }
}

