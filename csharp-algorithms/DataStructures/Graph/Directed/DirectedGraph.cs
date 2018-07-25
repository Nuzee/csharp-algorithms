using System.Collections.Generic;
using System.Linq;

namespace csharp_algorithms.DataStructures.Graph.Directed
{
    public class DirectedGraph<T, TV, TE> : IGraph<T, TV, TE> 
        where TV: DirectedVertex<T>
        where TE: DirectedEdge<T, TV>, new()
    {
        private List<TV> vertices 
            = new List<TV>();

        private List<TE> edges
            = new List<TE>();

        public bool IsDirected => true;

        public IEnumerable<TV> Vertices
            => vertices;
        public IEnumerable<TE> Edges
        => edges;

        public DirectedGraph()
        {
            
        }

        public void AddVertex(TV vertex)
        {
            vertices.Add(vertex);
        }

        public TV GetVertex(int id)
        {
            return vertices.Find(v => v.Id == id);
        }

        public bool RemoveVertex(TV vertex)
        {
            var result = vertices.Remove(vertex);
            if (result)
            {
                foreach (var edge in edges)
                {
                    if (edge.Source == vertex || edge.Target == vertex)
                    {
                        edges.Remove(edge);
                    }
                }
            }
            return result;
        }

        public TE GetEdge(long id)
        {
            return edges.Find(v => v.Id == id);
        }

        public bool RemoveEdge(TE edge)
        {
            return edges.Remove(edge);
        }
    }
}