using System;
using System.Collections;

namespace ProjectEuler
{
    class Problem549 : IProblem
    {
        const int limit = 100000000;
        readonly BitArray primes = Common.GeneratePrimes(limit);

        int GetFact(int p, int k, int n)
        {
            if (k == 1)
                return p;
            int i = 1;
            while (k > 0)
            {
                k--;
                int j = i;
                while (j > 1 && j % p == 0)
                {
                    k--;
                    j /= p;
                }
                i++;
            }

            int m = p * (i - 1);
            return m;
        }

        int GetMaxFact(int n)
        {
            if (primes[n])
            {
                return n;
            }

            if (n % 2 == 0)
            {
                int k = 0;
                int m = n;
                while (m > 1 && m % 2 == 0)
                {
                    k++;
                    m /= 2;
                }
                int m1 = GetFact(2, k, n / m);
                int m2 = GetMaxFact(m);
                m = m1 > m2 ? m1 : m2;
                return m;
            }

            for (int p = 3; p <= Math.Sqrt(n); p += 2)
                if (primes[p] && n % p == 0)
                {
                    int k = 0;
                    int m = n;
                    while (m > 1 && m % p == 0)
                    {
                        k++;
                        m /= p;
                    }
                    int m1 = GetFact(p, k, n / m);
                    int m2 = GetMaxFact(m);
                    m = m1 > m2 ? m1 : m2;
                    return m;
                }
            return 0;
        }

        public object GetResult()
        {
            long sum = 0;
            for (int i = 2; i <= limit; i++)
                sum += GetMaxFact(i);

            return sum;
        }
    }
}
