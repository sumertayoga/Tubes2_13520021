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
    public enum Mode
    {
        First,
        All
    }
    
    public class BFS
    {
         
        private string initial;
        private string destination;
        
        string[] visited;
        Mode mode;
        string[] temp2;
        Queue<string> q;
        List<string> foundPath;
        Graph graf;
        bool found;

        public Graph getGraph()
        {
            return graf;
        }

        public BFS(string initialDirectory, string destination)
        {
            mode = Mode.First;
            this.initial = initialDirectory;
            this.destination = destination;
            this.q = new Queue<string>();
        }

        private string endPath(string path)
        {
            string[] temp = path.Split('\\');
            return temp[temp.Length - 1];
        }

        private string parent(string path)
        {
            string[] temp = path.Split('\\');
            string parent = "";
            foreach (string t in temp.Take(temp.Length - 2))
            {
                parent += t + '\\';
            }
            return parent + temp[temp.Length - 2];
        }

        private void access(string node)
        { 
            graf.AddNode(node);
            if (node != initial)
            {
                graf.AddEdgesAccessed(parent(node), node);
            }

            Console.WriteLine(node);

            visited.Append(node);

            evaluate(node);
            // if it is subdir, enqueue

        }
        private void enqueueAllChild(string path)
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
                for (int i = 0; i < childs.Length; i++)
                {
                    node = childs[i];
                    if (!visited.Contains(node))
                    {
                        
                            q.Enqueue(node);
                        
                    }
                }
            }
            catch (Exception e)
            {
                return;
            }
            


        }

        private void coloring(string path)
        {
            graf.ChangeBlue(parent(path), path);
            if (path != initial)
            {
                coloring(parent(path));
            }
            
        }

        private void evaluate(string path)
        {
            string end = endPath(path);
            if (mode == Mode.First && end == destination)
            {
                foundPath.Add(path);
                found = true;
            }
            else if (end == destination)
            {
                foundPath.Add(path);
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
            q = new Queue<string>();

            q.Enqueue(initial);
            string path;
            while (q.Count != 0 && !found)
            {
                path = q.Dequeue();
                access(path);
                enqueueAllChild(path);
            }

            foreach (string f in foundPath)
            {
                coloring(f);
            }

        }

        
    }
}
