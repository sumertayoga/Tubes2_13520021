using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.ComponentModel;


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
                int i = childs.Length-1;
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
            catch (Exception)
            {
                return;
            }

        }

        public override void crawl(Mode m, bool showAll)
        {
            //inisialisasi
            mode = m;
            foundFirst = false;
            graf = new Graph();
            foundPath = new List<string>();
            visited = new string[] { };
            stack = new Stack<string>();
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            stack.Push(initial);
            string path;
            while ((showAll && stack.Count > 0) || (!showAll && stack.Count > 0 && !foundFirst))
            {
                path = stack.Pop();
                access(path);
                pushAllChild(path);

                if (foundFirst == true && originalTimeSpentTicks == 0)
                {
                    stopwatch.Stop();
                    originalTimeSpentTicks = stopwatch.ElapsedTicks;
                }
            }

            if (foundFirst != true)
            {
                stopwatch.Stop();
                originalTimeSpentTicks = stopwatch.ElapsedTicks;
            }

            if (stack.Count > 0)
            {
                int lastFoundLevel = level(foundPath[foundPath.Count() - 1]);
                foreach (var element in stack)
                {
                    if (level(element) <= lastFoundLevel)
                    {
                        graf.AddNode(element);
                        graf.AddEdgesNotAccessed(parent(element), element);
                    }

                }
            }


        }

        public override void crawlAnimate(Mode m, bool showAll, BackgroundWorker w)
        {
            //inisialisasi
            crawl(m, showAll);
            w.ReportProgress(0);
            System.Threading.Thread.Sleep(1000);
            mode = m;
            foundFirst = false;
            visited = new string[] { };
            stack = new Stack<string>();


            stack.Push(initial);
            string path;
            while (stack.Count != 0 && !foundFirst)
            {
                path = stack.Pop();
                accessAnimate(path, w);
                pushAllChild(path);
            }

            foreach (string f in foundPath)
            {
                coloringAnimate(f, w);
            }

        }
    }
}
