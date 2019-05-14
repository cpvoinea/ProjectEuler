using System;
using System.Collections;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem518 : IProblem
    {
        public string GetResult()
        {
            const int limit = 100_000_000;
            var isPrime = Common.GeneratePrimes(limit);
            List<int> primes = new List<int>();
            for (int i = 2; i < limit; i++)
                if (isPrime[i])
                    primes.Add(i);
            Dictionary<int, int> den = new Dictionary<int, int>();
            foreach (int p in primes)
            {
                int n = p + 1;
                int i = 0;
                int m = primes[i];
                int f = 1;
                while (m < n && n > 1 && !isPrime[n])
                {
                    bool found = false;
                    while (n % m == 0)
                    {
                        n /= m;
                        if (found)
                        {
                            f *= m;
                            found = false;
                        }
                        else
                            found = true;
                    }
                    i++;
                    m = primes[i];
                }
                den.Add(p, f);
            }

            long sum = 0;
            int ia = 0;
            int count = 0;
            while (ia < primes.Count - 2)
            {
                int a = primes[ia];
                int n = den[a];
                double max = (limit + 1.0) / (a + 1.0);
                double m = n + 1.0;
                double q = m / n;
                while (q * q < max)
                {
                    double b = Math.Round((a + 1) * q) - 1;
                    if (b % 1 == 0 && isPrime[(int)b])
                    {
                        double c = Math.Round((b + 1) * q) - 1;
                        if (c % 1 == 0 && isPrime[(int)c] && a < b && b < c && c < limit)
                        {
                            sum += a + (int)b + (int)c;
                            count++;
                        }
                    }
                    m++;
                    q = m / n;
                }
                ia++;
            }

            return sum.ToString();
        }
    }
}