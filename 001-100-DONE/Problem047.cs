using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem047 : IProblem
    {
        public object GetResult()
        {
            int target = 4;
            int limit = 1000000;
            List<int> primes = Common.GetPrimeNumbersLowerThan(limit);

            int total = 0;
            int i = 14;
            for (i = 14; i < limit; i++)
            {
                int c = 0;
                int n = i;
                foreach (int p in primes)
                {
                    if (i % p == 0)
                    {
                        c++;
                        if (c > target)
                            break;
                        n /= p;
                        while (n % p == 0)
                            n /= p;
                    }
                }
                if (c == target)
                {
                    total++;
                    if (total == target)
                        break;
                }
                else
                    total = 0;
            }

            if (total == target)
                return (i - 3);
            return "nope";
        }
    }
}
