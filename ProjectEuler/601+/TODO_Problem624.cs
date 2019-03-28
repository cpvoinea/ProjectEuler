using System;
using System.Numerics;

namespace ProjectEuler
{
    class Problem624 : IProblem
    {
        public string GetResult()
        {
            // const int div = 1000000009;
            const long N = 1000000000000000000;
            var primes = Common.GetPrimeNumbersLowerThan(10000000);
            // P(n) = A(n) / B(n)
            // F(n) = F(n-1) + F(n-2), F(0)=1, F(1)=1
            // A(n) = 2^n*F(n)/2 - A(n-1), A(1)=1
            // B(n) = 2^n*(2^n-F(n)) - A(n)
            long n = 2;
            BigInteger a = 1;
            BigInteger b = 1;
            BigInteger f1 = 1, f2 = 2;
            BigInteger t = 2;
            while (n <= N)
            {
                a = t * f2 - a;
                t = 2 * t;
                b = t * (t - f2) - a;
                f2 = f1 + f2;
                f1 = f2 - f1;
                //foreach (int p in primes)
                //{
                //    if (p > a)
                //        break;
                //    if (a % p == 0 && b % p == 0)
                //    {
                //        Console.WriteLine("////" + p);
                //    }
                //}
                //a %= div;
                //b %= div;

                if (a % 23 == 0 && b % 23 == 0)
                    return n.ToString();

                n++;
            }

            return "";
        }
    }
}
