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
        public JendelaUtama()
        {
            InitializeComponent();
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
                Microsoft.Msagl.GraphViewerGdi.GraphRenderer renderer = new Microsoft.Msagl.GraphViewerGdi.GraphRenderer(lala.getGraph().getGraph());
                renderer.CalculateLayout();
                int width = 500;
                Bitmap bitmap = new Bitmap(width, (int)(lala.getGraph().getGraph().Height * (width / lala.getGraph().getGraph().Width)), System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                renderer.Render(bitmap);

                pictureBox1.Image = bitmap;
                List<LinkLabel> pathDestination = new List<LinkLabel>();
                foreach(string path in lala.getFoundPath())
                {
                    pathDestination.Add(new LinkLabel());
                    pathDestination.ElementAt(pathDestination.Count-1).Text = path;
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
                Microsoft.Msagl.GraphViewerGdi.GraphRenderer renderer = new Microsoft.Msagl.GraphViewerGdi.GraphRenderer(lalala.getGraph().getGraph());
                renderer.CalculateLayout();
                int width = 500;
                Bitmap bitmap = new Bitmap(width, (int)(lalala.getGraph().getGraph().Height * (width / lalala.getGraph().getGraph().Width)), System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                renderer.Render(bitmap);

                pictureBox1.Image = bitmap;
                List<LinkLabel> pathDestination = new List<LinkLabel>();
                foreach (string path in lalala.getFoundPath())
                {
                    pathDestination.Add(new LinkLabel());
                    pathDestination.ElementAt(pathDestination.Count - 1).Text = path;
                    pathDestination.ElementAt(pathDestination.Count - 1).Location = new System.Drawing.Point(39, 250 + pathDestination.Count * 25);
                    pathDestination.ElementAt(pathDestination.Count - 1).LinkClicked += myLink_Clicked;
                    this.Controls.Add(pathDestination.ElementAt(pathDestination.Count - 1));
                }
            }
            

        }
    }
}
