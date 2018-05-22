using System.Text;

namespace ProjectEuler
{
    class Problem627 : IProblem
    {
        readonly int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
        const int m = 30;
        const int n = 2;
        const int mod = 1000000007;

        long MaxCount3(int[] powers)
        {
            int r4 = 0, r6 = 0, r30 = n;

            for (int j = primes.Length - 1; j > 2; j--)
                if (powers[j] > 0)
                {
                    int p1 = powers[j];
                    r30 -= p1;
                    if (r30 < 0)
                        return 0;

                    if (j == 3)
                        r4 += p1;
                }

            //5
            int p = powers[2];
            if (p > 0)
            {
                if (p > r30)
                {
                    r6 = 2 * r30 - p;
                    if (r6 < 0)
                        return 0;
                    r30 = 0;
                }
                else
                {
                    r30 -= p;
                    r6 = p;
                }
            }

            return r4 + r6 + r30 * 3 + 1;
        }

        long MaxCount2(int[] powers)
        {
            int r2 = 0, r3 = 0, r4 = 0, r6 = 0, r10 = 0, r30 = n;

            for (int j = primes.Length - 1; j > 2; j--)
                if (powers[j] > 0)
                {
                    int p1 = powers[j];
                    r30 -= p1;
                    if (r30 < 0)
                        return 0;

                    if (j < 6)
                    {
                        r2 += p1;
                        if (j == 3)
                            r4 += p1;
                    }
                }

            //5
            int p = powers[2];
            if (p > 0)
            {
                if (p > r30)
                {
                    r6 = 2 * r30 - p;
                    if (r6 < 0)
                        return 0;
                    r30 = 0;
                    p = 0;
                }
                else
                {
                    r30 -= p;
                    r6 = p;
                    p = 0;
                }
            }

            //3
            p = powers[1];
            if (p > 0 && r6 > 0)
            {
                if (r6 >= p)
                {
                    r6 -= p;
                    r2 += p;
                    p = 0;
                }
                else
                {
                    p -= r6;
                    r2 += r6;
                    r6 = 0;
                }
            }
            if (p > 0 && r30 > 0)
            {
                if (r30 >= p)
                {
                    r30 -= p;
                    r10 += p;
                    p = 0;
                }
                else
                {
                    p -= r30;
                    r10 += r30;
                    r30 = 0;
                }
            }
            if (p > 0 && r10 > 0)
            {
                while (p > 0 && r10 > 0)
                {
                    p--;
                    r10--;
                    r3++;
                    if (p == 0)
                        break;
                    p--;
                    r3--;
                }
            }
            if (p > 0 && r4 > 0)
            {
                if (p > r4)
                    return 0;
                r4 -= p;
                p = 0;
            }

            return r2 + r3 + r4 * 2 + r6 * 2 + r10 * 3 + r30 * 4 + 1;
        }

        long MaxCount(int i, int[] powers)
        {
            long max = 0;
            if (i >= 2)
            {
                int s = n;
                for (int j = i + 1; j < powers.Length; j++)
                    s -= powers[j];
                max = s * (i == 2 ? 2 : 1) + 1;
            }
            else if (i == 1)
                max = MaxCount3(powers);
            else
                max = MaxCount2(powers);

            return max;
        }

        string GetKey(int x, int[] powers)
        {
            StringBuilder sb = new StringBuilder();
            if (x < 10)
                sb.Append("0");
            sb.Append(x);
            foreach(int p in powers)
            {
                string s = p.ToString();
                for (int i = 0; i < 5 - s.Length; i++)
                    sb.Append("0");
                sb.Append(s);
            }
            return sb.ToString();
        }

        long Count(int i, int[] powers)
        {
            long max = MaxCount(i, powers);
            if (i == 0)
                return max;

            long c = 0;
            for (int j = 0; j < max; j++)
            {
                powers[i] = j;
                long x = Count(i - 1, powers);
                c = (c + x) % mod;
            }

            powers[i] = 0;
            return c;
        }

        public string GetResult()
        {
            return (Count(primes.Length - 1, new int[primes.Length]) % mod).ToString();
        }
    }
}
