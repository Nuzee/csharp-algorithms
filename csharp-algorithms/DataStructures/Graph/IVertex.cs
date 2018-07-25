using System.Collections.Generic;

namespace csharp_algorithms.DataStructures.Graph
{
    public interface IVertex<T>
    {
        int Degree { get; }
        int Id { get; }
        
        IEnumerable<IEdge<T, IVertex<T>>> Edges { get; }
        T Value { get; }

        IVertex<T>[] GetNeighbors();
    }
}