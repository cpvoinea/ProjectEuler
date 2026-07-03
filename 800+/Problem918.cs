using System.Collections.Generic;

namespace ProjectEuler
{
    public class Problem918 : IProblem
    {
        private long A(long n)
        {
            if (n <= 1)
                return 1;

            long m = n;
            long p = 1;
            while (n % 2 == 0)
            {
                p *= 2;
                n /= 2;
            }
            if (n <= 1)
                return p;

            var r = p * (A(n / 2) - 3 * A(n / 2 + 1));
            return r;
        }

        public object GetResult()
        {
            const long N = 1_000_000_000_000;
            long s = A(N) + A(1) + A(2) + A(3);
            long k = (N - 1) / 4;
            s += 6 * (1 - A(k + 1));

            return s;
        }
    }
}
