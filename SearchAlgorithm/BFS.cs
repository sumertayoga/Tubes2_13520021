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
        private Queue<string> q;
        private string initial;
        private string destination;
        private string[] visited;
        string[] temp2;
        Graph graf = new Graph();
        Node a1;
        Node a2;
        public Graph getGraph()
        {
            return graf;
        }

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
            string foundPath = "";
            string[] temp;
            string idTemp;
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
                foundPath = accessed;
            }
            q.Enqueue(initial);
            a1 = new Node(initial);
            graf.AddNode(a1);
            temp = initial.Split('\\');
            a1.Label.Text = temp[temp.Length - 1];
            Boolean found = false;
            while (q.Count != 0 && !found)
            {
                queueAccessed = q.Dequeue();
                subdirectories = Directory.GetDirectories(queueAccessed);
                files = Directory.GetFiles(queueAccessed);
                for (int i = subdirectories.Length-1; i >= 0; i--)
                {
                    accessed = subdirectories[i];
                    if (!visited.Contains(accessed))
                    {
                        // PRINT NODE
                        temp = accessed.Split('\\');
                        a1 = new Node(accessed);
                        graf.AddNode(a1);
                        a1.Label.Text = temp[temp.Length - 1];
                        idTemp = "";
                        foreach (string t in temp.Take(temp.Length - 2))
                        {
                            idTemp += t + '\\';
                        }
                        idTemp += temp[temp.Length - 2];
                        graf.AddEdges(idTemp, accessed);
                        Console.WriteLine(accessed);
                        Console.WriteLine(temp[temp.Length-1]);
                        Console.WriteLine(destination);
                        visited.Append(accessed);
                        q.Enqueue(accessed);
                        if (mode == Mode.First && temp[temp.Length - 1] == destination)
                        {
                            //WARNA KETEMU
                            q.Clear();
                            found = true;
                        }
                        else if (temp[temp.Length - 1] == destination)
                        {
                            //WARNA KETEMU
                            foundPath = accessed;
                        }
                        
                        
                    }
                }

                /*for (int i = 0; i < files.Length; i++)
                {
                    accessed = files[i];
                    temp = accessed.Split('\\');
                    //graf.AddEdges(temp[temp.Length - 2], temp[temp.Length - 1]);
                    Console.WriteLine(accessed);
                    if (!visited.Contains(accessed))
                    {
                        // PRINT NODE
                        if (mode == Mode.First && temp[temp.Length-1] == destination)
                        {
                            //WARNA KETEMU
                            q.Clear();
                        }
                        else if (temp[temp.Length-1] == destination)
                        {
                            //WARNA KETEMU
                        }
                        visited.Append(accessed);
                    }
                }*/
            }

            temp = foundPath.Split('\\');
            temp2 = initial.Split('\\');

            for (int i = temp2.Length; i < temp.Length; i++)
            {
                graf.ChangeBlue(initial, initial + '\\' + temp[i]);
                initial = initial + '\\' + temp[i];
            }
        }
    }
}
