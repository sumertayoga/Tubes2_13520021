﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.ComponentModel;



namespace SearchAlgorithm
{


    /* 
     PROBLEM
        1. The next level of foundFirst node is still accessed
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
            catch (Exception)
            {
                return;
            }

        }



        public void crawl(Mode m, bool showAll)
        {
            //inisialisasi
            mode = m;
            foundFirst = false;
            graf = new Graph();
            foundPath = new List<string>();
            visited = new string[] { };
            q = new Queue<string>();
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            q.Enqueue(initial);
            string path;
            while ((showAll && q.Count > 0) || (!showAll && q.Count > 0 && !foundFirst))
            {
                path = q.Dequeue();
                access(path);
                enqueueAllChild(path);

                if (foundFirst == true && originalTimeSpentTicks != 0)
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

        }

        public void crawlAnimate(Mode m, bool showAll,  BackgroundWorker w)
        {
            //inisialisasi
            crawl(m, showAll);
            w.ReportProgress(0);
            System.Threading.Thread.Sleep(1000);
            mode = m;
            foundFirst = false;
            visited = new string[] { };
            q = new Queue<string>();


            q.Enqueue(initial);
            string path;
            while (q.Count != 0 && !foundFirst)
            {
                path = q.Dequeue();
                accessAnimate(path, w);
                enqueueAllChild(path);
            }

            foreach (string f in foundPath)
            {
                coloringAnimate(f, w);
            }

        }
    }
}
