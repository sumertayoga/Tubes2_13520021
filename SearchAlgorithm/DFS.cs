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
    public class DFS
    {
        private Queue<string> queue;
        private string initial;
        private string destination;
        private string[] visited;
        string[] temp2;
        List<string> foundPath = new List<string>();
        Graph graf = new Graph();
        Node a1;


        public Graph getGraph()
        {
            return graf;
        }

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
            string idTemp;
            string[] subdirectories;

            temp = initial.Split('\\');
            if (mode == Mode.First && temp[temp.Length - 1] == destination)
            {
                foundPath.Add(initial);
                found = true;
            }
            else if (temp[temp.Length - 1] == destination)
            {
                foundPath.Add(initial);
            }
            //
            subdirectories = Directory.GetDirectories(initial);
            for (int i = subdirectories.Length - 1; i >= 0; i--)
            {
                stack.Push(subdirectories[i]);
            }
            graf.AddNode(initial);

            //
            while (stack.Count > 0 && !found)
            {
                //
                temp1 = stack.Pop();

                
                // cek sudah pernah atau belum
                if (!visited.Contains(temp1))
                {
                    //D:\Stima\C\X\W
                    temp = temp1.Split('\\');
                    graf.AddNode(temp1);
                    idTemp = "";
                    foreach (string t in temp.Take(temp.Length - 2))
                    {
                        idTemp += t + '\\';
                    }
                    idTemp += temp[temp.Length - 2];
                    graf.AddEdgesAccessed(idTemp, temp1);

                    Console.WriteLine(temp1);
                    Console.WriteLine(temp[temp.Length - 1]);
                    Console.WriteLine(destination);


                    if (mode == Mode.First && temp[temp.Length - 1] == destination)
                    {
                        foundPath.Add(temp1);
                        found = true;
                    } else if (temp[temp.Length - 1] == destination)
                    {
                        foundPath.Add(temp1);
                    }

                    //
                    visited.Append(temp1);

                    //
                    subdirectories = Directory.GetDirectories(temp1);
                    for (int i = subdirectories.Length -1; i >= 0; i--)
                    {
                        stack.Push(subdirectories[i]);
                    }
                }

            }

            foreach(string path in foundPath)
            {
                temp = path.Split('\\');
                temp2 = initial.Split('\\');

                for (int i = temp2.Length; i < temp.Length; i++)
                {
                    graf.ChangeBlue(initial, initial + '\\' + temp[i]);
                    initial = initial + '\\' + temp[i];
                }
            }

            foreach(var edges in stack)
            {
                temp = edges.Split('\\');
                string source = "";
                foreach(string t in temp.Take(temp.Length-2))
                {
                    source += t + '\\';
                }
                source += temp[temp.Length - 2];
                graf.AddNode(edges);
                graf.AddEdgesNotAccessed(source, edges);
            }
        }  
    }
}
