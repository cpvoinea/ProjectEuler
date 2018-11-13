using System.Collections;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem293 : IProblem
    {
        const int limit = 1000000000;
        readonly BitArray isPrime = Common.GeneratePrimes(limit + limit / 10);

        bool IsAdmissable(int n)
        {
            int p = 2;
            while (n > 1 && p < limit)
            {
                if (isPrime[p])
                {
                    if (n % p != 0)
                        return false;
                    while (n % p == 0)
                        n /= p;
                }
                p++;
            }

            return n == 1;
        }

        public string GetResult()
        {
            HashSet<int> pfn = new HashSet<int>();
            for (int n = 2; n <= limit; n += 2)
            {
                if (IsAdmissable(n))
                {
                    int m = 3;
                    while (!isPrime[n + m])
                        m += 2;
                    if (!pfn.Contains(m))
                        pfn.Add(m);
                }
            }

            int s = 0;
            foreach (int m in pfn)
                s += m;
            return s.ToString();
        }
    }
}
