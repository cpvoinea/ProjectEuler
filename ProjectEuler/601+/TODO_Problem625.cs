using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler
{
    class Problem625 : IProblem
    {
        Dictionary<long, long> tot = new Dictionary<long, long>();
        const int r = 316228;

        internal long Totient(long n, int p, long f, BitArray primes)
        {
            if (n == 1)
                return f;
            if (tot.ContainsKey(n))
                return tot[n];

            if (n < r && primes[(int)n])
            {
                long t = f / n * (n - 1);
                tot.Add(n, t);
                return t;
            }

            while (p < r && (!primes[p] || n % p > 0))
                p++;

            long m = n / p;
            while (m % p == 0)
                m /= p;

            long nt = Totient(m, p + 1, f / p * (p - 1), primes);
            tot.Add(n, nt);
            return nt;
        }

        public string GetResult()
        {
            const long limit = 10;// 0000000000;
            const long div = 998244353;
            var primes = Common.GeneratePrimes(r);

            long n = limit / 2;
            BigInteger sum = n;
            sum = (sum * sum + (sum * (sum + 1) / 2)) % div;

            long i = 2;
            BigInteger s = 1;
            while (n > 1)
            {
                BigInteger m = n;
                i++;
                n = limit / i;
                m -= n;
                s += Totient(i - 1, 2, i - 1, primes);
                sum += ((m * n) + m * (m + 1) / 2) * s;
            }

            while (i <= limit)
            {
                s += Totient(i, 2, i, primes);
                i++;
            }
            sum = (sum + s) % div;

            return sum.ToString();
        }
    }
}
