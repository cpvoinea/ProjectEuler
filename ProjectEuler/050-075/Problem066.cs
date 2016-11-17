using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem066 : IProblem
    {
        class Fraction
        {
        }

        public string GetResult()
        {
            HashSet<short> candidates = new HashSet<short>();
            for (short i = 1; i <= 1000; i++)
                candidates.Add(i);
            for (short i = 1; i <= 31; i++)
                candidates.Remove((short)(i * i));

            foreach(short n in candidates)
            {
                short r = 1;
                while (r * r < n)
                    r++;
                r--;
            }

            return "";
        }
    }
}
