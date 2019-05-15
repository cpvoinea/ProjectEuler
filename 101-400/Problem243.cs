using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Problem243 : IProblem
    {
        void AddCandidates(List<int> candidates, int current, int i, int max, int[] primes)
        {
            if (i >= primes.Length || current * primes[i] > max)
                return;
            int c = current * primes[i];
            candidates.Add(c);
            AddCandidates(candidates, c, i, max, primes);
            AddCandidates(candidates, current, i + 1, max, primes);
        }

        public object GetResult()
        {
            var primes = Common.GetPrimeNumbersLowerThan(100);
            long n = 1;
            double f = 1;
            int maxPrime = 0;
            foreach (int p in primes)
            {
                n *= p;
                f *= (p - 1);
                double m = f * 94744.0 / 15499 / (n - 1);
                if (m < 1)
                {
                    n /= p;
                    f /= (p - 1);
                    maxPrime = p;
                    break;
                }
            }

            List<int> candidates = new List<int>();
            AddCandidates(candidates, 1, 0, maxPrime, primes.Where(x => x < maxPrime).ToArray());
            candidates.Sort();
            foreach (int c in candidates)
            {
                double m = f * c * 94744.0 / 15499 / (n * c - 1);
                if (m < 1)
                    return (n * c);
            }

            return "N/A";
        }
    }
}
