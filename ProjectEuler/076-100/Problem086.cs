using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    class Problem086 : IProblem
    {
        const long limit = 100;

        BigInteger GetKey(long a, long b, long c)
        {
            if (b < c)
            {
                Console.WriteLine("{0} {1} {2}", a, b, c);
                return GetKey(a, c, b);
            }
            if (a < b)
            {
                Console.WriteLine("{0} {1} {2}", a, b, c);
                return GetKey(b, a, c);
            }
            BigInteger key = a;
            key = key * (limit + 1) + b;
            key = key * (limit + 1) + c;
            return key;
        }

        public string GetResult()
        {
            long c = 0;
            long c2 = 0;
            long n = 1;
            HashSet<BigInteger> keys = new HashSet<BigInteger>();
            while (n <= limit)
            {
                long n2 = n * n;
                long m = n + 1;
                while (m <= limit)
                {
                    long a = m * m - n2;
                    if (a > limit)
                        break;
                    long b = m * n;
                    if (b > limit)
                        break;
                    long k = limit / a;
                    for(int i = 1; i <= k; i++)
                    {
                        long a2 = i * a;
                        long s = i * b;
                        long s2 = 2 * s;
                        if (s > limit)
                            break;
                        if (s2 <= limit + 1)
                            c += s;
                        else
                            c += limit - s + 1;

                        for (int j = 1; j <= s; j++)
                            if (j <= limit && s2 - j <= limit)
                            {
                                keys.Add(GetKey(a2, j, s2 - j));
                                c2++;
                            }
                    }
                    m++;
                }
                n++;
            }

            return keys.Count.ToString() + " " + c + " " + c2;
        }
    }
}
