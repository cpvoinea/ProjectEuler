using System;

namespace ProjectEuler
{
    class Problem080 : IProblem
    {
        public string GetResult()
        {
            int sum = 0;
            for (int n = 2; n < 100; n++)
            {
                double s = Math.Sqrt(n);
                for (int i = 0; i < 100; i++)
                {
                    s = (s - (int)s) * 10;
                    int j = (int)s;
                    sum += j;
                    s -= j;
                }
            }

            return sum.ToString();
        }
    }
}
