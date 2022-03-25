using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SearchAlgorithm;

namespace FolderCrawler
{
    public partial class JendelaUtama : Form
    {
        List<LinkLabel> pathDestination = new List<LinkLabel>();
        Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
        BFS b;
        DFS d;
        bool isBFSAll, isBFSFirst, isDFSAll, isDFSFirst;

        public JendelaUtama()
        {
            InitializeComponent();
            viewer.Size = new System.Drawing.Size(400, 270);
            viewer.Location = new System.Drawing.Point(250, 34);
            this.Controls.Add(viewer);
        }

        private void myLink_Clicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            var a = (LinkLabel)sender;
            a.LinkVisited = true;
            System.Diagnostics.Process.Start(a.Text);
        }

        private void make_Hyperlink(BFS bfs, DFS dfs)
        //Make link label or hyperlink to all path to destination
        {
            List<string> pathFound = new List<string>();
            if (BFS.Checked)
            {
                pathFound = bfs.getFoundPath();
            }
            else if (DFS.Checked)
            {
                pathFound = dfs.getFoundPath();
            }
            foreach (string path in pathFound)
            {
                string[] array = path.Split('\\');
                string parentPath = "";
                for (int i = 0; i < array.Length - 2; i++)
                {
                    parentPath += array[i] + "\\";
                }
                parentPath += array[array.Length - 2];
                pathDestination.Add(new LinkLabel());
                pathDestination.ElementAt(pathDestination.Count - 1).Text = parentPath;
                pathDestination.ElementAt(pathDestination.Count - 1).Location = new System.Drawing.Point(39, 250 + pathDestination.Count * 25);
                pathDestination.ElementAt(pathDestination.Count - 1).LinkClicked += myLink_Clicked;
                this.Controls.Add(pathDestination.ElementAt(pathDestination.Count - 1));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fld = new FolderBrowserDialog();
            if(fld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                button1.Text = fld.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            b = new BFS(button1.Text, textBox1.Text);
            d = new DFS(button1.Text, textBox1.Text);
            isBFSAll = AllOccurence.Checked && BFS.Checked;
            isBFSFirst = !AllOccurence.Checked && BFS.Checked;
            isDFSAll = AllOccurence.Checked && DFS.Checked;
            isDFSFirst = !AllOccurence.Checked && DFS.Checked;
            if (isBFSAll)
            {
                b.crawl(Mode.All);
            }
            else if (isBFSFirst)
            {
                b.crawl(Mode.First);
            }
            else if (isDFSAll)
            {
                d.crawl(Mode.All);
            }
            else if (isDFSFirst)
            {
                d.crawl(Mode.First);
            }
            this.make_Hyperlink(b, d);
            stopwatch.Stop();
            label5.Text = "Time Spent: " + stopwatch.Elapsed.Seconds + "." + stopwatch.Elapsed.Milliseconds;

            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (isBFSAll)
            {
                b.crawlAnimate(Mode.All, worker);
            }
            else if (isBFSFirst)
            {
                b.crawlAnimate(Mode.First, worker);
            } else if (isDFSAll)
            {
                d.crawlAnimate(Mode.All, worker);
            } else if (isDFSFirst)
            {
                d.crawlAnimate(Mode.First, worker);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (BFS.Checked)
            {
                viewer.Graph = b.getGraph().getGraph();
            } else if (DFS.Checked)
            {
                viewer.Graph = d.getGraph().getGraph();
            }
        }
    }
}
