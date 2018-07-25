namespace csharp_algorithms.DataStructures.Graph.Undirected
{
    public class UndirectedEdge<T>
    {
        public UndirectedVertex<T> Source { get; private set; }
        public UndirectedVertex<T> Target { get; private set; }
        public long Id => Source.Id << (32 + Target.Id);

        public UndirectedEdge(UndirectedVertex<T> source, UndirectedVertex<T> target)
        {
            this.Source = source;
            this.Target = target;
        }

        public int Compare(UndirectedEdge<T> other)
        {
            if (this.Id == other.Id) return 0;

            return this.Id < other.Id ? -1 : 1;
        }
    }
}