﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace SearchAlgorithm
{
    public enum Mode
    {
        First,
        All
    }
    public class BFS
    {
        private Queue<string> q;
        private string[] visited;
        private string initial;
        private string destination;
        
        public BFS(string initialDirectory, string destination)
        {
            this.initial = initialDirectory;
            this.destination = destination;
            this.q = new Queue<string>();
        }

        public void crawl(Mode mode)
        {
            //inisialisasi
            string accessed  = initial;
            string[] subdirectories;
            string queueAccessed;
            visited.Append(initial);
            if (mode == Mode.First && initial == destination)
            {
                
            } else if (initial == destination)
            {

            }
            q.Enqueue(initial);

            while (q.Count != 0)
            {
                queueAccessed = q.Dequeue();
                subdirectories = Directory.GetDirectories(queueAccessed);
                for (int i = 0; i < subdirectories.Length; i++)
                {
                    accessed = subdirectories[i];
                    if (!visited.Contains(accessed))
                    {
                        if (mode == Mode.First && initial == destination)
                        {

                        }
                        else if (initial == destination)
                        {

                        }
                        visited.Append(accessed);
                        q.Enqueue(accessed);
                    }
                }
            }
        }
    }
}
