using System.Collections;

namespace ProjectEuler
{
    class Problem357 : IProblem
    {
        public string GetResult()
        {
            const int limit = 100000000;
            BitArray primes = Common.GeneratePrimes(limit);
            long sum = 1;
            int n = 2;
            while (n < limit)
            {
                if (primes[n / 2 + 2] && primes[n + 1])
                {
                    bool candidate = true;
                    for (int i = 3; i < n / i; i++)
                        if (n % i == 0)
                        {
                            if (!primes[n / i + i])
                            {
                                candidate = false;
                                break;
                            }
                        }
                    if (candidate)
                        sum += n;
                }

                n += 2;
            }

            return sum.ToString();
        }
    }
}
