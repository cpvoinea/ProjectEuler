using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem668 : IProblem
    {
        long limit = 10000000000;
        const int ls = 100000;
        readonly List<int> primes = Common.GetPrimeNumbersLowerThan(ls);

        long CountProductsLowerThan(int maxPrimeIndex, long maxProduct, int minProduct)
        {
            if (maxPrimeIndex < 0 || maxProduct <= 1)
                return 0;
            int p = primes[maxPrimeIndex];
            long max = maxProduct / p;
            long count = 0;
            int f = p;
            while (max > 0)
            {
                count += CountProductsLowerThan(maxPrimeIndex - 1, max, minProduct / f);
                if (f > minProduct)
                    count++;
                max /= p;
                f *= p;
            }
            return count + CountProductsLowerThan(maxPrimeIndex - 1, maxProduct, minProduct);
        }

        public object GetResult()
        {
            int maxPrimeIndex = primes.Count - 1;
            long count = 1;

            while (maxPrimeIndex >= 0)
            {
                int maxPrime = primes[maxPrimeIndex];
                long maxProduct = limit / maxPrime;
                count += CountProductsLowerThan(maxPrimeIndex, maxProduct, maxPrime);

                maxPrimeIndex--;
            }

            return count;
        }
    }
}