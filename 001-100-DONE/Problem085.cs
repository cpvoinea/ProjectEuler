using System;

namespace ProjectEuler
{
    class Problem085 : IProblem
    {
        public object GetResult()
        {
            // N = nm(n+1)(m+1)/4
            const int limit = 2000000;
            int maxDim = (int)(Math.Sqrt(2 * limit)) + 1;
            int minDif = limit;
            int minI = 0;
            int minJ = 0;
            for (int i = 1; i < maxDim; i++)
                for (int j = 1; j < maxDim; j++)
                {
                    int dif = Math.Abs(limit * 4 - i * (i + 1) * j * (j + 1));
                    if (dif < minDif)
                    {
                        minDif = dif;
                        minI = i;
                        minJ = j;
                    }
                }
            return (minI * minJ);
        }
    }
}
