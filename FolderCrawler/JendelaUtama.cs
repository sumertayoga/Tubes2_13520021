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
        
        public JendelaUtama()
        {
            InitializeComponent();
            viewer.Size = new System.Drawing.Size(370, 270);
            viewer.Location = new System.Drawing.Point(250, 34);
            this.Controls.Add(viewer);
        }

        private void myLink_Clicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            var a = (LinkLabel)sender;
            a.LinkVisited = true;
            System.Diagnostics.Process.Start(a.Text);
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
            BFS lala = new BFS(button1.Text, textBox1.Text);
            DFS lalala = new DFS(button1.Text, textBox1.Text);
            if (BFS.Checked)
            {
                if (AllOccurence.Checked)
                {
                    lala.crawl(Mode.All);
                }
                else
                {
                    lala.crawl(Mode.First);
                }
                viewer.Graph = lala.getGraph().getGraph();
                for (int i = 0; i < pathDestination.Count; i++)
                {
                    this.Controls.Remove(pathDestination.ElementAt(i));
                }

                pathDestination = new List<LinkLabel>();
                foreach(string path in lala.getFoundPath())
                {
                    string[] array = path.Split('\\');
                    string parentPath = "";
                    for (int i=0; i<array.Length-2;i++)
                    {
                        parentPath += array[i] + "\\";
                    }
                    parentPath += array[array.Length-2];
                    pathDestination.Add(new LinkLabel());
                    pathDestination.ElementAt(pathDestination.Count-1).Text = parentPath;
                    pathDestination.ElementAt(pathDestination.Count-1).Location = new System.Drawing.Point(39, 250+pathDestination.Count*25);
                    pathDestination.ElementAt(pathDestination.Count - 1).LinkClicked += myLink_Clicked;
                    this.Controls.Add(pathDestination.ElementAt(pathDestination.Count - 1));

                }
            }
            else if (DFS.Checked)
            {
                if (AllOccurence.Checked)
                {
                    lalala.crawl(Mode.All);
                }
                else
                {
                    lalala.crawl(Mode.First);
                }
                viewer.Graph = lalala.getGraph().getGraph();
                List<LinkLabel> pathDestination = new List<LinkLabel>();
                foreach (string path in lalala.getFoundPath())
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

            stopwatch.Stop();
            label5.Text = "Time Spent: " + stopwatch.Elapsed.Seconds + "." + stopwatch.Elapsed.Milliseconds;
        }
    }
}
