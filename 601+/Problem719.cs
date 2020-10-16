using System;

namespace ProjectEuler
{
    class Problem719 : IProblem
    {
        static bool S(long n, long s)
        {
            if (n == s)
                return true;
            if (n > s || n < 0)
                return false;

            long d = 0;
            long i = 1;
            while (s > 0)
            {
                d += (s % 10) * i;
                i *= 10;
                if (d > n)
                    return false;
                s /= 10;
                if (S(n - d, s))
                    return true;
            }
            return false;
        }

        public object GetResult()
        {
            const long limit = 1000000000000;
            long sum = 0;
            for (long n = 2; n <= Math.Sqrt(limit); n++)
            {
                long s = n * n;
                if (S(n, s))
                {
                    sum += s;
                    Console.WriteLine(n + " " + s);
                }
            }

            return sum;
        }
    }
}