using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Problem049 : IProblem
    {
        bool IsPermutation(int n, int m)
        {
            string sn = n.ToString();
            string sm = m.ToString();
            foreach (char c in sm)
            {
                int i = sn.IndexOf(c);
                if (i >= 0)
                    sn = sn.Remove(i, 1);
                else
                    return false;
            }
            return sn.Length == 0;
        }

        public object GetResult()
        {
            int limit = 100000;
            List<int> primes = Common.GetPrimeNumbersLowerThan(limit).Where(n => n > 1000 && n < 10000).ToList();
            int c = primes.Count;
            for (int i = 0; i < c - 2; i++)
            {
                int p1 = primes[i];
                for (int j = i + 1; j < c - 1; j++)
                {
                    int p2 = primes[j];
                    if (IsPermutation(p1, p2))
                    {
                        int p3 = 2 * p2 - p1;
                        if (primes.Contains(p3) && IsPermutation(p2, p3) && p1 != 1487)
                            return p1.ToString() + p2 + p3;
                    }
                }
            }

            return "nope";
        }
    }
}
