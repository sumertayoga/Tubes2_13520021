using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Msagl.Drawing;

namespace SearchAlgorithm
{
    public class DFS : GraphSearch
    {
        Stack<string> stack;
        public DFS(string initial, string destination) : base (initial, destination)
        {
        }

        private void pushAllChild(string path)
        {
            try
            {
                string[] subdirectories = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);
                string[] childs = new string[subdirectories.Length + files.Length];
                subdirectories.CopyTo(childs, 0);
                files.CopyTo(childs, subdirectories.Length);


                // loop childs
                string node;
                int i = 0;
                while (i >= 0)
                {
                    node = childs[i];
                    if (!visited.Contains(node))
                    {
                        stack.Push(node);
                    }
                    i--;
                }
                
            }
            catch (Exception e)
            {
                return;
            }

        }

        public void crawl(Mode m)
        {
            //inisialisasi
            mode = m;
            found = false;
            graf = new Graph();
            foundPath = new List<string>();
            visited = new string[] { };
            stack = new Stack<string>();

            stack.Push(initial);
            string path;
            while (stack.Count > 0 && !found)
            {
                path = stack.Pop();
                access(path);
                pushAllChild(path);
            }

            foreach (string f in foundPath)
            {
                graf.ChangeNodeBlue(f);
                coloring(f);
            }

        }  
    }
}
