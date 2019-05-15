using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem027 : IProblem
    {
        bool IsPrime(int n, List<int> primes)
        {
            return n > 1 && ((n < 2000 && primes.Contains(n)) || Common.IsPrime(n));
        }

        public object GetResult()
        {
            List<int> primes = Common.GetPrimeNumbersLowerThan(2000);
            int nMax = 0;
            int aMax = 0;
            int bMax = 0;
            foreach (int b in primes)
                if (b < 1000)
                    foreach (int m in primes)
                    {
                        int a = m - b - 1;
                        int i = 2;
                        while (IsPrime(i * i + a * i + b, primes))
                            i++;
                        if (i > nMax)
                        {
                            nMax = i;
                            aMax = a;
                            bMax = b;
                        }
                    }
            return (aMax * bMax) + " " + aMax + " " + bMax + " " + nMax;
        }
    }
}
