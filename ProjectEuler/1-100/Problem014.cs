using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem014 : IProblem
    {
        string GetLongestChainSeedBelow(long limit)
        {
            Dictionary<long, long> lengths = new Dictionary<long, long>();
            lengths.Add(1, 1);
            long maxL = 1;
            long maxN = 1;
            for (long i = 2; i < limit; i++)
            {
                long n = i;
                long l = 1;
                while (n != 1)
                {
                    if (n % 2 == 0)
                        n = n / 2;
                    else
                        n = 3 * n + 1;
                    l++;

                    if (lengths.ContainsKey(n))
                    {
                        l += lengths[n] - 1;
                        n = 1;
                    }
                }
                lengths.Add(i, l);
                if (l > maxL)
                {
                    maxL = l;
                    maxN = i;
                }
            }

            return maxN + " " + maxL;
        }

        public string GetResult()
        {
            return GetLongestChainSeedBelow(1000000);
        }
    }
}
