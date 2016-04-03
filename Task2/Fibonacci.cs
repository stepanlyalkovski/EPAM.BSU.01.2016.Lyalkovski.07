using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Fibonacci
    {
        public static IEnumerable<long> FibonacciSequence(int number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException(nameof(number));

            long num1 = 0;
            long num2 = 1;

            for (int i = 0; i < number; i++)
            {
                yield return num1;
                checked
                {
                    long temp = num2;
                    num2 += num1;
                    num1 = temp;
                }

            }
        }
    }
}
