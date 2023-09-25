using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem800 : IProblem
    {
        const int N = 800800;
        const int E = 800800;
        static int _log2;
        static List<int> _primes;
        static int[] _factors;

        static void Initialize()
        {
            _log2 = (int)Math.Ceiling(Math.Log(N, 2) * E);
            _primes = Common.GetPrimeNumbersLowerThan(_log2);
            _factors = new int[_primes.Count];
            int n = N;
            int i = 0;
            while (n > 1)
            {
                int p = _primes[i];
                while(n % p == 0)
                {
                    _factors[i] += E;
                    n /= p;
                }
                i++;
            }
        }

        public object GetResult()
        {
            Initialize();
            int minIndex = 0;
            int maxIndex = _primes.Count - 1;
            long count = 0;
            while (minIndex < maxIndex)
            {
                maxIndex = GetMaxIndex(minIndex, maxIndex);
                count += maxIndex - minIndex;
                minIndex++;
            }

            return count;
        }

        static int GetMaxIndex(int minIndex, int currentMaxIndex)
        {
            int p = _primes[minIndex];
            int m = (int)Math.Ceiling(Math.Log(N, p) * E);
            if (m > _primes[currentMaxIndex])
                m = _primes[currentMaxIndex];

            int i = currentMaxIndex;
            do
            {
                if (Check(p, m))
                    return i;
                i--;
                m = _primes[i];
            } while (i > minIndex);
            return minIndex;
        }

        static bool Check(int p, int m)
            => Math.Log(m, p) * p + m <= Math.Log(N, p) * E;
    }
}
