using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem357 : IProblem
    {
        bool IsPrime(HashSet<int> primes, int n)
        {
            if (primes.Contains(n))
                return true;
            foreach (int p in primes)
                if (n % p == 0)
                    return false;
            primes.Add(n);
            return true;
        }

        public string GetResult()
        {
            const int limit = 100000000;
            HashSet<int> primes = new HashSet<int>(Common.GetPrimeNumbersLowerThan(1000000));

            int sum = 2;
            int n = 4;
            while(n < limit)
            {
                if (IsPrime(primes, n + 1) && IsPrime(primes, n / 2 + 2))
                {
                    bool ok = true;
                    for (int k = 3; k < n / 2; k++)
                        if (n % k == 0)
                            if (!IsPrime(primes, k + n))
                            {
                                ok = false;
                                break;
                            }
                    if (ok)
                        sum += n;
                }
                n += 2;
            }

            return sum.ToString();
        }
    }
}
