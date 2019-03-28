using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem003 : IProblem
    {
        long GetLargestPrimeFactorOf(long n)
        {
            List<int> primes = Common.GetPrimeNumbersLowerThan((int)Math.Sqrt(n));
            int count = primes.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                int p = primes[i];
                if (n % p == 0)
                    return p;
            }

            return n;
        }

        public string GetResult()
        {
            return GetLargestPrimeFactorOf(600851475143).ToString();
        }
    }
}
