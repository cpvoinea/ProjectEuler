using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Problem068 : IProblem
    {
        void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        void CheckMagic(int[] c, List<string> list)
        {
            BitArray b = new BitArray(11);
            int s = 55;
            foreach (int x in c)
            {
                b[x] = true;
                s += x;
            }
            if (s % 5 > 0)
                return;
            s /= 5;
            int p = s - c[0] - c[c.Length - 1];
            if (p < 1 || p > 10 || b[p])
                return;
            b[p] = true;
            int min = p;
            int mini = c.Length - 1;
            for (int i = 0; i < c.Length - 1; i++)
            {
                p = s - c[i] - c[i + 1];
                if (p < 1 || p > 10 || b[p])
                    return;
                b[p] = true;
                if (p < min)
                {
                    min = p;
                    mini = i;
                }
            }
            for (int i = 1; i <= 10; i++)
                if (!b[i])
                    return;

            StringBuilder r = new StringBuilder();
            for (int i = 0; i < c.Length; i++)
            {
                int x = c[(i + mini) % c.Length];
                int y = c[(i + 1 + mini) % c.Length];
                int z = s - x - y;
                r.Append(z).Append(x).Append(y);
            }
            list.Add(r.ToString());
        }

        void CheckPerm(char[] c, List<string> list, int i, int j)
        {
            if (i == j)
            {
                CheckMagic(c.Select(x => x - 48).ToArray(), list);
                return;
            }
            for (int k = i; k <= j; k++)
            {
                Swap(ref c[i], ref c[k]);
                CheckPerm(c, list, i + 1, j);
                Swap(ref c[i], ref c[k]);
            }
        }

        public object GetResult()
        {
            string[] candidates = new[] { "98521", "97531", "97432", "96541", "87541", "86542", "95321", "86321", "85421", "76421", "75431", "65432", "54321" };
            List<string> magicList = new List<string>();
            foreach (string c in candidates)
                CheckPerm(c.ToCharArray(), magicList, 0, c.Length - 1);
            string max = "0";
            foreach (string c in magicList)
                if (Common.GreaterThanLargeInt(c, max))
                    max = c;
            return max;
        }
    }
}
