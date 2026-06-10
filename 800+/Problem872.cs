using System;
using System.Linq;

namespace ProjectEuler
{
    public class Problem872 : IProblem
    {
        public object GetResult()
        {
            long n = 100_000_000_000_000_000;
            long k = 9 * 9 * 9 * 9 * 9 * 9 * 9 * 9 * 9;
            k = k * 9 * 9 * 9 * 9 * 9 * 9 * 9 * 9;
            long d = n - k;
            var sn = new string(Convert.ToString(d, 2).Reverse().ToArray());
            long s = n;
            long p = 1;
            for (int i = 0; i < sn.Length; i++)
            {
                if (sn[i] - '0' == 1)
                {
                    n = n - p;
                    s += n;
                }
                p *= 2;
            }

            return s;
        }
    }
}
