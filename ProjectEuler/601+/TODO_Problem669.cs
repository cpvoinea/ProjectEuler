using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem669 : IProblem
    {
        const long limit = 99194853094755497;
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
            const long place = 10000000000000000;
            foreach (long f in fibos)
                Console.Write("{0} ", f);
            const long start = 34; // 80250321908183544;
            long c = start;
            while (true)
            {
                var n = Neighbours(c);
                Console.Write("{0}: ", c);
                foreach (long x in n)
                    Console.Write("{0} ", x);
                Console.WriteLine();
                int i = int.Parse(Console.ReadLine());
                c = n[i];
            }

            return "".ToString();
        }
    }
}