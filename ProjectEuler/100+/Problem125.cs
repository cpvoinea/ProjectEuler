using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem125 : IProblem
    {
        public string GetResult()
        {
            const int limit = 10001;
            const int max = 100000000;
            int[] squares = new int[limit];

            for (int n = 1; n < limit; n++)
                squares[n] = n * n;

            int i = 1;
            long sum = 0;
            HashSet<int> p = new HashSet<int>();
            while (i <= limit - 2)
            {
                int j = i + 1;
                int n = squares[i] + squares[j];
                while (n <= max)
                {
                    if (!p.Contains(n) && Common.IsPalindrome(n.ToString()))
                    {
                        sum += n;
                        p.Add(n);
                    }
                    j++;
                    n += squares[j];
                }
                i++;
            }

            return sum.ToString();
        }
    }
}
