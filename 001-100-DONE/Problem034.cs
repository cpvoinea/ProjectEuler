using System;

namespace ProjectEuler
{
    class Problem034 : IProblem
    {
        int[] factorial = new int[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };

        public object GetResult()
        {
            long result = 0;
            for (long i = 10; i < 100000000; i++)
            {
                long n = i;
                long s = 0;
                while (n > 0)
                {
                    long d = n % 10;
                    s += factorial[d];
                    n = n / 10;
                }
                if (s == i)
                {
                    Console.WriteLine(i);
                    result += i;
                }
            }

            return result;
        }
    }
}
