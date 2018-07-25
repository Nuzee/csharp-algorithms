namespace csharp_algorithms.DataStructures.DoubleLinkedLink
{
    public class DoubleLinkedListItem<T>
    {
        public DoubleLinkedListItem<T> PreviousItem;
        public DoubleLinkedListItem<T> NextItem;
        public T Value { get; }

        public DoubleLinkedListItem(T value)
        {
            this.Value = value;
        }
    }
}