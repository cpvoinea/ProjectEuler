using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Problem095 : IProblem
    {
        public string GetResult()
        {
            const int limit = 1000000;
            HashSet<int> maxChain = new HashSet<int>();
            Dictionary<int, int> sums = new Dictionary<int, int>();
            for (int n = 1; n < limit; n++)
                sums.Add(n, Common.GetSumOfDivisorsOf(n));

            for (int n = 2; n < limit; n++)
            {
                HashSet<int> chain = new HashSet<int> { n };
                int s = sums[n];
                while (s != n && s < limit && !chain.Contains(s))
                {
                    chain.Add(s);
                    s = sums[s];
                }

                if (s == n && chain.Count > maxChain.Count)
                    maxChain = chain;
            }

            return maxChain.Min().ToString();
        }
    }
}
