using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem007 : IProblem
    {
        long GetPrimeNo(int n)
        {
            List<long> primes = new List<long>();
            primes.Add(2);
            for (long i = 3; ; i += 2)
            {
                bool isPrime = true;
                for (int j = 0; isPrime && j < primes.Count; j++)
                {
                    long p = primes[j];
                    if (i % p == 0)
                        isPrime = false;
                }
                if (isPrime)
                {
                    primes.Add(i);
                    if (primes.Count == n)
                        return i;
                }
            }
        }

        public string GetResult()
        {
            return GetPrimeNo(10001).ToString();
        }
    }
}
