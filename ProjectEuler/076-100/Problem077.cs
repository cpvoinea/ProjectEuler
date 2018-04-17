using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem077 : IProblem
    {
        public string GetResult()
        {
            List<int> primes = Common.GetPrimeNumbersLowerThan(100000000);
            int count = primes.Count;
            // http://mathworld.wolfram.com/EulerTransform.html
            Dictionary<int, int> c = new Dictionary<int, int>();
            Dictionary<int, int> b = new Dictionary<int, int>();
            b.Add(1, 0);
            c.Add(1, 0);
            int n = 1;
            while (b[n] < 5000)
            {
                n++;
                int i = 1;
                int p = primes[0];
                int s = 0;
                while (p <= n && i < count)
                {
                    if (n % p == 0)
                        s += p;
                    p = primes[i++];
                }
                c.Add(n, s);
                for (int k = 1; k < n; k++)
                    s += c[k] * b[n - k];
                b[n] = s / n;
            }

            return n.ToString();
        }
    }
}
