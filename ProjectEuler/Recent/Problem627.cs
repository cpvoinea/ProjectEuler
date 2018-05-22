namespace ProjectEuler
{
    class Problem627 : IProblem
    {
        readonly int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
        const int m = 30;
        const int n = 2;
        const int mod = 1000000007;

        int GetMaxSlots(int[] powers, int r2, int r4, int r30)
        {
            int p2 = powers[0], p3 = powers[1], p5 = powers[2];

            return r30;
        }

        int GetMax(int i, int[] powers)
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

            if (i > 2)
                return GetMaxSlots(powers, r2, r4, r30);

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

            //3
            p = powers[1];
            if (p > 0 && r6 > 0)
            {
                if (r6 >= p)
                {
                    r6 -= p;
                    r2 += p;
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
            }

            return r2 + r3 + r4 * 2 + r6 * 2 + r10 * 3 + r30 * 4 + 1;
        }

        static int[] Copy(int[] array)
        {
            int[] result = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
                result[i] = array[i];
            return result;
        }

        int Count(int i, int emptySlots, int[] remainders)
        {
            int c = 0;
            int p = primes[i];
            int x = p;
            while (x <= m)
            {
                c++;
                x *= p;
            }
            c *= emptySlots;
            for (int j = p; j < remainders.Length; j++)
            {
                int r = remainders[j];
                if (r > 0)
                {
                    x = p;
                    while (x <= j)
                    {
                        c += r;
                        x *= p;
                    }
                }
            }

            return c;
        }

        int MaxCount(int x, int[] powers)
        {
            int max = 0;
            int emptySlots = n;
            int[] remainders = new int[16];
            int i = powers.Length;
            while(--i >= 0)
            {
                while (powers[i] > 0)
                {
                    powers[i]--;
                    if (i > 2)
                    {
                        emptySlots--;
                        if (i > 3)
                            remainders[2]++;
                        else
                            remainders[4]++;
                    }


                }
            }

            return max;
        }

        long Count(int i, int[] powers)
        {
            int max = GetMax(i, powers);
            if (i == 0)
                return max;

            long c = 0;
            for (int j = 0; j < max; j++)
            {
                powers[i] = j;
                c = (c + Count(i - 1, powers)) % mod;
            }

            return c;
        }

        public string GetResult()
        {
            return (Count(primes.Length - 1, new int[primes.Length]) % mod).ToString();
        }
    }
}
