using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem012 : IProblem
    {
        int D(Dictionary<int, int> powers)
        {
            int r = 1;
            foreach (int p in powers.Keys)
                r *= (powers[p] + 1);
            return r;
        }

        Dictionary<int, int> CorrectPowers(Dictionary<int, int> powers, int n, int dir)
        {
            for (int p = 2; p <= n; p++)
            {
                int c = 0;
                while (n % p == 0)
                {
                    n = n / p;
                    c++;
                }
                if (c > 0)
                {
                    if (powers.ContainsKey(p))
                        powers[p] += c * dir;
                    else
                        powers.Add(p, c);
                }
            }

            return powers;
        }

        long GetTriangleWithDivisorsMoreThan(int n)
        {
            int i = 1;
            Dictionary<int, int> powers = new Dictionary<int, int>();
            List<long> primes = new List<long>();
            primes.Add(2);
            int d = 1;
            while (d <= n)
            {
                int a = i + 2;
                int b = i;
                while (a % 2 == 0 && b % 2 == 0)
                {
                    a = a / 2;
                    b = b / 2;
                }
                powers = CorrectPowers(powers, a, 1);
                powers = CorrectPowers(powers, b, -1);
                i++;
                d = D(powers);
            }

            return i * (i + 1) / 2;
        }

        public object GetResult()
        {
            return GetTriangleWithDivisorsMoreThan(500);
        }
    }
}
