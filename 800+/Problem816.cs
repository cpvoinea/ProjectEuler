using System;

namespace ProjectEuler
{
    internal class Problem816 : IProblem
    {
        struct Point : IComparable<Point>
        {
            public long X { get; }
            public long Y { get; }

            public Point(long x, long y)
            {
                X = x;
                Y = y;
            }

            public int CompareTo(Point other)
                => X.CompareTo(other.X);
        }

        const long S0 = 290797;
        const long MOD = 50515093;
        const long N = 14;
        static readonly Point[] P = new Point[N];

        static long S(long s) => s * s % MOD;

        public object GetResult()
        {
            long s = S0;
            for (long i = 0; i < N; i++)
            {
                long next = S(s);
                P[i] = new Point(s, next);
                s = S(next);
            }

            Array.Sort(P);
            double min = SplitAndSolve(0, N - 1); //MinDistanceAcross(0, N - 1, long.MaxValue);
            return Math.Round(min, 9);
        }

        static double Distance(long from, long to)
        {
            double x = P[to].X - P[from].X;
            double y = P[to].Y - P[from].Y;
            return Math.Sqrt(x * x + y * y);
        }

        static double SplitAndSolve(long from, long to)
        {
            if (to - from == 1)
                return Distance(from, to);
            if (to - from == 2)
                return Math.Min(Distance(from, from + 1), Distance(from + 1, to));

            long mid = (to - from) / 2;
            double left = SplitAndSolve(from, from + mid);
            double right = SplitAndSolve(from + mid + 1, to);
            double min = Math.Min(left, right);
            return min;
        }

        static double MinDistanceAcross(long from, long to, double minSoFar)
        {
            long mid = (to - from) / 2;
            long left = from + mid;
            long right = from + mid + 1;
            double min = minSoFar;
            while (left >= from && P[right].X - P[left].X <= minSoFar)
            {
                while (right <= to && P[right].X - P[left].X <= minSoFar)
                {
                    double d = Distance(left, right);
                    if (d < min)
                        min = d;
                    right++;
                }
                left--;
                right = from + mid + 1;
            }

            return min;
        }
    }
}
