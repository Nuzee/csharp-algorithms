using System.Collections;
using System.Collections.Generic;

namespace csharp_algorithms.DataStructures.DoubleLinkedLink
{
    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        public DoubleLinkedList()
        {
        }

        public DoubleLinkedList(T value)
        {
            Head = Tail = new DoubleLinkedListItem<T>(value);
        }

        public DoubleLinkedListItem<T> Head { get; private set; }
        public DoubleLinkedListItem<T> Tail { get; private set; }

        public void Append(T value)
        {
            var node = new DoubleLinkedListItem<T>(value);
            if (Head == null)
            {
                Head = Tail = new DoubleLinkedListItem<T>(value);
            }
            else
            {
                node.PreviousItem = Tail;
                Tail.NextItem = node;
                Tail = node;
            }
        }

        public void Prepend(T value)
        {
            var node = new DoubleLinkedListItem<T>(value);
            if (Head == null)
            {
                Head = Tail = new DoubleLinkedListItem<T>(value);
            }
            else
            {
                node.NextItem = Head;
                Head.PreviousItem = node;
                Head = node;
            }
        }

        public bool DeleteHead()
        {
            if (Head != null)
            {
                if (Head.NextItem != null)
                {
                    Head = Head.NextItem;
                    Head.PreviousItem = null;
                }
                else
                {
                    Tail = Head = null;
                }
                return true;
            }

            return false;
        }

        public bool DeleteTail()
        {
            if (Tail != null)
            {
                if (Tail.PreviousItem != null)
                {
                    Tail = Tail.PreviousItem;
                    Tail.NextItem = null;
                }
                else
                {
                    Tail = Head = null;
                }
                return true;
            }

            return false;
        }

        public bool Delete(T value)
        {
            if (Head == null) return false;

            var current = Head;
            while (current.NextItem != null)
            {
                if (current.Value.Equals(value))
                {
                    if (current != Head)
                    {
                        current.PreviousItem.NextItem = current.NextItem;
                        current.NextItem.PreviousItem = current.PreviousItem;
                    }
                    else
                    {
                        current.PreviousItem = null;
                        Head = current;
                    }

                    return true;
                }

                current = current.NextItem;
            }

            if (current.Value.Equals(value))
            {
                Tail = current.PreviousItem;
                Tail.NextItem = null;
                return true;
            }

            return false;
        }

        public T[] ToArray()
        {
            var result = new List<T>();
            var current = Head;
            while (current != null)
            {
                result.Add(current.Value);
                current = current.NextItem;
            }

            return result.ToArray();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal class DoublyLinkedListEnumerator : IEnumerator<T>
        {
            private readonly DoubleLinkedList<T> _list;
            private DoubleLinkedListItem<T> _currentItem;
            public bool MoveNext()
            {
                _currentItem = _currentItem == null ? _list.Head : _currentItem.NextItem;

                return _currentItem != null;
            }

            public DoublyLinkedListEnumerator(DoubleLinkedList<T> list)
            {
                this._list = list;
            }
            public void Reset()
            {
                _currentItem = null;
            }

            public T Current => _currentItem != null ? _currentItem.Value : default(T);

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        } 
    }
}