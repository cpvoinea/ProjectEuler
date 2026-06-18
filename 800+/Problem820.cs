namespace ProjectEuler
{
    public class Problem820 : IProblem
    {
        private static long ModPow(long baseNum, long exp, long mod)
        {
            long result = 1;
            baseNum = baseNum % mod;

            while (exp > 0)
            {
                // If exp is odd, multiply baseNum with result
                if ((exp & 1) == 1)
                    result = (result * baseNum) % mod;

                // exp must be even now, square the base
                baseNum = (baseNum * baseNum) % mod;
                exp >>= 1; // Divide exp by 2
            }
            return result;
        }

        public static int GetNthDecimalPure(long m, long n)
        {
            long remainder = ModPow(10, n - 1, m);
            int digit = (int)(remainder * 10 / m);

            return digit;
        }

        public object GetResult()
        {
            const int n = 10_000_000;

            int s = 0;
            for (int i = 1; i <= n; i++)
            {
                int p2 = 0, p5 = 0;
                int m = i;
                while (m % 2 == 0)
                {
                    p2++;
                    m /= 2;
                }
                while (m % 5 == 0)
                {
                    p5++;
                    m /= 5;
                }
                int p = p2 > p5 ? p2 : p5;

                if (m == 1)
                    continue;

                s += GetNthDecimalPure(i, n);
            }

            return s;
        }
    }
}
