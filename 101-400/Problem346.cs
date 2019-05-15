using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem346 : IProblem
    {
        public object GetResult()
        {
            const long limit = 1000000000000;
            long n = 2;
            HashSet<long> hs = new HashSet<long>();
            while (n <= Math.Sqrt(limit))
            {
                long m = n * n + n + 1;
                if (m <= limit && !hs.Contains(m))
                    hs.Add(m);
                while (m <= limit / n)
                {
                    m = m * n + 1;
                    if (m <= limit && !hs.Contains(m))
                        hs.Add(m);
                }
                n++;
            }

            long sum = 1;
            foreach (long x in hs)
                sum += x;

            return sum;
        }
    }
}
