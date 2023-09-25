using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem808 : IProblem
    {
        public object GetResult()
        {
            const int maxPrime = 100_000_000;
            HashSet<long> primeSquares = new HashSet<long>();
            var primes = Common.GetPrimeNumbersLowerThan(maxPrime);
            foreach (long p in primes)
                primeSquares.Add(p * p);

            int count = 0;
            long sum = 0;
            foreach(var ps in primeSquares)
            {
                if (Common.IsPalindrome(ps.ToString()))
                    continue;
                if (!primeSquares.Contains(Common.Reverse(ps)))
                    continue;

                count++;
                sum += ps;

                if (count == 50)
                    return sum;
            }

            return count;
        }
    }
}
