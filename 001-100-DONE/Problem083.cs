using System.IO;
using System.Linq;

namespace ProjectEuler
{
    class Problem083 : IProblem
    {
        public object GetResult()
        {
            int n = 80;
            int[][] matrix = File.ReadAllLines("Resources\\Problem083.txt")
                .Select((l, i) => l.Split(',').Select(s => int.Parse(s)).ToArray())
                .ToArray();

            //matrix = new int[][]
            //{
            //    new int[] {131,673,234,103,18},
            //    new int[] {201,96,342,965,150},
            //    new int[] {630,803,746,422,111},
            //    new int[] {537,699,497,121,956},
            //    new int[] {805,732,524,37,331}
            //};
            //n = 5;

            // https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm
            int[,] dist = new int[n, n];
            int[,] prev = new int[n, n];
            bool[,] q = new bool[n, n];
            for (int x = 0; x < n; x++)
                for (int y = 0; y < n; y++)
                {
                    dist[x, y] = int.MaxValue;
                    prev[x, y] = -1;
                    q[x, y] = true;
                }
            dist[0, 0] = matrix[0][0];
            int c = n * n;
            while (c > 0)
            {
                int min = int.MaxValue;
                int xm = 0;
                int ym = 0;
                for (int x = 0; x < n; x++)
                    for (int y = 0; y < n; y++)
                        if (q[x, y])
                        {
                            int m = dist[x, y];
                            if (m < min)
                            {
                                min = m;
                                xm = x;
                                ym = y;
                            }
                        }
                q[xm, ym] = false;
                c--;

                int u = xm * 100 + ym;
                int v = dist[xm, ym];
                if (xm > 0 && q[xm - 1, ym])
                {
                    int alt = v + matrix[xm - 1][ym];
                    if (alt < dist[xm - 1, ym])
                    {
                        dist[xm - 1, ym] = alt;
                        prev[xm - 1, ym] = u;
                    }
                }
                if (xm < n - 1 && q[xm + 1, ym])
                {
                    int alt = v + matrix[xm + 1][ym];
                    if (alt < dist[xm + 1, ym])
                    {
                        dist[xm + 1, ym] = alt;
                        prev[xm + 1, ym] = u;
                    }
                }
                if (ym > 0 && q[xm, ym - 1])
                {
                    int alt = v + matrix[xm][ym - 1];
                    if (alt < dist[xm, ym - 1])
                    {
                        dist[xm, ym - 1] = alt;
                        prev[xm, ym - 1] = u;
                    }
                }
                if (ym < n - 1 && q[xm, ym + 1])
                {
                    int alt = v + matrix[xm][ym + 1];
                    if (alt < dist[xm, ym + 1])
                    {
                        dist[xm, ym + 1] = alt;
                        prev[xm, ym + 1] = u;
                    }
                }
            }

            return dist[n - 1, n - 1];
        }
    }
}
