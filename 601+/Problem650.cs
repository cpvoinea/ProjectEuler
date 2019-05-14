using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem650 : IProblem
    {
        const int limit = 20000;
        const int div = 1_000_000_007;
        static readonly List<int> primes = Common.GetPrimeNumbersLowerThan(limit + 100);

        static int[][] FactorialFactors(int limit, ref int[][] ordinalFactors)
        {
            int[][] result = new int[limit + 1][];
            result[1] = new int[primes.Count];
            ordinalFactors[1] = new int[primes.Count];

            int[] factors = new int[primes.Count];
            for (int i = 2; i <= limit; i++)
            {
                ordinalFactors[i] = new int[primes.Count];
                int n = i;
                int ip = 0;
                while (n > 1 && primes[ip] <= n)
                {
                    int p = primes[ip];
                    int c = 0;
                    while (n > 1 && n % p == 0)
                    {
                        c++;
                        n /= p;
                    }
                    if (c > 0)
                    {
                        factors[ip] += c;
                        ordinalFactors[i][ip] = c;
                    }
                    if (ip < primes.Count - 1)
                        ip++;
                }

                result[i] = new int[primes.Count];
                factors.CopyTo(result[i], 0);
            }

            return result;
        }

        long DivisorSum(int[] factors)
        {
            long result = 1;
            for (int ip = 0; ip < primes.Count; ip++)
                if (factors[ip] > 0)
                {
                    int p = primes[ip];
                    long s = 1;
                    long f = 1;
                    for (int i = 0; i < factors[ip]; i++)
                    {
                        f = (f * p) % div;
                        s = (s + f) % div;
                    }
                    result = (result * s) % div;
                }

            return result;
        }

        public string GetResult()
        {
            int[][] ordinalFactors = new int[limit + 1][];
            int[][] factorialFactors = FactorialFactors(limit, ref ordinalFactors);

            long sum = 1;
            int[] factors = new int[primes.Count];
            for (int n = 2; n <= limit; n++)
            {
                for (int i = 0; i < primes.Count; i++)
                    factors[i] += ordinalFactors[n][i] * (n - 1) - factorialFactors[n - 1][i];

                sum = (sum + DivisorSum(factors)) % div;
            }

            return sum.ToString(); //538319652
        }
    }
}