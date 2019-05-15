using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Problem023 : IProblem
    {
        public object GetResult()
        {
            List<int> abundant = new List<int>();
            int limit = 28123;

            for (int i = 12; i <= limit; i++)
            {
                int d = Common.GetSumOfDivisorsOf(i);
                if (d > i)
                    abundant.Add(i);
            }

            List<int> all = Enumerable.Range(1, limit).ToList();
            DateTime start = DateTime.Now;
            for (int i = 0; i < abundant.Count; i++)
            {
                if (i % 100 == 0)
                {
                    Console.WriteLine(DateTime.Now.Subtract(start).TotalSeconds);
                    start = DateTime.Now;
                }
                for (int j = i; j < abundant.Count; j++)
                {
                    int n = abundant[i] + abundant[j];
                    if (n > limit)
                        break;
                    all.Remove(n);
                }
            }

            return all.Sum();
        }
    }
}
