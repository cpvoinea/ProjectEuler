using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler
{
    class Problem169 : IProblem
    {
        Dictionary<string, long> counts = new Dictionary<string, long>();

        string GetKey(int[] a, int from)
        {
            int length = 0;
            for (int i = 0; i <= from; i++)
                if (a[i] > 0)
                    length = i + 1;
            string k = "";
            for (int i = 0; i < length; i++)
                k += a[i];
            return k;
        }

        int[] Copy(int[] a)
        {
            int length = 0;
            for (int i = 0; i < a.Length; i++)
                if (a[i] > 0)
                    length = i + 1;
            int[] na = new int[length];
            for (int i = 0; i < length; i++)
                na[i] = a[i];
            return na;
        }

        long Count(int[] pow, int from)
        {
            string key = GetKey(pow, from);
            if (counts.ContainsKey(key))
                return counts[key];
            long c = 1;
            for (int i = from; i > 0; i--)
                if (pow[i] > 0)
                {
                    int[] np = Copy(pow);
                    np[i]--;
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (np[j] == 2)
                            break;
                        if (np[j] == 0)
                        {
                            np[j] = 2;
                            if (j == 0)
                                c++;
                            else
                                c += Count(np, j - 1);
                            np[j] = 0;
                        }
                        np[j]++;
                    }
                }

            counts[key] = c;
            return c;
        }

        public object GetResult()
        {
            BigInteger limit = 1000000;
            limit *= limit;
            limit *= limit;
            limit *= 10;
            //limit = 1000000;
            int[] pow = new int[84];
            while (limit > 0)
            {
                BigInteger n = 1;
                int p = 0;
                while (n <= limit / 2)
                {
                    n *= 2;
                    p++;
                }

                pow[p] = 1;
                limit -= n;
            }
            pow = Copy(pow);

            long count = Count(pow, pow.Length - 1);
            return count;
        }
    }
}
