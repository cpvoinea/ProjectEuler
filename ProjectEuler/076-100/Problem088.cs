using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem088 : IProblem
    {
        public string GetResult()
        {
            const int limit = 12000;
            int[] min = new int[limit + 1];
            int[] factors = new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };

            int count = 13;
            while (count > 0)
            {
                int p = 1;
                for (int i = 0; i <= count; i++)
                    p *= factors[i];
                if (count == 0 && p > 2 * limit)
                    break;
                if (p > 2 * limit)
                {
                    p /= factors[count] * factors[count - 1];
                    factors[count - 1]++;
                    factors[count] = factors[count - 1];
                    p *= factors[count] * factors[count - 1];
                    if (p > 2 * limit)
                    {
                        p /= factors[count] * factors[count - 1];
                        factors[count] = 0;
                        count--;
                        factors[count] = 2;
                        p *= factors[count];
                    }
                }

                int s = 0;
                for (int i = 0; i <= count; i++)
                    s += factors[i];
                int k = p - s + count + 1;
                if (k >= 2 && k <= limit && (min[k] == 0 || p < min[k]))
                    min[k] = p;

                factors[count]++;
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
            return sum.ToString();
        }
    }
}
