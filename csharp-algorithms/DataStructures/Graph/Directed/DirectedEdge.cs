namespace csharp_algorithms.DataStructures.Graph.Directed
{
    public class DirectedEdge<T, TV> : IEdge<T, TV> where TV : DirectedVertex<T>
    {
        private TV _source;

        public DirectedEdge(TV source, TV target)
        {
            Source = source;
            Target = target;
        }

        public TV Source { get; private set; }

        TV IEdge<T, TV>.Target { get; } 

        public int Compare(IEdge<T, TV> other)
        {
            throw new System.NotImplementedException();
        }

        TV IEdge<T, TV>.Source => _source;

        public TV Target { get; private set; }
        public long Id => Source.Id << (32 + Target.Id);

        public int Compare(DirectedEdge<T, TV> other)
        {
            if (Id == other.Id) return 0;

            return Id < other.Id ? -1 : 1;
        }

        public void Reverse()
        {
            _source.Remove(this.Id);
            var temp = Source;
            Source = Target;
            Target = temp;
            Source.AddOutgoing<TV>(this);
            Target.AddIncoming<TV>(this);
        }
    }
}