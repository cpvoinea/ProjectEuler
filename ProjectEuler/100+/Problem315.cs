namespace ProjectEuler
{
    class Problem315 : IProblem
    {
        int[][] mapping = new int[10][] {
            new int[]{1,1,1,0,1,1,1}, //0
            new int[]{0,0,1,0,0,1,0}, //1
            new int[]{1,0,1,1,1,0,1}, //2
            new int[]{1,0,1,1,0,1,1}, //3
            new int[]{0,1,1,1,0,1,0}, //4
            new int[]{1,1,0,1,0,1,1}, //5
            new int[]{1,1,0,1,1,1,1}, //6
            new int[]{1,1,1,0,0,1,0}, //7
            new int[]{1,1,1,1,1,1,1}, //8
            new int[]{1,1,1,1,0,1,1}  //9
        };
        int[] cost = new int[] { 6, 2, 5, 5, 4, 5, 6, 4, 7, 6 };

        int Cost(int n) // or
        {
            int s = 0;
            while(n > 0)
            {
                s += cost[n % 10];
                n /= 10;
            }
            return s;
        }

        int DigitCostDif(int from, int to) // xor
        {
            int[] f = mapping[from];
            int[] t = mapping[to];
            int s = 0;
            for (int i = 0; i < 7; i++)
                if (f[i] != t[i])
                    s++;
            return s;
        }

        int CostDif(int from, int to)
        {
            int s = 0;
            while (to > 0)
            {
                s += DigitCostDif(from % 10, to % 10);
                from /= 10;
                to /= 10;
            }
            if (from > 0)
                s += Cost(from);
            return s;
        }

        int Root(int n)
        {
            int s = 0;
            while (n > 0)
            {
                s += n % 10;
                n /= 10;
            }
            return s;
        }

        public string GetResult()
        {
            const int limit = 20000000;
            var bPrimes = Common.GeneratePrimes(limit);
            int n = limit / 2;
            long s = 0;
            while (n < limit)
            {
                if (bPrimes[n])
                {
                    int max = Cost(n);
                    int sam = 2 * max;
                    int m = n;
                    int r = Root(m);
                    while (r >= 10)
                    {
                        sam += 2 * Cost(r);
                        max += CostDif(m, r);
                        m = r;
                        r = Root(m);
                    }
                    sam += 2 * Cost(r);
                    max += CostDif(m, r) + Cost (r);

                    s += sam - max;
                }
                n++;
            }
            return s.ToString();
        }
    }
}
