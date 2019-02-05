using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem622 : IProblem
    {
        const int s = 60;
        bool Check(long n, long current, int count)
        {
            if (count > s)
                return false;
            if (current == 2 && count > 0)
                return count == s;
            if (current <= n / 2)
                return Check(n, current * 2 - 1, count + 1);
            return Check(n, current * 2 - n, count + 1);
        }

        public string GetResult()
        {
            long max = (long)System.Math.Pow(2, s);
            long min = (long)System.Math.Sqrt(max);
            long m = max - 1;
            long sum = max;
            for (long i = 2; i <= min; i++)
                if (m % i == 0)
                {
                    long n = m / i + 1;
                    if (Check(n, 2, 0))
                        sum += n;
                    if (Check(i + 1, 2, 0))
                        sum += i + 1;
                }

            return sum.ToString();
        }
    }
}