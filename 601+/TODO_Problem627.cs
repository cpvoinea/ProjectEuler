using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    class Problem627 : IProblem
    {
        const int mod = 1000000007;
        const int b = 50000;

        // 3
        Dictionary<BigInteger, long> ce1 = new Dictionary<BigInteger, long>();
        long Count1Exact(int p, int n, int r10, int r6, int r4, int r3, int r2)
        {
            if (n < 0 || r10 < 0 || r6 < 0 || r4 < 0 || r3 < 0 || r2 < 0)
                return 0;
            BigInteger k = n * b + p;
            k = ((((k * b + r10) * b + r6) * b + r4) * b + r3) * b + r2;
            if (ce1.ContainsKey(k))
                return ce1[k];
            if (p == 0)
            {
                long max = n * 4 + r10 * 3 + r6 * 2 + r4 * 2 + r3 + r2 + 1;
                ce1[k] = max;
                return max;
            }

            long c1 = Count1Exact(p - 1, n - 1, r10 + 1, r6, r4, r3, r2);
            long c2 = Count1Exact(p - 1, n, r10 - 1, r6, r4, r3 + 1, r2);
            long c3 = Count1Exact(p - 1, n, r10, r6 - 1, r4, r3, r2 + 1);
            long c4 = Count1Exact(p - 1, n, r10, r6, r4 - 1, r3, r2);
            long c5 = Count1Exact(p - 1, n, r10, r6, r4, r3 - 1, r2);


            long c = new[] { c1, c2, c3, c4, c5 }.Max();
            ce1[k] = c;
            return c;
        }

        Dictionary<BigInteger, long> ca1 = new Dictionary<BigInteger, long>();
        long Count1(int n, int r6, int r4, int r2)
        {
            BigInteger k = n;
            k = ((k * b + r6) * b + r4) * b + r2;
            if (ca1.ContainsKey(k))
                return ca1[k];

            long c = 0;
            int max = 3 * n + r6 + r4;
            for (int i = 0; i <= max; i++)
                c = (c + Count1Exact(i, n, 0, r6, r4, 0, r2));

            ca1[k] = c;
            return c;
        }

        // 5
        Dictionary<BigInteger, long> ce2 = new Dictionary<BigInteger, long>();
        long Count2Exact(int p, int n, int r6, int r4, int r2)
        {
            if (n < 0 || r6 < 0 || r4 < 0 || r2 < 0)
                return 0;
            if (p == 0)
                return Count1(n, r6, r4, r2);
            BigInteger k = n * b + p;
            k = ((k * b + r6) * b + r4) * b + r2;
            if (ce2.ContainsKey(k))
                return ce2[k];

            long c1 = Count2Exact(p - 1, n - 1, r6 + 1, r4, r2);
            long c2 = Count2Exact(p - 1, n, r6 - 1, r4, r2);
            long c = c1 > c2 ? c1 : c2;

            ce2[k] = c;
            return c;
        }

        Dictionary<BigInteger, long> ca2 = new Dictionary<BigInteger, long>();
        long Count2(int n, int r4, int r2)
        {
            BigInteger k = n;
            k = (k * b + r4) * b + r2;
            if (ca2.ContainsKey(k))
                return ca2[k];

            long c = 0;
            int max = 2 * n;
            for (int i = 0; i <= max; i++)
                c = (c + Count2Exact(i, n, 0, r4, r2)) % mod;

            ca2[k] = c;
            return c;
        }

        // 7
        Dictionary<long, long> ca3 = new Dictionary<long, long>();
        long Count3(int n, int r2)
        {
            long k = n * b + r2;
            if (ca3.ContainsKey(k))
                return ca3[n];

            long c = 0;
            for (int i = 0; i <= n; i++)
                c = (c + Count2(n - i, i, r2)) % mod;

            ca3.Add(k, c);
            return c;
        }

        // 11, 13
        Dictionary<int, long> ca4 = new Dictionary<int, long>();
        long Count4(int n)
        {
            if (ca4.ContainsKey(n))
                return ca4[n];

            long c = 0;
            for (int i = 0; i <= n; i++)
                c = (c + Count3(n - i, i) * (i + 1)) % mod;

            ca4.Add(n, c);
            return c;
        }

        // 17, 19, 23, 29
        long Count(int n)
        {
            long c = 0;
            for (int i = 0, k = 1; i <= n; i++, k *= (i + 3) / i)
                c = (c + Count4(n - i) * k + 1) % mod;

            return c;
        }

        public object GetResult()
        {
            long c = Count(10001);
            return c;
        }
    }
}
