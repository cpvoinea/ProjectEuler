using System.Linq;

namespace ProjectEuler
{
    class Problem627 : IProblem
    {
        const int mod = 1000000007;

        // 3
        long CountExact1(int p, int n, int r10, int r6, int r4, int r3, int r2)
        {
            if (n < 0 || r10 < 0 || r6 < 0 || r4 < 0 || r3 < 0 || r2 < 0)
                return 0;
            if (p == 0)
                return 4 * n + 3 * r10 + 2 * r6 + 2 * r4 + r3 + r2 + 1;
            long c1 = CountExact1(p - 1, n - 1, r10 + 1, r6, r4, r3, r2);
            long c2 = CountExact1(p - 1, n, r10 - 1, r6, r4, r3 + 1, r2);
            long c3 = CountExact1(p - 1, n, r10, r6 - 1, r4, r3, r2 + 1);
            long c4 = CountExact1(p - 1, n, r10, r6, r4 - 1, r3, r2);
            long c5 = CountExact1(p - 1, n, r10, r6, r4, r3 - 1, r2);

            return new[] { c1, c2, c3, c4, c5 }.Max();
        }

        long Count1(int n, int r6, int r4, int r2)
        {
            long c = 0;
            long max = n * 3 + r6 + r4;
            for (int i = 0; i <= max; i++)
                c = (c + CountExact1(i, n, 0, r6, r4, 0, r2)) % mod;
            return c;
        }

        // 5
        long CountExact2(int p, int n, int r6, int r4, int r2)
        {
            if (n < 0 || r6 < 0 || r4 < 0 || r2 < 0)
                return 0;
            if (p == 0)
                return Count1(n, r6, r4, r2);
            long c1 = CountExact2(p - 1, n - 1, r6 + 1, r4, r2);
            long c2 = CountExact2(p - 1, n, r6 - 1, r4, r2);
            return c1 > c2 ? c1 : c2;
        }

        long Count2(int n, int r4, int r2)
        {
            long c = 0;
            long max = n * 2;
            for (int i = 0; i <= max; i++)
                c = (c + CountExact2(i, n, 0, r4, r2)) % mod;
            return c;
        }

        // 7
        long Count3(int n, int r2)
        {
            long c = 0;
            for (int i = 0; i <= n; i++)
                c = (c + Count2(n - i, i, r2)) % mod;
            return c;
        }

        // 11
        long Count4(int n, int r2)
        {
            long c = 0;
            for (int i = 0; i <= n; i++)
                c = (c + Count3(n - i, r2 + i)) % mod;
            return c;
        }

        // 13
        long Count5(int n)
        {
            long c = 0;
            for (int i = 0; i <= n; i++)
                c = (c + Count4(n - i, i)) % mod;
            return c;
        }

        // 17
        long Count6(int n)
        {
            long c = 0;
            for (int i = 0; i <= n; i++)
                c = (c + Count5(n - i)) % mod;
            return c;
        }

        // 19
        long Count7(int n)
        {
            long c = 0;
            for (int i = 0; i <= n; i++)
                c = (c + Count6(n - i)) % mod;
            return c;
        }

        // 23
        long Count8(int n)
        {
            long c = 0;
            for (int i = 0; i <= n; i++)
                c = (c + Count7(n - i)) % mod;
            return c;
        }

        // 29
        long Count(int n)
        {
            long c = 0;
            for (int i = 0; i <= n; i++)
                c = (c + Count8(n - i)) % mod;
            return c;
        }

        public string GetResult()
        {
            long c = Count(10);

            return c.ToString();
        }
    }
}
