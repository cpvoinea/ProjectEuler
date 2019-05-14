using System;
using System.IO;
using System.Linq;

namespace ProjectEuler
{
    class Problem099 : IProblem
    {
        bool GreaterThan(int b1, int e1, int b2, int e2)
        {
            if (b1 > b2 && e1 > e2)
                return true;
            if (b1 <= b2 && e1 <= e2)
                return false;
            return e1 * Math.Log(b1) > e2 * Math.Log(b2);
        }

        public string GetResult()
        {
            int[][] pairs = File.ReadAllLines("Resources\\Problem099.txt").Select(s => s.Split(',').Select(p => int.Parse(p)).ToArray()).ToArray();
            int maxi = 0;
            for (int i = 0; i < pairs.Length; i++)
            {
                if (GreaterThan(pairs[i][0], pairs[i][1], pairs[maxi][0], pairs[maxi][1]))
                    maxi = i;
            }
            return (maxi + 1).ToString();
        }
    }
}
