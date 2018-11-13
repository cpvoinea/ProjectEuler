using System;

namespace ProjectEuler
{
    class Problem009 : IProblem
    {
        int GetPythagoreanProductWithSum(int s)
        {
            int half = s / 2;
            int sqrt = (int)Math.Sqrt(half);
            for (int m = 2; m < sqrt; m++)
            {
                if (half % m == 0)
                {
                    int n = half / m - m;
                    if (m > n)
                    {
                        int a = m * m - n * n;
                        int b = 2 * m * n;
                        int c = m * m + n * n;
                        return a * b * c;
                    }
                }
            }
            return 0;
        }

        public string GetResult()
        {
            return GetPythagoreanProductWithSum(1000).ToString();
        }
    }
}
