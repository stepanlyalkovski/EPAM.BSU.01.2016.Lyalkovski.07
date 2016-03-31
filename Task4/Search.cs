using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public static class Search
    {
        public static int BinarySearch<T>(T[] array, T value)
        {
            return BinarySearch(array, value, null);
        }

        public static int BinarySearch<T>(T[] array, T value, IComparer<T> comparer)
        {
            return BinarySearch(array, 0, array.Length - 1, value, comparer);
        }

        public static int BinarySearch<T>(T[] array, int lowBound, int highBound, T value, IComparer<T> comparer)
        {
            IComparer<T> comp = comparer ?? Comparer<T>.Default;

            while (lowBound <= highBound)
            {
                int mid = (lowBound + highBound) / 2;
                if (comp.Compare(array[mid], value) < 0)
                {
                    lowBound = mid + 1;
                    continue;
                }
                if (comp.Compare(array[mid], value) > 0)
                {
                    highBound = mid - 1;
                    continue;
                }
                return mid;
            }
            return -1;
        }

        
    }
}
