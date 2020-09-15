using Logic.Abstract;
using System;
using System.Collections.Generic;

namespace Logic.Implementation
{
    public class FibonacciService : IFibonacciService
    {
        public int[] GenerateValues(string maxValue)
        {
            int value = Convert.ToInt32(maxValue);
            List<int> fiboSequence = new List<int>();
            int a = 0; int b = 1; int c;

            fiboSequence.Add(a);
            fiboSequence.Add(b);

            for (int i = 2; i < value; i++)
            {
                c = a + b;
                a = b; b = c;
                if (c == value)
                {
                    fiboSequence.Add(c);
                    break;
                }
                fiboSequence.Add(c);
            }
            return fiboSequence.ToArray();
        }
    }
}
