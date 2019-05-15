using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem088 : IProblem
    {
        const int limit = 12000;
        readonly int[] min = new int[limit + 1];

        int GetSum(int[] v)
        {
            int s = 0;
            for (int i = 0; i < v.Length; i++)
                s += v[i];
            return s;
        }

        int GetProd(int[] v)
        {
            int p = 1;
            for (int i = 0; i < v.Length; i++)
                p *= v[i];
            return p;
        }

        bool CheckFactors(int[] f)
        {
            int p = GetProd(f);
            if (p > 2 * limit)
                return false;
            int s = GetSum(f);
            int k = p - s + f.Length;
            if (k <= limit && k >= 2 && (min[k] == 0 || p < min[k]))
                min[k] = p;
            return true;
        }

        bool IterateFactors(int[] f, int i, int p)
        {
            if (p > 2 * limit)
                return false;
            if (i >= f.Length)
                return CheckFactors(f);
            else
                for (int n = 2; n <= limit; n++)
                {
                    f[i] = n;
                    if (!IterateFactors(f, i + 1, p * n))
                        return true;
                }
            return true;
        }

        public object GetResult()
        {
            for (int i = 2; i <= 14; i++)
            {
                int[] f = new int[i];
                IterateFactors(f, 0, 1);
            }

            HashSet<int> vals = new HashSet<int>();
            long sum = 0;
            for (int i = 2; i <= limit; i++)
            {
                int n = min[i];
                if (!vals.Contains(n))
                {
                    sum += n;
                    vals.Add(n);
                }
            }

            return sum;
        }
    }
}
