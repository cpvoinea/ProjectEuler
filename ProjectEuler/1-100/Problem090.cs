using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    class Problem090 : IProblem
    {
        void GetComb(int n, int from, int[] v, List<int[]> result)
        {
            if (n >= 6)
            {
                int[] vc = new int[6];
                for (int i = 0; i < 6; i++)
                    vc[i] = v[i];
                result.Add(vc);
            }
            else
                for (int i = from; i < 10; i++)
                {
                    v[n] = i;
                    GetComb(n + 1, i + 1, v, result);
                }
        }

        bool Contains(int[] l, int v)
        {
            bool isSixOrNine = v == 6 || v == 9;
            for (int i = 0; i < 6; i++)
                if (l[i] == v || isSixOrNine && (l[i] == 6 || l[i] == 9))
                    return true;
            return false;
        }

        bool IsValid(int[] l, int[] r)
        {
            for(int i = 1; i < 10; i++)
            {
                int n = i * i;
                int dl = n / 10;
                int dr = n % 10;
                if (!(Contains(l, dl) && Contains(r, dr) || Contains(l, dr) && Contains(r, dl)))
                    return false;
            }
            return true;
        }

        string GetKey(int[] l, int[] r)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int i in l)
                sb.Append(i.ToString());
            foreach (int i in r)
                sb.Append(i.ToString());
            return sb.ToString();
        }

        public string GetResult()
        {
            List<int[]> comb = new List<int[]>();
            GetComb(0, 0, new int[6], comb);

            HashSet<string> c = new HashSet<string>();
            for (int i = 0; i < comb.Count; i++)
                for (int j = i; j < comb.Count; j++)
                    if (IsValid(comb[i], comb[j]))
                    {
                        string k = GetKey(comb[i], comb[j]);
                        if (!c.Contains(k))
                            c.Add(k);
                    }

            return c.Count.ToString();
        }
    }
}
