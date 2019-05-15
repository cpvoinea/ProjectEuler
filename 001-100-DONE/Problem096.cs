using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectEuler
{
    class Problem096 : IProblem
    {
        bool Done(int[,] s)
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (s[i, j] == 0)
                        return false;
            return true;
        }

        int Sum(int[,] s)
        {
            return s[0, 0] * 100 + s[0, 1] * 10 + s[0, 2];
        }

        void Copy(int[,] s, int[,] d)
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    d[i, j] = s[i, j];
        }

        Dictionary<int, List<int>> Copy(Dictionary<int, List<int>> s)
        {
            Dictionary<int, List<int>> d = new Dictionary<int, List<int>>();
            foreach (var k in s.Keys)
                d.Add(k, new List<int>(s[k]));
            return d;
        }

        void RemoveCandidate(int[,] s, Dictionary<int, List<int>> candidates, int i, int j, int v)
        {
            var c = candidates[i * 10 + j];
            if (c.Contains(v))
                c.Remove(v);
        }

        void SetCell(int[,] s, Dictionary<int, List<int>> candidates, int i, int j, int v)
        {
            s[i, j] = v;
            candidates[i * 10 + j] = new List<int>();

            int x = 3 * (i / 3);
            int y = 3 * (j / 3);
            for (int k = 0; k < 9; k++)
            {
                if (k != j && s[i, k] == 0)
                    RemoveCandidate(s, candidates, i, k, v);

                if (k != i && s[k, j] == 0)
                    RemoveCandidate(s, candidates, k, j, v);

                int i1 = x + k / 3;
                int j1 = y + k % 3;
                if ((i1 != i || j1 != j) && s[i1, j1] == 0)
                    RemoveCandidate(s, candidates, i1, j1, v);
            }
        }

        int m;
        long cccc = 0;

        bool Solve(int[,] s, Dictionary<int, List<int>> candidates)
        {
            int max = 1;
            while (max <= 9)
            {
                if (max > m)
                    m = max;
                cccc++;
                int lastCount = 0;
                int count = 0;
                do
                {
                    lastCount = count;
                    for (int i = 0; i < 9; i++)
                        for (int j = 0; j < 9; j++)
                        {
                            if (s[i, j] == 0)
                            {
                                List<int> c = candidates[i * 10 + j];
                                if (c.Count == 0)
                                    return false;
                                if (c.Count == 1)
                                {
                                    SetCell(s, candidates, i, j, c[0]);
                                    count++;
                                }
                                else if (c.Count <= max)
                                {
                                    var c2 = Copy(candidates);
                                    foreach (int v in c2[i * 10 + j])
                                    {
                                        int[,] s1 = new int[9, 9];
                                        Copy(s, s1);
                                        var c1 = Copy(candidates);
                                        SetCell(s1, c1, i, j, v);
                                        if (Solve(s1, c1))
                                        {
                                            Copy(s1, s);
                                            return true;
                                        }

                                        c.Remove(v);
                                        count++;
                                    }
                                }
                            }
                        }
                    if (Done(s))
                        return true;
                }
                while (count > lastCount);
                max++;
            }

            return Done(s);
        }

        public object GetResult()
        {
            int sum = 0;
            var lines = File.ReadAllLines("Resources\\Problem096.txt");
            int l = 0;
            while (l < lines.Length)
            {
                Dictionary<int, List<int>> candidates = new Dictionary<int, List<int>>();
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                        candidates.Add(i * 10 + j, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

                int[,] s = new int[9, 9];
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        int v = lines[l + 1 + i][j] - 48;
                        if (v != 0)
                            SetCell(s, candidates, i, j, v);
                    }

                if (Solve(s, candidates))
                {
                    if (l == 0)
                    {
                        Console.WriteLine("{0} {1} {2}", lines[0], m, cccc);
                        for (int i = 0; i < 9; i++)
                        {
                            for (int j = 0; j < 9; j++)
                                Console.Write(s[i, j] + " ");
                            Console.WriteLine();
                        }
                    }
                    else
                        sum += Sum(s);
                }

                l += 10;
            }

            return sum;
        }
    }
}
