using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem046 : IProblem
    {
        public string GetResult()
        {
            long limit = 10000000;
            List<long> primes = new List<long>();
            for (long i = 3; i < limit; i += 2)
            {
                if (Common.IsPrime(i))
                    primes.Add(i);
                else
                {
                    bool ok = false;
                    for (int j = primes.Count - 1; j >= 0 && !ok; j--)
                    {
                        double n = Math.Sqrt((i - primes[j]) / 2);
                        if (n % 1 == 0.0)
                            ok = true;
                    }
                    if (!ok)
                        return i.ToString();
                }
            }

            return "nope";
        }
    }
}
