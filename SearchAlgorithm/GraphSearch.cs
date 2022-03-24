using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.ComponentModel;


namespace SearchAlgorithm
{
    public enum Mode
    {
        First,
        All
    }
    public class GraphSearch
    {
        protected string initial;
        protected string destination;
        protected Mode mode;
        protected List<string> foundPath;
        protected Graph graf;
        protected bool found;
        protected string[] visited;

        public Graph getGraph()
        {
            return graf;
        }

        public List<string> getFoundPath()
        {
            return foundPath;
        }

        public GraphSearch(string initialDirectory, string destination)
        {
            mode = Mode.First;
            this.initial = initialDirectory;
            this.destination = destination;
        }

        protected string endPath(string path)
        {
            string[] temp = path.Split('\\');
            return temp[temp.Length - 1];
        }

        

        protected int level(string path)
        {
            if (Directory.GetDirectoryRoot(initial) == path)
            {
                return 0;
            }
            return path.Split('\\').Length - initial.Split('\\').Length;
        }

        protected string parent(string path)
        {
            return Directory.GetParent(path).ToString();
        }

        protected void coloring(string path)
        {
            if (path != initial)
            {
                coloring(parent(path));
                graf.ChangeBlue(parent(path), path);
            }

        }

        protected void coloringAnimate(string path, BackgroundWorker w)
        {
            if (path != initial)
            {
                coloring(parent(path));
                
                graf.ChangeBlue(parent(path), path);
                graf.ChangeNodeBlue(path);

                w.ReportProgress(0);
            }

        }

        protected void evaluate(string path)
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

        protected void access(string node)
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

        protected void accessAnimate(string node, BackgroundWorker w)
        {
            if (node != initial)
            {
                graf.ChangeRed(parent(node), node);
                System.Threading.Thread.Sleep(1000);
            }
            w.ReportProgress(0);


            //Console.WriteLine(node);

            visited.Append(node);

            evaluate(node);

        }
    }
}
