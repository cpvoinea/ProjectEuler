using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem088 : IProblem
    {
        public string GetResult()
        {
            HashSet<int> num = new HashSet<int>();
            for(int k = 2; k <= 12000; k++)
            {
                int min = int.MaxValue;
                int b = 2;
                while (b <= k)
                {
                    int p = 1;
                    int e = b;
                    while (e <= k + p * (b - 1) && p <= k)
                    {
                        if ((k + p * (b - 1) - 1) % (e - 1) == 0)
                        {
                            int s = e * (k + p * (b - 1) - 1) / (e - 1);
                            if (s < min)
                                min = s;
                        }
                        p++;
                        e *= b;
                    }
                    b++;
                }

                if (!num.Contains(min))
                    num.Add(min);
            }

            long sum = 0;
            foreach (int n in num)
                sum += n;

            return sum.ToString();
        }
    }
}
