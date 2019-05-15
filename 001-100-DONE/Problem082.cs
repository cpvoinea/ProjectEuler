using System;
using System.IO;
using System.Linq;

namespace ProjectEuler
{
    class Problem082 : IProblem
    {
        const int n = 80;

        int GetMin(int[][] matrix, int j, int k, int i)
        {
            if (k == i)
                return matrix[i][j - 1] + matrix[i][j];
            int m = int.MaxValue;
            int step = k < i ? 1 : -1;
            for (int move = 0; move <= Math.Abs(k - i); move++)
            {
                int right = 0;
                int s = 0;
                for (int t = k; t != i; t += step)
                {
                    if (move == Math.Abs(t - k))
                        right = 1;
                    s += matrix[t + step * (1 - right)][j - 1 + right];
                }
                if (s < m)
                    m = s;
            }
            return m + matrix[k][j - 1] + matrix[i][j];
        }

        public object GetResult()
        {
            int[][] matrix = File.ReadAllLines("Resources\\Problem082.txt")
                .Select((l, i) => l.Split(',').Select(s => int.Parse(s)).ToArray())
                .ToArray();
            //matrix = new int[][]
            //{
            //    new int[] {131,673,234,103,18},
            //    new int[] {201,96,342,965,150},
            //    new int[] {630,803,746,422,111 },
            //    new int[] {537,699,497,121,956},
            //    new int[]{805,732,524,37,331}
            //};
            int min = int.MaxValue;
            for (int j = 1; j < n; j++)
            {
                int[] jmin = new int[n];
                for (int i = 0; i < n; i++)
                {
                    int m = int.MaxValue;
                    for (int k = 0; k < n; k++)
                    {
                        int s = GetMin(matrix, j, k, i);
                        if (s < m)
                            m = s;
                    }
                    jmin[i] = m;
                }

                for (int i = 0; i < n; i++)
                    if (j == n - 1)
                    {
                        if (jmin[i] < min)
                            min = jmin[i];
                    }
                    else
                        matrix[i][j] = jmin[i];
            }

            return min;
        }
    }
}
