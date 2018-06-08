using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem074 : IProblem
    {
        public string GetResult()
        {
            int[] fact = new int[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };
            int count = 0;
            for(int n = 1; n < 1000000; n++)
            {
                HashSet<int> chain = new HashSet<int>();
                int m = n;
                while (!chain.Contains(m))
                {
                    chain.Add(m);
                    int s = 0;
                    while(m > 0)
                    {
                        s += fact[m % 10];
                        m /= 10;
                    }
                    m = s;
                }
                if (chain.Count == 60)
                    count++;
            }

            return count.ToString();
        }
    }
}
