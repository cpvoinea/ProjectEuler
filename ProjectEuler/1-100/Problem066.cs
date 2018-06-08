using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem066 : IProblem
    {
        struct Fraction { internal string H; internal string K; }

        Fraction Calculate(Stack<double> s)
        {
            Fraction result = new Fraction { H = "0", K = "1" };
            foreach(double i in s)
            {
                if (result.H == "0")
                    result = new Fraction { H = i.ToString(), K = "1" };
                else
                    result = new Fraction
                    {
                        H = Common.AddLargeInt(Common.MultiplyLargeInt(result.H, i.ToString()), result.K),
                        K = result.H
                    };
            }

            return result;
        }

        bool IsSolution(Stack<double> s, double n)
        {
            var f = Calculate(s);
            var h = Common.MultiplyLargeInt(f.H, f.H);
            var k = Common.AddLargeInt(Common.MultiplyLargeInt(Common.MultiplyLargeInt(f.K, f.K), n.ToString()), "1");

            return h == k;
        }

        public string GetResult()
        {
            HashSet<double> candidates = new HashSet<double>();
            for (double i = 1; i <= 1000; i++)
                candidates.Add(i);
            for (double i = 1; i <= 31; i++)
                candidates.Remove(i * i);

            double nmax = 0;
            double max = 0;
            foreach (double n in candidates)
            {
                double up = 1;
                while (up * up < n)
                    up++;
                up--;
                Stack<double> vals = new Stack<double>();
                vals.Push(up);
                double down = n - up * up;
                while (!IsSolution(vals, n))
                {
                    up = down - up;
                    double i = 1;
                    while (up < 0 || up * up < n)
                    {
                        i++;
                        up += down;
                    }
                    i--;
                    up -= down;
                    down = (n - up * up) / down;
                    vals.Push(i);
                }

                var f = Calculate(vals);
                double v = double.Parse(f.H);
                if (v > max)
                {
                    max = v;
                    nmax = n;
                }
            }

            return nmax.ToString();
        }
    }
}
