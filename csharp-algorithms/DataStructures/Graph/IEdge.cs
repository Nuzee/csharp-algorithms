namespace csharp_algorithms.DataStructures.Graph
{
    public interface IEdge<T, TV> where TV : IVertex<T>
    {
        long Id { get; }
        TV Source { get; }
        TV Target { get; }

        int Compare(IEdge<T, TV> other);
    }
}