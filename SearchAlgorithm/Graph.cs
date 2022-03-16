﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithm
{
    public class Graph
    {
        //Atribut??
        Microsoft.Msagl.Drawing.Graph graph;

        //Constructor
        public Graph()
        {
            this.graph = new Microsoft.Msagl.Drawing.Graph();
        }

        public Microsoft.Msagl.Drawing.Graph getGraph()
        {
            return this.graph;
        }

        public void AddNode(string nodeName)
        {
            /*foreach (var node in graph.Nodes)
            {
                if (node.Id == nodeName)
                {
                    nodeName += " ";
                }
            }*/
            this.graph.AddNode(nodeName);
        }

        public void AddEdges(string node1, string node2)
        {
            this.graph.AddEdge(node1, node2);
        }

        public Microsoft.Msagl.Drawing.Edge FindEdge(string source, string target)
        {
            foreach (var edge in graph.Edges)
            {
                if (edge.SourceNode.LabelText == source && edge.TargetNode.LabelText == target)
                {
                    return edge;
                }
            }
            return null;
        }

        public void ChangeRed(string source, string target)
        {
            var edge = FindEdge(source, target);
            edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
        }

        public void ChangeBlue(string source, string target)
        {
            var edge = FindEdge(source, target);
            edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
        }

    }
}
