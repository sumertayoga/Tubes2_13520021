using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Windows.Forms;


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
        private string initial;
        private string destination;
        private string[] visited;
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
            string[] files;
            string[] temp;
            string queueAccessed;
            visited = new string[] { };
            q = new Queue<string>();
            visited.Append(initial);
            Console.WriteLine(initial);
            if (mode == Mode.First && initial == destination)
            {
                
                return;
            } else if (initial == destination)
            {
            }
            q.Enqueue(initial);

            while (q.Count != 0)
            {
                queueAccessed = q.Dequeue();
                subdirectories = Directory.GetDirectories(queueAccessed);
                files = Directory.GetFiles(queueAccessed);
                for (int i = 0; i < subdirectories.Length; i++)
                {
                    accessed = subdirectories[i];
                    if (!visited.Contains(accessed))
                    {
                        // PRINT NODE
                        temp = accessed.Split('\\');
                        Console.WriteLine(accessed);
                        if (mode == Mode.First && temp[temp.Length - 1] == destination)
                        {
                            //WARNA KETEMU
                            q.Clear();
                        }
                        else if (temp[temp.Length - 1] == destination)
                        {
                            //WARNA KETEMU
                        }
                        visited.Append(accessed);
                        q.Enqueue(accessed);
                    }
                }

                for (int i = 0; i < files.Length; i++)
                {
                    accessed = files[i];
                    Console.WriteLine(accessed);
                    if (!visited.Contains(accessed))
                    {
                        // PRINT NODE
                        if (mode == Mode.First && accessed == destination)
                        {
                            //WARNA KETEMU
                            q.Clear();
                        }
                        else if (accessed == destination)
                        {
                            //WARNA KETEMU
                        }
                        visited.Append(accessed);
                    }
                }
            }
        }
    }
}
