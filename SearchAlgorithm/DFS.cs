using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SearchAlgorithm
{
    public enum Mode
    {
        First,
        All
    }

    public class DFS
    {
        private Queue<string> queue;
        private string initial;
        private string destination;
        private string[] visited;

        public DFS(string initial, string destination)
        {
            this.queue = new Queue<string>();
            this.initial = initial;
            this.destination = destination;
        }
        
        public void crawl(Mode mode)
        {
            //inisialisasi
            visited = new string[] {};
            Stack<string> stack = new Stack<string>();
            string[] temp;
            Boolean found = false;
            string temp1;
            string[] subdirectories;

            //
            stack.Push(initial);

            //
            while (stack.Count > 0 && !found)
            {
                //
                temp1 = stack.Pop();

                
                // cek sudah pernah atau belum
                if (!visited.Contains(temp1))
                {
                    //
                    temp = temp1.Split('\\');
                    if (mode == Mode.First && temp[temp.Length - 1] == destination)
                    {
                        found = true;
                    } else if (temp[temp.Length - 1] == destination)
                    {
                        //nda tau ngapain
                    }

                    //
                    visited.Append(temp1);

                    //
                    subdirectories = Directory.GetDirectories(temp1);
                    for (int i = subdirectories.Length -1; i >= 0; i++)
                    {
                        stack.Push(subdirectories[i]);
                    }
                }

            }
        }  
    }
}
