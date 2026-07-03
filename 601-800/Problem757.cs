using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    public class Problem757 : IProblem
    {
        public object GetResult()
        {
            const long MAX = 100000000000000;
            long SMAX = (long)Math.Sqrt(MAX / 2) + 1;

            var existing = new HashSet<long>();
            for (long m = 1; m < SMAX; m++)
            {
                long n = (long)Math.Sqrt(MAX / (m * (m + 1)));
                long p = m * n * (m + 1) * (n + 1);
                if (n < m)
                    break;
                while (p > MAX)
                {
                    n--;
                    p = m * n * (m + 1) * (n + 1);
                }
                for (long i = m; i <= n; i++)
                {
                    p = i * m * (i + 1) * (m + 1);
                    if (!existing.Contains(p))
                        existing.Add(p);
                }
            }

            return existing.Count;
        }
    }
}
