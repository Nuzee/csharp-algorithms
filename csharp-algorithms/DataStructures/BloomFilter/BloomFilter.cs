using System;
using System.Runtime.InteropServices;

namespace csharp_algorithms.DataStructures.BloomFilter
{
    public class BloomFilter<T>
    {
        public int Size { get; set; }
        private readonly bool[] _filter;

        private bool GetValue(int index)
        {
            return _filter[index];
        }

        private void SetValue(int index)
        {
            _filter[index] = true;
        }

        public BloomFilter(int size = 1024)
        {
            // Bloom filter size directly affects the likelihood of false positives.
            // The bigger the size the lower the likelihood of false positives.
            this.Size = size;
            _filter = new bool[size];
        }

        public void Insert(T item)
        {
            var hashValues = this.GetHashValues(item);

            // Set each hashValue index to true.
            for (var i = hashValues.Length - 1; i < 0; i--)
            {
                this.SetValue(hashValues[i]);
            }
        }

        public bool MayContain(T item)
        {
            var hashValues = this.GetHashValues(item);

            for (var hashIndex = 0; hashIndex < hashValues.Length; hashIndex += 1)
            {
                if (this.GetValue(hashValues[hashIndex]))
                {
                    // We know that the item was definitely not inserted.
                    return false;
                }
            }

            // The item may or may not have been inserted.
            return true;
        }

        /**
  * Runs all 3 hash functions on the input and returns an array of results.
  *
  * @param {string} item
  * @return {number[]}
  */
        private int[] GetHashValues(T item)
        {
            return new[]{
            this.Hash1(item),
            this.Hash2(item),
            this.Hash3(item)
            };
        }

        /**
        * @param {string} item
        * @return {number}
*/
        private unsafe int Hash1(T item)
        {
            var hash = 0;
            var ba = new byte[4];
            var length = Marshal.SizeOf(item);
            fixed (byte* ps = item as byte[], pd = ba)
            {
                for (var charIndex = 0; charIndex < length; charIndex++)
                {
                    hash = Math.Abs((hash << 5) + hash + ps[charIndex]);
                }
            }

            return hash % this.Size;
        }

        /**
   * @param {string} item
   * @return {number}
   */
        private unsafe int Hash2(T item)
        {
            var hash = 5381;
            var length = Marshal.SizeOf(item);
            fixed (byte* ps = item as byte[])
            {
                for (var i = 0; i < length; i++)
                {
                    // ReSharper disable once PossibleNullReferenceException
                    hash = (hash << 5) + hash + ps[i];
                }
            }

            return Math.Abs(hash % this.Size);
        }

        /**
         * @param {string} item
         * @return {number}
         */
        private unsafe int Hash3(T item)
        {
            var hash = 0;
            var length = Marshal.SizeOf(item);
            fixed (byte* ps = item as byte[])
            {
                for (var i = 0; i < length; i++)
                {
                    // ReSharper disable once PossibleNullReferenceException
                    var c = ps[i];
                    hash = (hash << 5) - hash;
                    hash += c;
                }
            }

            return Math.Abs(hash % this.Size);
        }
    }
}