using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bellman_Ford
{
    public class Graph
    {
        public class Vertex
        {
            public int id;
            public double shortest;

            public Vertex() { }

            public Vertex(int id)
            {
                this.id  = id;
                this.shortest = double.MaxValue;
            }
        }

        public class Edge
        {
            public Vertex src, dest;
            public double weight;

            public Edge() { }

            public Edge(Vertex src, Vertex dest, double weight)
            {
                this.src = src;
                this.dest = dest;
                this.weight = weight;
            }
        }

        public List<Vertex> Vertexes { get; set; }
        public List<Edge> Edges { get; set; }

        public Graph()
        {
            Vertexes = new List<Vertex>();
            Edges = new List<Edge>();
        }

        public Graph(string filePath) :  this()
        {
            string[] lines = File.ReadAllLines(filePath);

            for(int i=0, n=lines.Length; i<n; i++)
            {
                var line = lines[i].Trim(']', '[');
                var src = AddVertex(i);

                string[] edges = line.Split(',');
                foreach(var edge in edges)
                {
                    if (string.IsNullOrEmpty(edge)) continue;

                    Tuple<int, double> destWeight = Tuple.Create(int.Parse(edge.Split('#')[0]), double.Parse(edge.Split('#')[1]));
                    var dest = AddVertex(destWeight.Item1);
                    Edges.Add(new Edge(src, dest, destWeight.Item2));
                }
            }
        }

        public void BellmanFord(int src)
        {
            var srcVertex = Vertexes.FirstOrDefault(a => a.id == src);
            if(srcVertex == null)
            {
                Console.WriteLine($"There is no Vertex with id {src}");
                return;
            }

            srcVertex.shortest = 0;

            foreach(var vertex in Vertexes.Skip(1))
            {
                foreach(var edge in Edges)
                {
                    var weight = edge.src.shortest + edge.weight;
                    if (edge.src.shortest != double.MaxValue && weight < edge.dest.shortest)
                        edge.dest.shortest = weight;
                }
            }

            foreach (var edge in Edges)
            {
                var weight = edge.src.shortest + edge.weight;
                if (edge.src.shortest != int.MaxValue && weight < edge.dest.shortest)
                {
                    Console.WriteLine("Graph contains negative weight cycle");
                    return;
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("Vertex Distance from Source");
            foreach(var vertex in Vertexes)
                Console.WriteLine(vertex.id + "\t\t" + (vertex.shortest == double.MaxValue ? "INF" : String.Format("{0:0.###}", vertex.shortest)));
        }

        private Vertex AddVertex(int id)
        {
            var vertex = Vertexes.FirstOrDefault(a => a.id == id);
            if (vertex == null)
            {
                vertex = new Vertex(id);
                Vertexes.Add(vertex);
            }

            return vertex;    
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            // source path for file with adjacency list
            string path = "../../../graph.txt";
            var graph = new Graph(path);
            // idx of source vertex (nr of line in file counted from 0)
            graph.BellmanFord(0);
            graph.Print();
        }
    }
}
