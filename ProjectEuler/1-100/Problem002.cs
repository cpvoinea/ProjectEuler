using System;

namespace ProjectEuler
{
    class Problem002 : IProblem
    {
        long CalculateFibbonacciEvenSumLessThan(int n)
        {
            int a = 1;
            int b = 2;
            long s = 0;
            while (a < n)
            {
                int t = b;
                b = a + b;
                a = t;

                Console.Write(a + " ");
                if (a % 2 == 0)
                    s += a;
            }

            Console.WriteLine();
            return s;
        }

        public string GetResult()
        {
            return CalculateFibbonacciEvenSumLessThan(4000000).ToString();
        }
    }
}
