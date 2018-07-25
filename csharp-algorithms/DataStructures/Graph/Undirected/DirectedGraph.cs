using System;
using System.Collections.Generic;

namespace csharp_algorithms.DataStructures.Graph.Undirected
{
    public class UndirectedGraph
    {
    }

    public class UndirectedVertex<T>
    {
        private static readonly Random Random = new Random();

        public List<UndirectedEdge<T>> Edges { get; set; }

        public UndirectedVertex(T value)
        {
            Value = value;
            Id = value.GetHashCode() ^ Random.Next();
        }

        public int Id { get; }
        public T Value { get; }
        public int Degree => Edges.Count;
    }
}