using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Problem075 : IProblem
    {
        const int limit = 1500000;
        readonly List<int> primes = Common.GetPrimeNumbersLowerThan(1000);

        bool Primitives(int a, int b)
        {
            int c = a < b ? a : b;
            int p = primes[0];
            int i = 1;
            while (p <= c && i < primes.Count)
            {
                if (a % p == 0 && b % p == 0)
                    return false;
                p = primes[i++];
            }
            return true;
        }

        public string GetResult()
        {
            Dictionary<int, int> sums = new Dictionary<int, int>();
            for (int m = 2; m <= 1000; m++)
                for (int n = 1; n < m; n++)
                    if (Primitives(n, m))
                    {
                        int a = 2 * m * n;
                        int b = m * m - n * n;

                        if (Primitives(a, b))
                        {
                            int s = 2 * m * (m + n);
                            int ss = s;
                            while (ss <= limit)
                            {
                                if (sums.ContainsKey(ss))
                                    sums[ss]++;
                                else
                                    sums.Add(ss, 1);
                                ss += s;
                            }
                        }
                    }

            int max = sums.Max(x => x.Key);
            return string.Format("{0} - {1} = {2} {3} {4}", sums.Count, sums.Count(x => x.Value > 1), sums.Count(x => x.Value == 1), max, sums[max]);
        }
    }
}
