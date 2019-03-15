using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem650 : IProblem
    {
        const int limit = 100;
        const int div = 1_000_000_007;

        static int[][] FactorialFactors(int limit, int primeCount, List<int> primes, ref int[][] ordinalFactors)
        {
            int[][] result = new int[limit + 1][];
            result[1] = new int[primeCount + 1];
            ordinalFactors[1] = new int[primeCount + 1];

            int[] factors = new int[primeCount + 1];
            for (int i = 2; i <= limit; i++)
            {
                ordinalFactors[i] = new int[primeCount + 1];
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
                    if (ip < primeCount - 1)
                        ip++;
                }

                result[i] = new int[primeCount + 1];
                factors.CopyTo(result[i], 0);
            }

            return result;
        }

        long D(int[] factors, List<int> primes, int primeCount)
        {
            long result = 1;
            for (int ip = 0; ip <= primeCount; ip++)
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
            List<int> primes = Common.GetPrimeNumbersLowerThan(limit + 1);
            int primeCount = primes.Count;
            int[][] ordinalFactors = new int[limit + 1][];
            int[][] factorialFactors = FactorialFactors(limit, primeCount, primes, ref ordinalFactors);

            long sum = 1;
            int[] factors = new int[primeCount + 1];
            for (int n = 2; n <= limit; n++)
            {
                for (int i = 0; i <= primeCount; i++)
                    factors[i] += ordinalFactors[n][i] * (n - 1) + ordinalFactors[n - 1][i] - factorialFactors[n - 1][i] * 2;

                sum = (sum + D(factors, primes, primeCount)) % div;
            }

            return sum.ToString();
        }
    }
}