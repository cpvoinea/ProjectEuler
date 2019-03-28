using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Problem086 : IProblem
    {
        struct Triple
        {
            public long X;
            public long Y;
            public long Z;

            public Triple(long x, long y, long z)
            {
                X = x;
                Y = y;
                Z = z;
                Sort(ref X, ref Y, ref Z);
            }

            void Sort(ref long x, ref long y, ref long z)
            {
                if (x <= y && y <= z)
                    return;
                if (x > y)
                    Swap(ref x, ref y);
                if (y > z)
                    Swap(ref y, ref z);
                Sort(ref x, ref y, ref z);
            }

            void Swap(ref long x, ref long y)
            {
                long t = x;
                x = y;
                y = t;
            }

            public bool MinIsInt()
            {
                long m = Math.Min(X * X + (Y + Z) * (Y + Z), Math.Min(Y * Y + (X + Z) * (X + Z), Z * Z + (X + Y) * (X + Y)));
                long s = (long)Math.Sqrt(m);
                return m == s * s;
            }

            public bool Smaller(long limit)
            {
                return X <= limit && Y <= limit && Z <= limit;
            }

            public override bool Equals(object obj)
            {
                Triple t = (Triple)obj;
                return t.X == X && t.Y == Y && t.Z == Z;
            }

            public override int GetHashCode()
            {
                var hashCode = -307843816;
                hashCode = hashCode * -1521134295 + X.GetHashCode();
                hashCode = hashCode * -1521134295 + Y.GetHashCode();
                hashCode = hashCode * -1521134295 + Z.GetHashCode();
                return hashCode;
            }

            public override string ToString()
            {
                return $"{X} {Y} {Z}";
            }
        }

        HashSet<Triple> GeneratePythTriples(long limit)
        {
            HashSet<Triple> result = new HashSet<Triple>();
            long n = 1;
            long n2 = 1;
            while (n <= limit)
            {
                long m = n + 1;
                long m2 = m * m;
                while (m - n <= limit)
                {
                    long x = m2 - n2;
                    long y = 2 * m * n;
                    long z = m2 + n2;
                    long x2 = x, y2 = y, z2 = z;
                    while (y2 <= 2 * limit || x2 <= 2 * limit)
                    {
                        var t = new Triple(x2, y2, z2);
                        result.Add(t);
                        x2 += x;
                        y2 += y;
                        z2 += z;
                    }
                    m++;
                    m2 = m * m;
                }
                n++;
                n2 = n * n;
            }

            return result;
        }

        void AddSplit(HashSet<Triple> result, long x, long y, long limit)
        {
            if (y > limit)
                return;
            for (int i = 1; i <= x / 2; i++)
                if (i <= limit && x - i <= limit)
                {
                    Triple t = new Triple(i, x - i, y);
                    if (t.MinIsInt())
                        result.Add(t);
                }
        }

        HashSet<Triple> GenerateCubeSizes(HashSet<Triple> pyth, long limit)
        {
            HashSet<Triple> result = new HashSet<Triple>();
            foreach (Triple t in pyth)
            {
                AddSplit(result, t.X, t.Y, limit);
                AddSplit(result, t.Y, t.X, limit);
            }

            return result;
        }

        public string GetResult()
        {
            long limit = 3000;
            var pyth = GeneratePythTriples(limit);
            var cube = GenerateCubeSizes(pyth, limit);

            int n = 101;
            while (cube.Count(c => c.Smaller(n)) < 1000000)
                n++;
            return n.ToString();
        }
    }
}
