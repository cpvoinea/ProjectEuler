using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem073 : IProblem
    {
        public string GetResult()
        {
            HashSet<double> distinct = new HashSet<double>();
            for (int d = 2; d <= 12000; d++)
                for (int n = d / 3 + 1; n < d / 2; n++)
                {
                    distinct.Add(n * 1.0 / d);
                }
            return distinct.Count.ToString();
        }
    }
}
