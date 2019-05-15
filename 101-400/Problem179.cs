using System;
using System.Collections;

namespace ProjectEuler
{
    class Problem179 : IProblem
    {
        const int limit = 10000000;
        readonly BitArray prime = Common.GeneratePrimes(limit);

        long CountDivisors(int n)
        {
            long c = 1;
            int p = 2;
            while (n > 1 && p <= (int)Math.Sqrt(n))
            {
                if (prime[p] && n % p == 0)
                {
                    int a = 0;
                    while (n % p == 0)
                    {
                        n /= p;
                        a++;
                    }
                    c *= (a + 1);
                }
                p++;
            }
            if (n > 1)
                c *= 2;

            return c;
        }

        public object GetResult()
        {
            long d = 2;
            int count = 0;
            for (int n = 2; n < limit; n++)
            {
                long next = CountDivisors(n + 1);
                if (next == d)
                    count++;
                d = next;
            }

            return count;
        }
    }
}
