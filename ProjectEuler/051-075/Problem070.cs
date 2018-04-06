using System;
using System.Collections;

namespace ProjectEuler
{
    class Problem070 : IProblem
    {
        const int limit = 10000000;
        readonly BitArray isPrime = Common.GeneratePrimes(limit);

        bool IsPerm(int f, int n)
        {
            var fs = f.ToString().ToCharArray();
            var ns = n.ToString().ToCharArray();
            if (fs.Length < ns.Length)
                return false;
            Array.Sort(fs);
            Array.Sort(ns);
            return new string(fs) == new string(ns);
        }

        int Totient(int n, int p, int f)
        {
            if (n == 1)
                return f;

            if (isPrime[n])
                return f / n * (n - 1);

            while (!isPrime[p] || n % p > 0)
                p++;

            int m = n / p;
            while (m % p == 0)
                m /= p;
            return Totient(m, p + 1, f / p * (p - 1));
        }

        public string GetResult()
        {
            double min = limit;
            int minN = limit;
            for (int n = 2; n <= limit; n++)
            {
                int f = Totient(n, 2, n);

                if (IsPerm(f, n))
                {
                    double m = (double)n / f;
                    if (m < min)
                    {
                        min = m;
                        minN = n;
                    }
                }
            }

            return minN.ToString();
        }
    }
}
