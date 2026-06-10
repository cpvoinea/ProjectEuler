using System;

namespace ProjectEuler
{
    public class Problem932 : IProblem
    {
        public object GetResult()
        {
            const int N = 16;
            long L = (long)Math.Floor(Math.Pow(10, N / 2) / 9) + 1;
            long s = 0;

            for (long k = 1; k < L; k++)
            {
                long i = k * 9;
                long n = i * i;
                if (Check(n, i))
                    s += n;
                n = (i + 1) * (i + 1);
                if (Check(n, i + 1))
                    s += n;
            }

            return s;
        }

        private bool Check(long a, long i)
        {
            long b = a % 10;
            a /= 10;
            if (a + b == i && b > 0)
                return true;
            long e = 10;
            while (a > 0)
            {
                while (a % 10 == 0 && a > 0)
                {
                    a /= 10;
                    e *= 10;
                }
                b = a % 10 * e + b;
                e *= 10;
                a = a / 10;
                if (a + b == i && b > 10)
                    return true;
            }
            return false;
        }
    }
}
