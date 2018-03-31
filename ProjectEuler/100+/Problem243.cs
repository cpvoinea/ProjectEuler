using System;
using System.Collections;

namespace ProjectEuler
{
    class Problem243 : IProblem
    {
        public string GetResult()
        {
            //15499/94744
            // https://en.wikipedia.org/wiki/Euler%27s_totient_function
            int n = 12;
            bool ok = false;
            while (!ok)
            {
                n++;
                BitArray a = new BitArray(n + 1);
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        int j = i;
                        while (j <= n)
                        {
                            a[j] = true;
                            j += i;
                        }
                    }
                }

                int c = 0;
                for (int i = 1; i < n; i++)
                    if (!a[i])
                        c++;
                ok = c * 94744L < (n - 1) * 15499L;
            }
            return n.ToString();
        }
    }
}
