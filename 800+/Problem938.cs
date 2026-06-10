using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    public class Problem938 : IProblem
    {
        public object GetResult()
        {
            const int R = 24690;
            const int B = 12345;

            var P = new Dictionary<int, Dictionary<int, decimal>>();
            for (int r = 0; r <= R; r += 2)
            {
                decimal prr = 0, pbb = 0, prb = 0;
                P[r] = new Dictionary<int, decimal>();
                for (int b = 0; b <= B; b++)
                {
                    decimal n = ((decimal)r + b) * (r + b - 1);
                    if (r + b > 1)
                    {
                        prr = r * (r - 1) / n;
                        pbb = b * (b - 1) / n;
                        prb = 2 * r * b / n;
                    }

                    if (r == 0)
                        P[r][b] = 1;
                    else if (b == 0)
                        P[r][b] = 0;
                    else
                        P[r][b] = (prr * P[r - 2][b] + prb * P[r][b - 1]) / (1 - pbb);
                }
            }

            return Math.Round(P[R][B], 10);
        }
    }
}
