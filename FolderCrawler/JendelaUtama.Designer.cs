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
            this.SuspendLayout();
            // 
            // InitialDirectoryInput
            // 
            this.InitialDirectoryInput.ForeColor = System.Drawing.SystemColors.ControlText;
            this.InitialDirectoryInput.Location = new System.Drawing.Point(41, 58);
            this.InitialDirectoryInput.Name = "InitialDirectoryInput";
            this.InitialDirectoryInput.Size = new System.Drawing.Size(171, 23);
            this.InitialDirectoryInput.TabIndex = 0;
            this.InitialDirectoryInput.Text = "Pilih Direktori...";
            this.InitialDirectoryInput.UseVisualStyleBackColor = true;
            this.InitialDirectoryInput.Click += new System.EventHandler(this.InitialInput_Click);
            // 
            // DestinationInput
            // 
            this.DestinationInput.Location = new System.Drawing.Point(41, 119);
            this.DestinationInput.Name = "DestinationInput";
            this.DestinationInput.Size = new System.Drawing.Size(171, 22);
            this.DestinationInput.TabIndex = 1;
            // 
            // LabelInitialInput
            // 
            this.LabelInitialInput.AutoSize = true;
            this.LabelInitialInput.Location = new System.Drawing.Point(39, 39);
            this.LabelInitialInput.Name = "LabelInitialInput";
            this.LabelInitialInput.Size = new System.Drawing.Size(124, 17);
            this.LabelInitialInput.TabIndex = 2;
            this.LabelInitialInput.Text = "Pilih Direktori Awal";
            // 
            // LabelDestination
            // 
            this.LabelDestination.AutoSize = true;
            this.LabelDestination.Location = new System.Drawing.Point(39, 100);
            this.LabelDestination.Name = "LabelDestination";
            this.LabelDestination.Size = new System.Drawing.Size(66, 17);
            this.LabelDestination.TabIndex = 3;
            this.LabelDestination.Text = "Destinasi";
            // 
            // BFS
            // 
            this.BFS.AutoSize = true;
            this.BFS.Location = new System.Drawing.Point(40, 230);
            this.BFS.Name = "BFS";
            this.BFS.Size = new System.Drawing.Size(55, 21);
            this.BFS.TabIndex = 5;
            this.BFS.TabStop = true;
            this.BFS.Text = "BFS";
            this.BFS.UseVisualStyleBackColor = true;
            // 
            // DFS
            // 
            this.DFS.AutoSize = true;
            this.DFS.Location = new System.Drawing.Point(40, 256);
            this.DFS.Name = "DFS";
            this.DFS.Size = new System.Drawing.Size(56, 21);
            this.DFS.TabIndex = 6;
            this.DFS.TabStop = true;
            this.DFS.Text = "DFS";
            this.DFS.UseVisualStyleBackColor = true;
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(102, 231);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(132, 46);
            this.FindButton.TabIndex = 7;
            this.FindButton.Text = "Cari";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // AllOccurence
            // 
            this.AllOccurence.AutoSize = true;
            this.AllOccurence.Location = new System.Drawing.Point(42, 156);
            this.AllOccurence.Name = "AllOccurence";
            this.AllOccurence.Size = new System.Drawing.Size(227, 21);
            this.AllOccurence.TabIndex = 10;
            this.AllOccurence.Text = "Temukan Semua Kemungkinan";
            this.AllOccurence.UseVisualStyleBackColor = true;
            this.AllOccurence.CheckStateChanged += new System.EventHandler(this.AllOccurence_CheckStateChanged);
            // 
            // LabelLinkList
            // 
            this.LabelLinkList.AutoSize = true;
            this.LabelLinkList.Location = new System.Drawing.Point(39, 312);
            this.LabelLinkList.Name = "LabelLinkList";
            this.LabelLinkList.Size = new System.Drawing.Size(115, 17);
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
            this.TimeSpent.Location = new System.Drawing.Point(386, 339);
            this.TimeSpent.Name = "TimeSpent";
            this.TimeSpent.Size = new System.Drawing.Size(0, 17);
            this.TimeSpent.TabIndex = 12;
            // 
            // ShowAllVertices
            // 
            this.ShowAllVertices.AutoSize = true;
            this.ShowAllVertices.Location = new System.Drawing.Point(42, 183);
            this.ShowAllVertices.Name = "ShowAllVertices";
            this.ShowAllVertices.Size = new System.Drawing.Size(194, 21);
            this.ShowAllVertices.TabIndex = 13;
            this.ShowAllVertices.Text = "Tampilkan Seluruh Simpul";
            this.ShowAllVertices.UseVisualStyleBackColor = true;
            this.ShowAllVertices.CheckStateChanged += new System.EventHandler(this.ShowAllVertices_CheckStateChanged);
            // 
            // JendelaUtama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 522);
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
            this.Name = "JendelaUtama";
            this.Text = "Form1";
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
    }
}

