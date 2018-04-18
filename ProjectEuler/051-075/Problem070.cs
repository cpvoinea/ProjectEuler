using System;

namespace ProjectEuler
{
    class Problem070 : IProblem
    {
        bool IsPerm(int f, int n)
        {
            var fs = f.ToString().ToCharArray();
            var ns = n.ToString().ToCharArray();
            if (fs.Length < ns.Length)
                return false;
            Array.Sort(fs);
            Array.Sort(ns);
            return new string(fs) == new string(ns);
        }

        public string GetResult()
        {
            const int limit = 10000000;
            double min = limit;
            int minN = limit;
            for (int n = 2; n <= limit; n++)
            {
                int f = Common.Totient(n, 2, n, Common.GeneratePrimes(limit));

                if (IsPerm(f, n))
                {
                    double m = (double)n / f;
                    if (m < min)
                    {
                        min = m;
                        minN = n;
                    }
                }
            }

            return minN.ToString();
        }
    }
}
