namespace FolderCrawler
{
    partial class JendelaUtama
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JendelaUtama));
            this.InitialDirectoryInput = new System.Windows.Forms.Button();
            this.DestinationInput = new System.Windows.Forms.TextBox();
            this.LabelInitialInput = new System.Windows.Forms.Label();
            this.LabelDestination = new System.Windows.Forms.Label();
            this.BFS = new System.Windows.Forms.RadioButton();
            this.DFS = new System.Windows.Forms.RadioButton();
            this.FindButton = new System.Windows.Forms.Button();
            this.AllOccurence = new System.Windows.Forms.CheckBox();
            this.LabelLinkList = new System.Windows.Forms.Label();
            this.BFSVisualWorker = new System.ComponentModel.BackgroundWorker();
            this.DFSVisualWorker = new System.ComponentModel.BackgroundWorker();
            this.TimeSpent = new System.Windows.Forms.Label();
            this.ShowAllVertices = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InitialDirectoryInput
            // 
            this.InitialDirectoryInput.BackColor = System.Drawing.Color.Transparent;
            this.InitialDirectoryInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InitialDirectoryInput.ForeColor = System.Drawing.SystemColors.ControlText;
            this.InitialDirectoryInput.Location = new System.Drawing.Point(42, 67);
            this.InitialDirectoryInput.Name = "InitialDirectoryInput";
            this.InitialDirectoryInput.Size = new System.Drawing.Size(233, 39);
            this.InitialDirectoryInput.TabIndex = 0;
            this.InitialDirectoryInput.Text = "Pilih Direktori...";
            this.InitialDirectoryInput.UseVisualStyleBackColor = false;
            this.InitialDirectoryInput.Click += new System.EventHandler(this.InitialInput_Click);
            // 
            // DestinationInput
            // 
            this.DestinationInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DestinationInput.Location = new System.Drawing.Point(42, 156);
            this.DestinationInput.Name = "DestinationInput";
            this.DestinationInput.Size = new System.Drawing.Size(294, 28);
            this.DestinationInput.TabIndex = 1;
            // 
            // LabelInitialInput
            // 
            this.LabelInitialInput.AutoSize = true;
            this.LabelInitialInput.BackColor = System.Drawing.Color.Transparent;
            this.LabelInitialInput.Font = new System.Drawing.Font("Jokerman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInitialInput.Location = new System.Drawing.Point(39, 39);
            this.LabelInitialInput.Name = "LabelInitialInput";
            this.LabelInitialInput.Size = new System.Drawing.Size(179, 25);
            this.LabelInitialInput.TabIndex = 2;
            this.LabelInitialInput.Text = "Pilih Direktori Awal";
            // 
            // LabelDestination
            // 
            this.LabelDestination.AutoSize = true;
            this.LabelDestination.BackColor = System.Drawing.Color.Transparent;
            this.LabelDestination.Font = new System.Drawing.Font("Jokerman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDestination.Location = new System.Drawing.Point(41, 127);
            this.LabelDestination.Name = "LabelDestination";
            this.LabelDestination.Size = new System.Drawing.Size(92, 26);
            this.LabelDestination.TabIndex = 3;
            this.LabelDestination.Text = "Destinasi";
            // 
            // BFS
            // 
            this.BFS.AutoSize = true;
            this.BFS.BackColor = System.Drawing.Color.Transparent;
            this.BFS.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BFS.Location = new System.Drawing.Point(40, 299);
            this.BFS.Name = "BFS";
            this.BFS.Size = new System.Drawing.Size(76, 31);
            this.BFS.TabIndex = 5;
            this.BFS.TabStop = true;
            this.BFS.Text = "BFS";
            this.BFS.UseVisualStyleBackColor = false;
            // 
            // DFS
            // 
            this.DFS.AutoSize = true;
            this.DFS.BackColor = System.Drawing.Color.Transparent;
            this.DFS.Font = new System.Drawing.Font("Papyrus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DFS.Location = new System.Drawing.Point(40, 330);
            this.DFS.Name = "DFS";
            this.DFS.Size = new System.Drawing.Size(89, 35);
            this.DFS.TabIndex = 6;
            this.DFS.TabStop = true;
            this.DFS.Text = "DFS";
            this.DFS.UseVisualStyleBackColor = false;
            // 
            // FindButton
            // 
            this.FindButton.BackColor = System.Drawing.Color.Transparent;
            this.FindButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindButton.Location = new System.Drawing.Point(135, 299);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(181, 66);
            this.FindButton.TabIndex = 7;
            this.FindButton.Text = "Cari";
            this.FindButton.UseVisualStyleBackColor = false;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // AllOccurence
            // 
            this.AllOccurence.AutoSize = true;
            this.AllOccurence.BackColor = System.Drawing.Color.Transparent;
            this.AllOccurence.Font = new System.Drawing.Font("Kristen ITC", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllOccurence.Location = new System.Drawing.Point(46, 213);
            this.AllOccurence.Name = "AllOccurence";
            this.AllOccurence.Size = new System.Drawing.Size(300, 28);
            this.AllOccurence.TabIndex = 10;
            this.AllOccurence.Text = "Temukan Semua Kemungkinan";
            this.AllOccurence.UseVisualStyleBackColor = false;
            this.AllOccurence.CheckStateChanged += new System.EventHandler(this.AllOccurence_CheckStateChanged);
            // 
            // LabelLinkList
            // 
            this.LabelLinkList.AutoSize = true;
            this.LabelLinkList.BackColor = System.Drawing.Color.Transparent;
            this.LabelLinkList.Font = new System.Drawing.Font("ROG Fonts", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelLinkList.Location = new System.Drawing.Point(37, 396);
            this.LabelLinkList.Name = "LabelLinkList";
            this.LabelLinkList.Size = new System.Drawing.Size(247, 24);
            this.LabelLinkList.TabIndex = 11;
            this.LabelLinkList.Text = "Hasil Pencarian: ";
            // 
            // BFSVisualWorker
            // 
            this.BFSVisualWorker.WorkerReportsProgress = true;
            this.BFSVisualWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BFSVisualWorker_DoWork);
            this.BFSVisualWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BFSVisualWorker_ProgressChanged);
            this.BFSVisualWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.VisualWorkers_RunWorkerCompleted);
            // 
            // DFSVisualWorker
            // 
            this.DFSVisualWorker.WorkerReportsProgress = true;
            this.DFSVisualWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DFSVisualWorker_DoWork);
            this.DFSVisualWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.DFSVisualWorker_ProgressChanged);
            this.DFSVisualWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.VisualWorkers_RunWorkerCompleted);
            // 
            // TimeSpent
            // 
            this.TimeSpent.AutoSize = true;
            this.TimeSpent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeSpent.Location = new System.Drawing.Point(467, 67);
            this.TimeSpent.Name = "TimeSpent";
            this.TimeSpent.Size = new System.Drawing.Size(0, 20);
            this.TimeSpent.TabIndex = 12;
            // 
            // ShowAllVertices
            // 
            this.ShowAllVertices.AutoSize = true;
            this.ShowAllVertices.BackColor = System.Drawing.Color.Transparent;
            this.ShowAllVertices.Font = new System.Drawing.Font("Kristen ITC", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowAllVertices.Location = new System.Drawing.Point(46, 240);
            this.ShowAllVertices.Name = "ShowAllVertices";
            this.ShowAllVertices.Size = new System.Drawing.Size(260, 28);
            this.ShowAllVertices.TabIndex = 13;
            this.ShowAllVertices.Text = "Tampilkan Seluruh Simpul";
            this.ShowAllVertices.UseVisualStyleBackColor = false;
            this.ShowAllVertices.CheckStateChanged += new System.EventHandler(this.ShowAllVertices_CheckStateChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(37, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 0);
            this.label1.TabIndex = 14;
            // 
            // JendelaUtama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FolderCrawler.Properties.Resources._8b29a9bebeee7decf57af4124a7c4047;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShowAllVertices);
            this.Controls.Add(this.TimeSpent);
            this.Controls.Add(this.LabelLinkList);
            this.Controls.Add(this.AllOccurence);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.DFS);
            this.Controls.Add(this.BFS);
            this.Controls.Add(this.LabelDestination);
            this.Controls.Add(this.LabelInitialInput);
            this.Controls.Add(this.DestinationInput);
            this.Controls.Add(this.InitialDirectoryInput);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JendelaUtama";
            this.Text = "FILE EXPLORER";
            this.Load += new System.EventHandler(this.JendelaUtama_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button InitialDirectoryInput;
        private System.Windows.Forms.TextBox DestinationInput;
        private System.Windows.Forms.Label LabelInitialInput;
        private System.Windows.Forms.Label LabelDestination;
        private System.Windows.Forms.RadioButton BFS;
        private System.Windows.Forms.RadioButton DFS;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.CheckBox AllOccurence;
        private System.Windows.Forms.Label LabelLinkList;
        private System.ComponentModel.BackgroundWorker BFSVisualWorker;
        private System.ComponentModel.BackgroundWorker DFSVisualWorker;
        private System.Windows.Forms.Label TimeSpent;
        private System.Windows.Forms.CheckBox ShowAllVertices;
        private System.Windows.Forms.Label label1;
    }
}

