using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem668 : IProblem
    {
        const long limit = 10000000000; //00000000;
        static readonly List<int> primes = Common.GetPrimeNumbersLowerThan((int)Math.Sqrt(limit));

        static int MaxExp(int p, long max) => (int)Math.Log(max, p);
        static long MaxPow(int p, int e) => (long)Math.Pow(p, e);
        static long Count(int i, long max)
        {
            if (i == 1)
                return MaxExp(2, max);

            long count = Count(i - 1, max);

            int p = primes[i - 1];
            int e = MaxExp(p, max);
            while (e > 0)
            {
                long m = max / MaxPow(p, e);
                if (m > 0)
                    count++;
                if (m > 1)
                    count += Count(i - 1, m);

                e--;
            }

            return count;
        }

        public object GetResult()
        {
            long count = 1;
            count += MaxExp(2, limit) - 2; // 2^3, 2^4,... 2^e < limit

            int i = 1;
            while (i < primes.Count)
            {
                int p = primes[i];
                int e = MaxExp(p, limit);
                count += e - 2; // p^3, p^4,... p^e < limit

                while (e > 0)
                {
                    long max = limit / MaxPow(p, e);
                    count += Count(i, max); // p^e*2, p^e*2^2,...p^e*2^f < max

                    e--;
                }
                count -= Count(i, p);

                i++;
            }

            return count;
        }
    }
}
