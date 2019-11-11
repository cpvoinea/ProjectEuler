using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ProjectEuler
{
    class Node
    {
        public int value;
        public bool left;
        public bool right;

        public Node(int value)
        {
            this.value = value;
            left = true;
            right = true;
        }
    }

    class Problem067 : IProblem
    {
        Dictionary<Node, int> maxSums = new Dictionary<Node, int>();

        #region old
        int GetTriangleMaxSumRec(List<Node[]> lines, int currentLine, int currentPos)
        {
            Node n = lines[currentLine][currentPos];
            if (maxSums.ContainsKey(n))
                return maxSums[n];

            int s = n.value;
            if (!n.left && !n.right)
                return s;

            int l = n.left ? GetTriangleMaxSumRec(lines, currentLine + 1, currentPos) : 0;
            int r = n.right ? GetTriangleMaxSumRec(lines, currentPos + 1, currentPos + 1) : 0;
            s += l > r ? l : r;
            maxSums.Add(n, s);
            return s;
        }

        int GetTriangleMaxSum(List<Node[]> lines, bool dummy)
        {
            for (int l = 0; l < lines.Count - 1; l++)
                for (int p = 0; p <= l; p++)
                    if (lines[l + 1][p].value < lines[l + 1][p + 1].value)
                        lines[l + 1][p].right = false;
                    else
                        lines[l + 1][p + 1].left = false;

            return GetTriangleMaxSumRec(lines, 0, 0);
        }
        #endregion

        int GetTriangleMaxSum(List<int[]> lines)
        {
            int max = 0;
            for (int i = 0; i < lines.Count; i++)
            {
                int s = lines[lines.Count - 1 - i][0];
                int current = i;
                for (int j = lines.Count - 2; j >= 0; j--)
                {
                    int l = current == 0 ? 0 : lines[j][current - 1];
                    int r = current > j ? 0 : lines[j][current];
                    if (l > r)
                    {
                        s += l;
                        current--;
                    }
                    else
                        s += r;
                }
                if (s > max)
                    max = s;
            }
            return max;
        }

        public object GetResult()
        {
            List<int[]> lines = new List<int[]>();
            using (StreamReader sr = File.OpenText("Resources\\Problem067.txt"))
                while (!sr.EndOfStream)
                    lines.Add(sr.ReadLine().Split().Select(s => int.Parse(s)).ToArray());

            return GetTriangleMaxSum(lines);
        }
    }
}
