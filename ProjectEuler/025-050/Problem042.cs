using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ProjectEuler
{
	class Problem042 : IProblem
	{
        public string GetResult()
        {
            int limit = 33;
            List<int> triangleNumbers = new List<int>();
            for (int i = 0; i < limit; i++)
                triangleNumbers.Add(i * (i + 1) / 2);
            int count = 0;
            string[] words = Common.GetTextFromFile("Problem042.txt").Split(',').Select(w => w.Trim('"')).ToArray();
            foreach (string w in words)
            {
                int s = 0;
                foreach (char c in w)
                    s += c - 64;
                if (triangleNumbers.Contains(s))
                    count++;
            }

            return count.ToString();
        }
	}
}
