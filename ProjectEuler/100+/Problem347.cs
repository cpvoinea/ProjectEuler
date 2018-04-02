using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem347 : IProblem
    {
        public string GetResult()
        {
            const int limit = 10000000;
            int primeLimit = (int)Math.Sqrt(limit);
            List<int> primes = Common.GetPrimeNumbersLowerThan(limit / 2 + 1);
            long sum = 0;
            for(int i = 0; primes[i] <= primeLimit; i++)
                for(int j = i + 1; j < primes.Count; j++)
                {
                    int p = primes[i];
                    int q = primes[j];
                    long n = p * q;
                    if (n > limit)
                        break;
                    int k = 1;
                    while (n * p <= limit)
                    {
                        n *= p;
                        k++;
                    }
                    long max = n;
                    while (k > 1)
                    {
                        while (k > 1 && n * q > limit)
                        {
                            n = n / p;
                            k--;
                        }
                        if (k >= 1)
                        {
                            while (n * q <= limit)
                                n *= q;
                            if (n > max)
                                max = n;
                        }
                    }
                    sum += max;
                }

            return sum.ToString();
        }
    }
}
