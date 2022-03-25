using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.ComponentModel;


namespace SearchAlgorithm
{
    public enum Mode
    {
        First,
        All
    }
    public abstract class GraphSearch : Object
    {
        protected string initial;
        protected string destination;
        protected Mode mode;
        protected List<string> foundPath;
        protected Graph graf;
        protected bool foundFirst;
        protected string[] visited;
        public long originalTimeSpentTicks = 0;
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

        public static string parent(string path)
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
            if (mode == Mode.First && end == destination && !foundFirst)
            {
                foundPath.Add(path);
                foundFirst = true;
            }
            else if (end == destination && !foundFirst)
            {
                foundPath.Add(path);
            }
        }

        protected void evaluateAnimate(string path)
        {
            string end = endPath(path);
            if (mode == Mode.First && end == destination)
            {
                foundFirst = true;
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
                Console.WriteLine("Node " + node);
                graf.ChangeRed(parent(node), node);
                int c = graf.getGraph().NodeCount;
                if (c >= 6)
                {
                    System.Threading.Thread.Sleep((750*6) / c);
                } else
                {
                    System.Threading.Thread.Sleep(400);
                }
            }
            w.ReportProgress(0);


            //Console.WriteLine(node);

            visited.Append(node);

            evaluateAnimate(node);
        }

        public abstract void crawl(Mode m, bool showAll);
        public abstract void crawlAnimate(Mode m, bool showAll, BackgroundWorker w);

    }
}
