using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
            return BinarySearch(array, value, (IComparer<T>) null);
        }

        public static int BinarySearch<T>(T[] array, T value, IComparer<T> comparer)
        {

            return BinarySearch(array, 0, array.Length - 1, value, comparer);
        }

        public static int BinarySearch<T>(T[] array, T value, Comparison<T> comparison)
        {
            var comparer = Comparer<T>.Create(comparison);
            return BinarySearch(array, value, comparer);
        }

        public static int BinarySearch<T>(T[] array, int lowBound, int highBound, T value, IComparer<T> comparer)
        {
            if(array == null)
                throw new ArgumentNullException(nameof(array));

            if(lowBound < 0)
                throw new ArgumentOutOfRangeException(nameof(lowBound));

            if(highBound < 0)
                throw new ArgumentOutOfRangeException(nameof(highBound));

            if(highBound < lowBound)
                throw new ArgumentException("highBound is less than lowBound");

            IComparer<T> comp;

            if (comparer == null)
                if(value is IComparable<T>)
                    comp =  Comparer<T>.Default;
                else
                    throw new ArgumentException();
            else
                comp = comparer;

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
