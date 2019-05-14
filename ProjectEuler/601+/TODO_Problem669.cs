using System;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler
{
    class Problem669 : IProblem
    {
        const long limit = 99_194_853_094_755_497;
        static readonly long[] fibos = GetFibos(limit);

        static long[] GetFibos(long limit)
        {
            List<long> result = new List<long>();

            long a = 1, b = 1;
            while (a < limit)
            {
                long c = a + b;
                result.Add(c);
                a = b;
                b = c;
            }

            return result.ToArray();
        }

        static long[] Neighbours(long from, HashSet<long> path = null)
        {
            List<long> result = new List<long>();
            int i = fibos.Length - 1;
            while (i >= 0 && fibos[i] > from)
            {
                long d = fibos[i] - from;
                if (d <= limit && d != from && (path == null || !path.Contains(d)))
                    result.Add(d);
                i--;
            }

            return result.ToArray();
        }

        public string GetResult()
        {
            // for (int i = 0; i < fibos.Length; i++)
            //     Console.WriteLine(fibos[i]);
            const long place = 10_000_000_000_000_000;
            double phi = (Math.Sqrt(5) + 3) / 2;
            long f1 = 61305790721611591;
            long f2 = 99194853094755497;
            long max = f2 - place + 1;
            long j = 10;
            long ji = 0;
            long si = 1;
            long s = 2;

            long a = 0;
            long b = 1;
            int d = -1;
            int di = 2;
            for (int i = 2; i <= max; i++)
            {
                if (a > 0) a = -a;
                else a = 1 - a;

                if (di == 0) b = -b;
                else b = 1 - b;

                if (i == j - 1)
                {
                    di = 0;
                    d = 1;
                    if (ji == s)
                    {
                        si++;
                        s = (int)(si * phi);
                        j += 6;
                    }
                    else
                        j += 10;
                    ji++;
                }
                else
                {
                    di += d;
                    if (di < 0 || di > 2)
                    {
                        d = -d;
                        di = 1;
                    }
                }
            }

            BigInteger b1 = new BigInteger(a) * f1;
            BigInteger b2 = new BigInteger(b) * f2;
            BigInteger r = b1 + b2;

            return r.ToString();
        }
    }
}