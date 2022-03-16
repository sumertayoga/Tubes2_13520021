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
            BFS lala = new BFS(button1.Text, textBox1.Text);
            lala.crawl(Mode.First);
            Microsoft.Msagl.GraphViewerGdi.GraphRenderer renderer = new Microsoft.Msagl.GraphViewerGdi.GraphRenderer(lala.getGraph().getGraph());
            renderer.CalculateLayout();
            int width = 500;
            Bitmap bitmap = new Bitmap(width, (int)(lala.getGraph().getGraph().Height * (width / lala.getGraph().getGraph().Width)), System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            renderer.Render(bitmap);

            pictureBox1.Image = bitmap;
        }
    }
}
