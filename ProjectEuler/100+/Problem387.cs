using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem387 : IProblem
    {
        const long limit = 100000000000000;
        readonly List<long> _primes = new List<long>();

        long DigitSum(long n)
        {
            long s = 0;
            while (n > 0)
            {
                s += n % 10;
                n /= 10;
            }
            return s;
        }

        private bool IsPrime(long n)
        {
            if (n < 2)
                return false;
            if (n < 4)
                return true;
            if (n % 2 == 0)
                return false;

            if (_primes.Contains(n))
                return true;

            for (long i = 3; i <= Math.Sqrt(n); i += 2)
                if (n % i == 0)
                    return false;

            _primes.Add(n);
            return true;
        }

        long Check(long c)
        {
            if (c * 10 >= limit)
                return 0;
            long s = 0;
            long sum = DigitSum(c);
            bool isStrong = c % sum == 0 && IsPrime(c / sum);
            for (long i = 0; i < 10; i++)
            {
                long n = c * 10 + i;
                if (isStrong && IsPrime(n))
                    s += n;
                else
                {
                    long ns = sum + i;
                    if (n % ns != 0)
                        continue;
                    s += Check(n);
                }
            }
            return s;
        }

        public string GetResult()
        {
            long sum = 0;
            foreach (long c in new long[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })
                sum += Check(c);

            return sum.ToString();
        }
    }
}
