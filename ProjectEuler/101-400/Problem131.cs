using System.Collections;

namespace ProjectEuler
{
    class Problem131 : IProblem
    {
        public string GetResult()
        {
            const int limit = 1000000;
            BitArray isPrime = Common.GeneratePrimes(limit);
            int n = 1;
            int count = 0;
            // p = (n+1)^3 - n^3
            while (n <= 576)
            {
                int p = 3 * n * (n + 1) + 1;
                if (isPrime[p])
                    count++;
                n++;
            }
            return count.ToString();
        }
    }
}
