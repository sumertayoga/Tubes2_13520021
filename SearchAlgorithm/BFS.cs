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
    
    /* 
     PROBLEM
        1. The next level of found node is still accessed
            Solution: use function to determine the level of the node --> not beautiful but working
     */
    public class BFS
    {
         
        private string initial;
        private string destination;
        
        string[] visited;
        Mode mode;
        Queue<string> q;
        List<string> foundPath;
        Graph graf;
        bool found;

        public Graph getGraph()
        {
            return graf;
        }

        public List<string> getFoundPath()
        {
            return foundPath;
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

        private int level(string path)
        {
            return path.Split('\\').Length - initial.Split('\\').Length;
        }

        private string parent(string path)
        {
            return Directory.GetParent(path).ToString();
        }

        private void access(string node)
        { 
            graf.AddNode(node);
            if (node != initial)
            {
                graf.AddEdgesAccessed(parent(node), node);
            }

            //Console.WriteLine(node);

            visited.Append(node);

            evaluate(node);

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
            if (path != initial)
            {
                coloring(parent(path));
                graf.ChangeBlue(parent(path), path);
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
                graf.ChangeNodeBlue(f);
                coloring(f);
            }

            if(q.Count > 0)
            {
                int lastFoundLevel = level(foundPath[foundPath.Count() - 1]);
                foreach (var element in q)
                {
                    if (level(element) <= lastFoundLevel)
                    {
                        graf.AddNode(element);
                        graf.AddEdgesNotAccessed(parent(element), element);
                    }
                    
                }
            }

        }

        
    }
}
