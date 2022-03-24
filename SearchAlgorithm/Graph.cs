using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Msagl.Drawing;

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

            Node a1 = this.graph.AddNode(nodeName);
            a1.Attr.LabelMargin = 15;
            a1.Attr.Shape = Shape.Plaintext;
            string[] splitter = nodeName.Split('\\');
            a1.Label.Text = splitter[splitter.Length - 1];
        }

        public void AddEdgesNotAccessed(string node1, string node2)
        {
            Edge e = this.graph.AddEdge(node1, node2);
            e.Attr.ArrowheadAtTarget = ArrowStyle.None;
            e.Attr.Length = 30;

        }
        public void AddEdgesAccessed(string node1, string node2)
        {
            Edge e = this.graph.AddEdge(node1, node2);
            e.Attr.ArrowheadAtTarget = ArrowStyle.None;
            e.Attr.Length = 30;
            e.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
            this.graph.FindNode(node1).Label.FontColor = Color.Red;
            this.graph.FindNode(node2).Label.FontColor = Color.Red;
        }


        public Microsoft.Msagl.Drawing.Edge FindEdge(string source, string target)
        {
            foreach (var edge in graph.Edges)
            {
                if (edge.SourceNode.Id == source && edge.TargetNode.Id == target)
                {
                    return edge;
                }
            }
            return null;
        }
        

        public void ChangeBlue(string source, string target)
        {
            graph.FindNode(source).Label.FontColor = Microsoft.Msagl.Drawing.Color.Blue;
            graph.FindNode(target).Label.FontColor = Microsoft.Msagl.Drawing.Color.Blue;
            var edge = FindEdge(source, target);
            if(edge != null)
            {
                edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
            }
        }

        public void ChangeNodeBlue(string nodeId)
        {
            Node n = this.graph.FindNode(nodeId);
            if (n != null)
            {
                n.Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
            }
        }

    }
}
