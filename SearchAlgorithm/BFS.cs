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
using System.ComponentModel;



namespace SearchAlgorithm
{


    /* 
     PROBLEM
        1. The next level of found node is still accessed
            Solution: use function to determine the level of the node --> not beautiful but working
        2. If start in logical drive, and try to find the logical drive, it wont work
     */
    public class BFS : GraphSearch
    {

        Queue<string> q;

        public BFS(string initialDirectory, string destination) : base(initialDirectory, destination)
        {

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

            /*foreach (string f in foundPath)
            {
                graf.ChangeNodeBlue(f);
                coloring(f);
            }*/

            /*if (q.Count > 0)
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
            }*/




        }

        public void crawlAnimate(Mode m, BackgroundWorker w)
        {
            //inisialisasi
            crawl(m);
            w.ReportProgress(0);
            System.Threading.Thread.Sleep(1000);
            mode = m;
            found = false;
            visited = new string[] { };
            q = new Queue<string>();


            q.Enqueue(initial);
            string path;
            while (q.Count != 0 && !found)
            {
                path = q.Dequeue();
                accessAnimate(path, w);
                enqueueAllChild(path);
            }

            foreach (string f in foundPath)
            {
                coloringAnimate(f, w);
            }

            /*if (q.Count > 0)
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
            }*/

        }
    }
}
