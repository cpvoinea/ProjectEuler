namespace ProjectEuler
{
    class Problem091 : IProblem
    {
        public string GetResult()
        {
            const int n = 50;
            int c = 0;
            for (int x1 = 0; x1 <= n; x1++)
                for (int y1 = 0; y1 <= n; y1++)
                {
                    if (x1 == 0 && y1 == 0)
                        continue;
                    int d1 = x1 * x1 + y1 * y1;
                    for (int x2 = 0; x2 <= n; x2++)
                        for (int y2 = 0; y2 <= n; y2++)
                        {
                            if (x2 == x1 && y2 == y1 || x2 == 0 && y2 == 0)
                                continue;
                            int d2 = x2 * x2 + y2 * y2;
                            int x3 = x1 - x2;
                            int y3 = y1 - y2;
                            int d3 = x3 * x3 + y3 * y3;

                            if (d1 + d2 - d3 == 0)
                                c++;
                            if (d1 + d3 - d2 == 0)
                                c++;
                            if (d2 + d3 - d1 == 0)
                                c++;
                        }
                }
            return (c / 2).ToString();
        }
    }
}
