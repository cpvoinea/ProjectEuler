using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem021 : IProblem
    {
        Dictionary<int, int> cachedD = new Dictionary<int, int>();

        public object GetResult()
        {
            int s = 0;
            int limit = 10000;
            for (int i = 3; i < limit; i++)
            {
                int div1 = Common.GetSumOfDivisorsOf(i);
                if (div1 >= limit || div1 == i)
                    continue;
                if (!cachedD.ContainsKey(i))
                    cachedD.Add(i, div1);

                int div2 = 1;
                if (cachedD.ContainsKey(div1))
                    div2 = cachedD[div1];
                else
                {
                    div2 = Common.GetSumOfDivisorsOf(div1);
                    cachedD.Add(div1, div2);
                }

                if (div2 == i)
                    s += i;
            }

            return s;
        }
    }
}
