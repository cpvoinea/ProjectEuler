using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem429 : IProblem
    {
        public string GetResult()
        {
            const int limit = 100_000_000;
            const int div = 1_000_000_009;
            var primes = Common.GetPrimeNumbersLowerThan(limit);

            Dictionary<int, int> powers = new Dictionary<int, int>();
            foreach (int p in primes)
            {
                int pow = 0;
                int n = limit;
                while (n >= p)
                {
                    n /= p;
                    pow += n;
                }
                powers.Add(p, pow);
            }

            long s = 1;
            foreach (int p in powers.Keys)
            {
                long sp = 1;
                for (int i = 0; i < 2 * powers[p]; i++)
                    sp = (sp * p) % div;

                s = (s * (sp + 1)) % div;
            }

            return s.ToString();
        }
    }
}