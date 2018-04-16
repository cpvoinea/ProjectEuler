
using System.Numerics;

namespace ProjectEuler
{
    class Problem080 : IProblem
    {
        long RootSum(BigInteger r, BigInteger d, int c)
        {
            if (c == 0)
                return 0;
            BigInteger n = d * 100;
            BigInteger m = r * 20;
            int i = 0;
            while ((m + i) * i < n)
                i++;
            i--;
            return i + RootSum(r * 10 + i, n - ((m + i) * i), c - 1);
        }

        public string GetResult()
        {
            int i = 1;
            int i2 = 1;
            int i3 = 4;
            int n = 2;
            long s = 0;
            while (i < 10)
            {
                s += i + RootSum(new BigInteger(i), new BigInteger(n - i2), 99);
                n++;
                if (n == i3)
                {
                    i++;
                    i2 = i3;
                    i3 = (i + 1) * (i + 1);
                    n++;
                }
            }

            return s.ToString();
        }
    }
}
