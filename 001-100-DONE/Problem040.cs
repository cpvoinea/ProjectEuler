using System;

namespace ProjectEuler
{
    class Problem040 : IProblem
    {
        int GetDigit(int n)
        {
            int c = 1;
            int nd = 1;
            int s = 0;
            while (n > s + 9 * c * nd)
            {
                s += 9 * c * nd;
                c *= 10;
                nd++;
            }
            int m = c + (n - s) / nd - 1;
            int r = n - s - nd * (m - c + 1);
            if (r == 0)
                return m % 10;
            m = m + 1;
            for (int i = 0; i < r - 1; i++)
                c /= 10;
            return (m / c) % 10;
        }

        public object GetResult()
        {
            Console.WriteLine(GetDigit(10));
            int limit = 7;
            int p = 1;
            int c = 1;
            for (int i = 0; i < limit; i++)
            {
                p *= GetDigit(c);
                c *= 10;
            }

            return p;
        }
    }
}
