using System;

namespace ProjectEuler
{
    class Problem094 : IProblem
    {
        bool IsPP(long n)
        {
            long s = (long)Math.Sqrt(n);
            return s * s == n;
        }

        public string GetResult()
        {
            const int limit = 166666666;
            long sum = 0;
            for (int k = 1; k <= limit; k++)
            {
                long p = 3 * k + 1;
                if (IsPP((k + 1) * p))
                    sum += 2 * p;
                if (IsPP(k * (p + 1)))
                    sum += 2 * (p + 1);
            }
            return sum.ToString();
        }
    }
}
