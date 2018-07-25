using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp_algorithms.DataStructures.Graph.Directed
{
    public class DirectedVertex<T> : IVertex<T>
    {
        protected static readonly Random Random = new Random();

        public DirectedVertex(T value)
        {
            Value = value;
            Id = value.GetHashCode() ^ Random.Next();
        }
        
        public int Id { get; }
        public IEnumerable<IEdge<T, IVertex<T>>> Edges { get; }
        public T Value { get; }
        IVertex<T>[] IVertex<T>.GetNeighbors()
        {
            return GetNeighbors();
        }

        public int Indegree => IncomingEdges.Count;
        public int Outdegree => OutgoingEdges.Count;
        public int Degree => Indegree + Outdegree;
        
        public List<IEdge<T, DirectedVertex<T>>> IncomingEdges { get; private set; }
            = new List<IEdge<T, DirectedVertex<T>>>();

        internal void Remove(long id)
        {
            IncomingEdges = IncomingEdges.Where(e => e.Id == id).ToList();
            OutgoingEdges = OutgoingEdges.Where(e => e.Id == id).ToList();
        }

        public List<IEdge<T, DirectedVertex<T>>> OutgoingEdges { get; private set; }
            = new List<IEdge<T, DirectedVertex<T>>>();

        public void AddIncoming<TV>(DirectedEdge<T, TV> edge) where TV : DirectedVertex<T>
        {
            IncomingEdges.Add((IEdge<T, DirectedVertex<T>>)edge);
        }
        public void AddOutgoing<TV>(DirectedEdge<T, TV> edge) where TV : DirectedVertex<T>
        {
            OutgoingEdges.Add((IEdge<T, DirectedVertex<T>>) edge);
        }

        public bool RemoveIncoming(DirectedEdge<T, DirectedVertex<T>> edge) 
        {
            return IncomingEdges.Remove(edge);
        }

        public bool RemoveOutgoing(DirectedEdge<T, DirectedVertex<T>> edge)
        {
            return OutgoingEdges.Remove(edge);
        }

        public bool Remove(DirectedEdge<T, DirectedVertex<T>> edge) { 
            return IncomingEdges.Remove(edge) |
                   OutgoingEdges.Remove(edge);
        }

        public DirectedVertex<T>[] GetNeighbors()
        {
            var set = new HashSet<DirectedVertex<T>>(this.Degree);

            foreach (var edge in IncomingEdges)
            {
                set.Add(edge.Source);
            }
            foreach (var edge in OutgoingEdges)
            {
                set.Add(edge.Target);
            }

            return set.ToArray();
        }

        public DirectedVertex<T>[] GetSources()
        {
            var set = new DirectedVertex<T>[Indegree];
            for (var i = 0; i < Indegree; i++)
            {
                set[i] = IncomingEdges[i].Source;
            }
            return set;
        }

        public DirectedVertex<T>[] GetTargets()
        {
            var set = new DirectedVertex<T>[Outdegree];
            for (var i = 0; i < Outdegree; i++)
            {
                set[i] = OutgoingEdges[i].Target;
            }
            return set;
        }
    }
}