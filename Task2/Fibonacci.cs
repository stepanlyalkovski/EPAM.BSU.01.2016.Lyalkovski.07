using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Fibonacci
    {
        public static IEnumerable<int> GetSequence(int number)
        {
            int num1 = 0;
            int num2 = 1;

            for (int i = 0; i < number; i++)
            {
                yield return num1;
                int temp = num2;
                num2 += num1;
                num1 = temp;
            }
        }
    }
}
