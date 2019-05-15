using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectEuler
{
    class Problem345 : IProblem
    {
        static long count = 0;

        string GetKey(BitArray v)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < 15; i++)
                s.Append(v[i] ? "1" : "0");
            return s.ToString();
        }

        int Sum(int n, BitArray v, int[][] matrix, Dictionary<string, int> sums)
        {
            string k = GetKey(v);
            if (n == 14)
                for (int i = 0; i < 15; i++)
                    if (v[i])
                        return sums[k] = matrix[n][i];
            if (sums.ContainsKey(k))
                return sums[k];

            int max = 0;
            for (int i = 0; i < 15; i++)
                if (v[i])
                {
                    v[i] = false;
                    int s = matrix[n][i] + Sum(n + 1, v, matrix, sums);
                    if (s > max)
                        max = s;
                    v[i] = true;
                    count++;
                }
            sums[k] = max;
            return max;
        }

        public object GetResult()
        {
            string[] lines = File.ReadAllLines("Resources\\Problem345.txt");
            int[][] matrix = new int[lines.Length][];
            int c = 0;
            foreach (string l in lines)
            {
                matrix[c] = new int[lines.Length];
                int j = 0;
                foreach (string n in l.Trim().Split())
                    if (!string.IsNullOrEmpty(n.Trim()))
                        matrix[c][j++] = int.Parse(n.Trim());
                c++;
            }

            BitArray v = new BitArray(15);
            v.SetAll(true);

            int sum = Sum(0, v, matrix, new Dictionary<string, int>());

            return sum;
        }
    }
}
