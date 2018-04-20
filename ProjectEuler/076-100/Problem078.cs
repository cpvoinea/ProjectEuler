using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler
{
    class Problem078 : IProblem
    {
        public string GetResult()
        {
            const int div = 1000000;
            Dictionary<int, BigInteger> b = new Dictionary<int, BigInteger> { { 1, 1 } };
            Dictionary<int, int> c = new Dictionary<int, int> { { 1, 1 } };
            int n = 1;
            while (n < int.MaxValue - 10)
            {
                n++;
                BigInteger sb = 0;
                int sc = n;
                for (int k = 1; k < n; k++)
                {
                    if (n % k == 0)
                        sc += k;
                    sb += c[k] * b[n - k];
                }
                sb = (sb + sc) / n;
                if (sb % div == 0)
                    return n.ToString();
                b.Add(n, sb);
                c.Add(n, sc);
            }

            return "N/A";
        }
    }
}
