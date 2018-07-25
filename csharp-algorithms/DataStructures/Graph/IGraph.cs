using System.Collections.Generic;

namespace csharp_algorithms.DataStructures.Graph
{
    public interface IGraph<T, TV, TE> 
        where TE : IEdge<T, TV>
        where TV : IVertex<T>
    {
        bool IsDirected { get; }

        IEnumerable<TV> Vertices { get; }
        IEnumerable<TE> Edges { get; }
    }
}