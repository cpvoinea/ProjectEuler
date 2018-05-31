using System;
using System.Collections;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem093 : IProblem
    {
        double Oper(double left, double right, int op)
        {
            switch (op)
            {
                case 0: return left + right;
                case 1: return left - right;
                case 2: return left * right;
                case 3: return left / right;
                default: return 0;
            }
        }

        int[][] GetPerm(int[] c)
        {
            List<int[]> result = new List<int[]>();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (i != j)
                        for (int k = 0; k < 4; k++)
                            if (k != i && k != j)
                                for (int l = 0; l < 4; l++)
                                    if (l != i && l != j && l != k)
                                    {
                                        result.Add(new[] { c[i], c[j], c[k], c[l] });
                                        result.Add(new[] { c[i], c[j], c[l], c[k] });
                                    }
            return result.ToArray();
        }

        int[][] GetCandidates()
        {
            List<int[]> result = new List<int[]>();
            for (int i = 1; i <= 6; i++)
                for (int j = i + 1; j <= 7; j++)
                    for (int k = j + 1; k <= 8; k++)
                        for (int l = k + 1; l <= 9; l++)
                            result.Add(new[] { i, j, k, l });
            return result.ToArray();
        }

        double Evaluate(int[] p, int o1, int o2, int o3, int par)
        {
            switch (par)
            {
                case 0:
                    if (o2 > 1)
                    {
                        double e = Oper(p[1], p[2], o2);
                        if (o3 > 1)
                            return Oper(p[0], Oper(e, p[3], o3), o1);
                        else
                            return Oper(Oper(p[0], e, o1), p[2], o3);
                    }
                    else
                    {
                        double e = Oper(p[0], p[1], o1);
                        if (o3 > 1)
                            return Oper(e, Oper(p[2], p[3], o3), o2);
                        else
                            return Oper(Oper(e, p[2], o2), p[3], o3);
                    }
                case 1:
                    return Oper(Oper(p[0], p[1], o1), Oper(p[2], p[3], o3), o2);
                case 2:
                    if (o3 > 1)
                        return Oper(Oper(p[0], p[1], o1), Oper(p[2], p[3], o3), o2);
                    else
                        return Oper(Oper(Oper(p[0], p[1], o1), p[2], o2), p[3], o3);
                case 3:
                    if (o2 > 1)
                        return Oper(p[0], Oper(p[1], Oper(p[2], p[3], o3), o2), o1);
                    else
                        return Oper(Oper(p[0], p[1], o1), Oper(p[2], p[3], o3), o2);
                case 4:
                    if (o3 > 1)
                        return Oper(p[0], Oper(Oper(p[1], p[2], o2), p[3], o3), o1);
                    else
                        return Oper(Oper(p[0], Oper(p[1], p[2], o2), o1), p[3], o3);
                case 5:
                    if (o2 > 1)
                        return Oper(Oper(p[0], Oper(p[1], p[2], o2), o1), p[3], o3);
                    else
                        return Oper(Oper(Oper(p[0], p[1], o1), p[2], o2), p[3], o3);
                case 6:
                    if (o3 > 1)
                        return Oper(p[0], Oper(p[1], Oper(p[2], p[3], o3), o2), o1);
                    else
                        return Oper(p[0], Oper(Oper(p[1], p[2], o2), p[3], o3), o1);
                default: return 0;
            }
        }

        public string GetResult()
        {
            int max = 0;
            string cMax = "";
            int[][] candidates = GetCandidates();
            foreach (int[] c in candidates)
            {
                BitArray b = new BitArray(10000);
                int[][] perm = GetPerm(c);
                foreach (int[] p in perm)
                {
                    for (int o1 = 0; o1 < 4; o1++)
                        for (int o2 = 0; o2 < 4; o2++)
                            for (int o3 = 0; o3 < 4; o3++)
                                for (int par = 0; par < 7; par++)
                                {
                                    double e = Evaluate(p, o1, o2, o3, par);
                                    if (e > 0 && e - (int)e == 0)
                                        b[(int)e] = true;

                                    e = Evaluate(new[] { -p[0], p[1], p[2], p[3] }, o1, o2, o3, par);
                                    if (e > 0 && e - (int)e == 0)
                                        b[(int)e] = true;
                                }
                }

                int i = 1;
                while (b[i++]) ;
                if(i > max)
                {
                    max = i;
                    Array.Sort(c);
                    cMax = string.Format("{0}{1}{2}{3} {4}", c[0], c[1], c[2], c[3], max);
                }
            }

            return cMax;
        }
    }
}
