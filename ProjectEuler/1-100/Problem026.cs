using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem026 : IProblem
    {
        int GetCycleLength(int n)
        {
            int m = 1;
            List<int> numerators = new List<int>();
            while (m != 0)
            {
                if (numerators.Contains(m))
                    return numerators.Count - numerators.IndexOf(m);

                numerators.Add(m);
                m = (m * 10) % n;
            }

            return 0;
        }

        public string GetResult()
        {
            int cmax = 0;
            int nmax = 2;
            for (int i = 2; i < 1000; i++)
            {
                int c = GetCycleLength(i);
                if (c > cmax)
                {
                    cmax = c;
                    nmax = i;
                }
            }

            return nmax.ToString() + " " + cmax;
        }
    }
}
