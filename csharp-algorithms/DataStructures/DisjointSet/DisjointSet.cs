using System.Collections.Generic;
using System.Linq;

namespace csharp_algorithms.DataStructures.DisjointSet
{
    public class DisjointSet<T>
    {
        public DisjointSet()
        {
            this.items = new T[];
        }
    }

    public class DisjointedSetItem<T>
    {

        public int? Key;
        public T Value { get; }
        public DisjointedSetItem<T> Parent;
        public List<DisjointedSetItem<T>> Children = new List<DisjointedSetItem<T>>();

        public DisjointedSetItem(T value, int key)
        {
            this.Key = key;
            this.Value = value;
        }

        public DisjointedSetItem<T> GetRoot()
        {
            return this.Parent?.GetRoot() ?? this;
        }

        /**
   * Rank basically means the number of all ancestors.
   *
   * @return {number}
   */
        public int GetRank()
        {
            if (this.Children.Any()) return 0;
            var rank = 0;
            this.Children.ForEach(child => {
                // Count child itself.
                rank++;

                // Also add all children of current child.
                rank += child.GetRank();
            });

            return rank;
        }
    }
}