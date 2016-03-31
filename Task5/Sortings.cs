using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public static class Sortings
    {

        public static void Bubble<T>(T[] array)
        {
            Bubble(array, null);
        }

        public static void Bubble<T>(T[] array, IComparer<T> comparer)
        {
            IComparer<T> comp = comparer ?? Comparer<T>.Default;
            for (int write = 0; write < array.Length; write++)
            {
                for (int sort = 0; sort < array.Length - 1; sort++)
                {                    
                    if (comp.Compare(array[sort], array[sort + 1]) > 0)
                    {
                        T temp = array[sort + 1];
                        array[sort + 1] = array[sort];
                        array[sort] = temp;
                    }
                }
            }

        }

    }
}
