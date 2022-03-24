using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SearchAlgorithm;

namespace FolderCrawler
{
    public partial class JendelaUtama : Form
    {
        List<LinkLabel> pathDestination = new List<LinkLabel>();
        Microsoft.Msagl.GraphViewerGdi.GViewer viewer;
        BFS b;
        DFS d;

        public JendelaUtama()
        {
            InitializeComponent();
            viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            viewer.Size = new System.Drawing.Size(700, 270);
            viewer.Location = new System.Drawing.Point(250, 34);
            this.Controls.Add(viewer);
        }

        private void myLink_Clicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            var a = (LinkLabel)sender;
            a.LinkVisited = true;
            System.Diagnostics.Process.Start(a.Text);
        }

        private void InitialInput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fld = new FolderBrowserDialog();
            if (fld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InitialDirectoryInput.Text = fld.SelectedPath;
            }
        }

        private LinkLabel pathToLinkLabel(string path)
        {
            LinkLabel r = new LinkLabel();
            r.Text = path;
            r.LinkClicked += myLink_Clicked;
            return r;
        }

        private void generateLinks(GraphSearch g)
        {
            pathDestination.Clear();
            foreach (string path in g.getFoundPath())
            {
                LinkLabel l = pathToLinkLabel(path);
                l.Location = new Point(39, 270 + pathDestination.Count * 25);
                l.AutoSize = true;
                pathDestination.Add(l);
                this.Controls.Add(pathDestination.ElementAt(pathDestination.Count - 1));
            }
        }

        private void clearLinks()
        {
            for (int i = 0; i < pathDestination.Count; i++)
            {
                this.Controls.Remove(pathDestination.ElementAt(i));
            }
        }

        private void runWorker(BackgroundWorker w)
        {
            if (w.IsBusy != true)
            {
                w.RunWorkerAsync();
            }
        }

        private void generateTimeSpent(GraphSearch g)
        {
            TimeSpent.Text = "Time Spent: " + (g.originalTimeSpentTicks / 10000) + " ms";
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (BFS.Checked)
                {
                    runWorker(BFSVisualWorker);

                }
                else if (DFS.Checked)
                {
                    runWorker(DFSVisualWorker);
                }

            }
            catch (Exception)
            {

            }
        }

        private void JendelaUtama_Load(object sender, EventArgs e)
        {

        }

        private void BFSVisualWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            b = new BFS(InitialDirectoryInput.Text, DestinationInput.Text);
            BackgroundWorker worker = sender as BackgroundWorker;
            bool isBFSAll = AllOccurence.Checked;
            bool isBFSFirst = !AllOccurence.Checked;

            if (isBFSAll)
            {
                b.crawlAnimate(Mode.All, ShowAllVertices.Checked, worker);
            }
            else if (isBFSFirst)
            {
                b.crawlAnimate(Mode.First, ShowAllVertices.Checked, worker);
            }

            e.Result = b;
        }

        private void BFSVisualWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            viewer.Graph = b.getGraph().getGraph();
        }

        private void DFSVisualWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            d = new DFS(InitialDirectoryInput.Text, DestinationInput.Text);
            BackgroundWorker worker = sender as BackgroundWorker;
            bool isDFSAll = AllOccurence.Checked;
            bool isDFSFirst = !AllOccurence.Checked;
            if (isDFSAll)
            {
                d.crawlAnimate(Mode.All, ShowAllVertices.Checked , worker);
            }
            else if (isDFSFirst)
            {
                d.crawlAnimate(Mode.First, ShowAllVertices.Checked, worker);
            }

            e.Result = d;
        }

        private void DFSVisualWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            viewer.Graph = d.getGraph().getGraph();
        }

        private void VisualWorkers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            clearLinks();
            generateLinks((GraphSearch) e.Result);
            generateTimeSpent((GraphSearch)e.Result);
        }




        private void ShowAllVertices_CheckStateChanged(object sender, EventArgs e)
        {
            if (AllOccurence.Checked)
            {
                ShowAllVertices.CheckState = CheckState.Indeterminate;
                ShowAllVertices.Checked = true;
            }
        }

        private void AllOccurence_CheckStateChanged(object sender, EventArgs e)
        {
            if (AllOccurence.CheckState == CheckState.Checked)
            {
                ShowAllVertices.Checked = true;
                ShowAllVertices.CheckState = CheckState.Checked;
                AllOccurence.Checked = true;
            } else if (AllOccurence.CheckState == CheckState.Unchecked)
            {
                ShowAllVertices.Checked = false;
                ShowAllVertices.CheckState = CheckState.Unchecked;
                AllOccurence.Checked = false;
            }
        }
    }
}
