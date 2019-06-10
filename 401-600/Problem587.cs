using System;

namespace ProjectEuler
{
    class Problem587 : IProblem
    {
        public object GetResult()
        {
            double n = 0;
            double f1 = 1.0 - Math.PI / 4.0;
            double p = 100;
            while (p > 0.1)
            {
                n++;
                double x = (n * (Math.Sqrt(2 * n) - 1) + 1) / (n * n + 1);
                double f = (2 * x - x * Math.Sqrt(1 - x * x) - Math.Asin(x) + (1 - x) * (1 - x) / n) / 2;
                p = f * 100 / f1;
            }

            return n;
        }
    }
}