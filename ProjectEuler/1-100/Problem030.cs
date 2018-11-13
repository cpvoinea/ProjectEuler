using System;

namespace ProjectEuler
{
    class Problem030 : IProblem
    {
        public string GetResult()
        {
            int limit = 10 * (int)Math.Pow(9, 5) + 1;

            int s = 0;
            for (int i = 2; i <= limit; i++)
            {
                int n = i;
                int m = 0;
                while (n > 0)
                {
                    int d = n % 10;
                    n = n / 10;
                    m += (int)Math.Pow(d, 5);
                }
                if (m == i)
                {
                    Console.WriteLine(i);
                    s += i;
                }
            }

            return s.ToString();
        }
    }
}
