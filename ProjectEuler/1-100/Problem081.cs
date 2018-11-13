using System.IO;
using System.Linq;

namespace ProjectEuler
{
    class Problem081 : IProblem
    {
        int GetMin(int[][] matrix, int[,] min, int i, int j)
        {
            if (min[i, j] > 0)
                return min[i, j];
            if (i == 0 && j == 0)
                return matrix[0][0];
            int up = i > 0 ? GetMin(matrix, min, i - 1, j) : int.MaxValue;
            int left = j > 0 ? GetMin(matrix, min, i, j - 1) : int.MaxValue;
            int m = matrix[i][j] + (up < left ? up : left);
            min[i, j] = m;
            return m;
        }

        public string GetResult()
        {
            const int n = 80;
            int[][] matrix = File.ReadAllLines("Resources\\Problem081.txt")
                .Select((l, i) => l.Split(',').Select(s => int.Parse(s)).ToArray())
                .ToArray();
            int[,] min = new int[n, n];
            return GetMin(matrix, min, n - 1, n - 1).ToString();
        }
    }
}
