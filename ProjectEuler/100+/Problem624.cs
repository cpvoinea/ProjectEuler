using System;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler
{
    class Problem624 : IProblem
    {
        Dictionary<long, BigInteger> f = new Dictionary<long, BigInteger>();
        Dictionary<long, BigInteger> q = new Dictionary<long, BigInteger>();
        Dictionary<long, BigInteger> p = new Dictionary<long, BigInteger>();

        BigInteger F(long n)
        {
            if (n < 2)
                return 1;
            if (f.ContainsKey(n))
                return f[n];
            BigInteger x = F(n - 1) + F(n - 2);
            f.Add(n, x);
            return x;
        }

        BigInteger Q(long n)
        {
            if (n == 2)
                return 1;
            if (n == 3)
                return 4;
            if (q.ContainsKey(n))
                return q[n];
            BigInteger x = Q(n - 1) + Q(n - 2) + P(n - 2);
            q.Add(n, x);
            return x;
        }

        BigInteger P(long n)
        {
            if (n == 1)
                return 2;
            if (p.ContainsKey(n))
                return p[n];
            BigInteger x = 2 * P(n - 1);
            p.Add(n, x);
            return x;
        }

        public string GetResult()
        {
            const int div = 1000000009;
            const long n = 1000000000000000000;
            var primes = Common.GetPrimeNumbersLowerThan(10000000);
            // P(n) = A(n) / B(n)
            // F(n) = F(n-1) + F(n-2)
            // Q(n) = Q(n-1) + Q(n-2) + 2^(n-2)
            // A(n) = F(2n-2) + F(n-2)*Q(n)
            // B(n) = (-1)^n + 2^n*Q(n)
            long x = 2;
            int i = 1;
            while (true)
            {
                BigInteger a = Q(x);
                BigInteger A = F(x * 2 - 2) + F(x - 2) * a;
                BigInteger B = i + P(x) * a;

                Console.WriteLine("{0}: {1} / {2}", x, A, B);
                foreach (int pr in primes)
                {
                    if (pr > A)
                        break;
                    if (A % pr == 0 && B % pr == 0)
                        Console.WriteLine("///" + pr);
                }

                i = -i;
                x++;
                Console.ReadKey();
            }
        }
    }
}
