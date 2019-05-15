using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Problem024 : IProblem
    {
        public object GetResult()
        {
            string r = "";
            int limit = 1000000;
            List<int> digits = Enumerable.Range(0, 10).ToList();
            for (int i = 0; i < 9; i++)
            {
                int f = Common.Fact(9 - i);
                int d = (limit - 1) / f;
                limit -= d * f;
                r += digits[d];
                digits.RemoveAt(d);
            }
            r += digits[0];

            return r;
        }
    }
}
