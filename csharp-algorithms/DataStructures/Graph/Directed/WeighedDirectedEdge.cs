namespace csharp_algorithms.DataStructures.Graph.Directed
{
    public class WeighedDirectedEdge<T> : DirectedEdge<T>
    {
        public WeighedDirectedEdge(DirectedVertex<T> source, DirectedVertex<T> target, int weight = 1)
            : base(source, target)
        {
            Weight = weight;
        }

        public int Weight { get; }
    }
}