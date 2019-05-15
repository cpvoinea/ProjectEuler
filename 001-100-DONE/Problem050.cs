using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem050 : IProblem
    {
        public object GetResult()
        {
            int limit = 1000000;
            List<int> primes = Common.GetPrimeNumbersLowerThan(limit);

            int firstS = 0;
            int count = 0;
            while (firstS < limit)
            {
                firstS += primes[count];
                count++;
            }
            count--;
            firstS -= primes[count];
            int from = 0;
            int s = firstS;

            while (count >= 21)
            {
                if (primes.Contains(s))
                    return s;

                s -= primes[from];
                from++;
                s += primes[from + count - 1];

                if (s > limit)
                {
                    count--;
                    firstS -= primes[count];
                    from = 0;
                    s = firstS;
                }
            }

            return "nope";
        }
    }
}
