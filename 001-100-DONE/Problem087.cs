using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Problem087 : IProblem
    {
        public object GetResult()
        {
            const int limit = 50000000;
            const int limit1 = 7069;
            const int limit2 = 367;
            const int limit3 = 83;

            var primes = Common.GetPrimeNumbersLowerThan(limit1 + 1); //7069^2, 367^3, 83^4
            var primes2 = primes.Where(x => x <= limit2).ToList();
            var primes3 = primes.Where(x => x <= limit3).ToList();
            HashSet<int> numbers = new HashSet<int>();

            foreach (int c in primes3)
            {
                foreach (int b in primes2)
                {
                    int l = limit - b * b * b - c * c * c * c;
                    if (l > 0)
                    {
                        int p = (int)Math.Sqrt(l);
                        foreach (int a in primes.Where(x => x <= p))
                            numbers.Add(l - a * a);
                    }
                }
            }

            return numbers.Count;
        }
    }
}
