using System;
using System.Collections;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem407 : IProblem
    {
        List<int> GetDivisors(int n)
        {
            List<int> div = new List<int>();
            int d = 2;
            while (d <= Math.Sqrt(n))
            {
                if (n % d == 0)
                {
                    div.Add(d);
                    int d2 = n / d;
                    if (d2 > d)
                        div.Add(d2);
                    else break;
                }
                d++;
            }
            div.Add(n);
            div.Sort();

            return div;
        }

        public string GetResult()
        {
            const int limit = 10_000_000;
            long sum = 0;
            BitArray hit = new BitArray(limit + 1);
            int a = limit;
            List<int> div = GetDivisors(a);
            while (a > 1)
            {
                var nextDiv = GetDivisors(a - 1);

                int count = 0;
                for (int i = div.Count - 1; i >= 0; i--)
                {
                    long n = div[i];
                    int j = 0;
                    while (j < nextDiv.Count && n * nextDiv[j] <= a)
                        j++;
                    while (j < nextDiv.Count)
                    {
                        long m = n * nextDiv[j];
                        if (m > limit)
                            break;
                        if (!hit[(int)m])
                        {
                            hit[(int)m] = true;
                            count++;
                        }
                        j++;
                    }
                }
                if (count > 0)
                    sum += count * a;

                a--;
                div = nextDiv;
                nextDiv = null;
            }
            for (int i = 2; i <= limit; i++)
                if (!hit[i])
                    sum++;

            return sum.ToString();
        }
    }
}