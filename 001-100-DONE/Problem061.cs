using System;
using System.Linq;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem061 : IProblem
    {
        readonly Dictionary<int, List<int>> _numbers = new Dictionary<int, List<int>>();

        public Problem061()
        {
            _numbers.Add(3, new List<int>());
            _numbers.Add(4, new List<int>());
            _numbers.Add(5, new List<int>());
            _numbers.Add(6, new List<int>());
            _numbers.Add(7, new List<int>());
            _numbers.Add(8, new List<int>());

            for (int i = 45; i <= 140; i++)
                _numbers[3].Add(i * (i + 1) / 2);
            for (int i = 32; i <= 99; i++)
                _numbers[4].Add(i * i);
            for (int i = 26; i < 81; i++)
                _numbers[5].Add(i * (3 * i - 1) / 2);
            for (int i = 23; i <= 70; i++)
                _numbers[6].Add(i * (2 * i - 1));
            for (int i = 21; i <= 63; i++)
                _numbers[7].Add(i * (5 * i - 3) / 2);
            for (int i = 19; i <= 58; i++)
                _numbers[8].Add(i * (3 * i - 2));
        }

        Dictionary<int, List<int>> GetCandidates(string firstDigits, params int[] exclude)
        {
            Dictionary<int, List<int>> result = new Dictionary<int, List<int>>();
            foreach (int i in _numbers.Keys)
                if (!exclude.Contains(i))
                    result.Add(i, _numbers[i].Where(n => n.ToString().StartsWith(firstDigits)).ToList());
            return result;
        }

        bool Find(ref List<int> current, List<int> keys)
        {
            if (current.Count == _numbers.Keys.Count)
                return current[0].ToString().StartsWith(current.Last().ToString().Substring(2, 2));
            int n = current.Last();
            var c = GetCandidates(n.ToString().Substring(2, 2), keys.ToArray());
            foreach (int k in c.Keys)
            {
                keys.Add(k);
                foreach (int next in c[k])
                {
                    current.Add(next);
                    if (Find(ref current, keys))
                        return true;
                    current.RemoveAt(current.Count - 1);
                }
                keys.Remove(k);
            }
            return false;
        }

        public object GetResult()
        {
            int k1 = 8;
            foreach (int n1 in _numbers[k1])
            {
                List<int> result = new List<int> { n1 };
                if (Find(ref result, new List<int> { k1 }))
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} {5}", result[0], result[1], result[2], result[3], result[4], result[5]);
                    return (result[0] + result[1] + result[2] + result[3] + result[4] + result[5]);
                }
            }

            return "";
        }
    }
}
