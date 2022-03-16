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
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Graph graf = new Graph();
            graf.AddEdges("A", "B");
            graf.AddEdges("A", "C");
            Microsoft.Msagl.GraphViewerGdi.GraphRenderer renderer = new Microsoft.Msagl.GraphViewerGdi.GraphRenderer(graf.getGraph());
            renderer.CalculateLayout();
            int width = 150;
            Bitmap bitmap = new Bitmap(width, (int)(graf.getGraph().Height * (width / graf.getGraph().Width)), System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            renderer.Render(bitmap);

            pictureBox1.Image = bitmap;
        }
    }
}
