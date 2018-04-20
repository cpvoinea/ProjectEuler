using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem078 : IProblem
    {
        const int limit = 1000000;
        Dictionary<long, long> counts = new Dictionary<long, long>();

        long Comb(long n, long m)
        {
            if (m == n)
                return 1;
            if (m > n)
                return 0;
            long key = n * 10000 + m;
            if (counts.ContainsKey(key))
                return counts[key];

            long s = 1;
            for (long i = 2; i <= m; i++)
                s = (s + Comb(n - m, i)) % limit;
            s = s % limit;
            counts[key] = s;
            return s;
        }

        public string GetResult()
        {
            long n = 2;
            while (n < 10000)
            {
                long s = 1;
                for (long i = 2; i <= n; i++)
                    s = (s + Comb(n, i)) % limit;
                s = s % limit;
                if (s == 0)
                    return n.ToString();
                n++;
            }

            return "N/A";
        }
    }
}
