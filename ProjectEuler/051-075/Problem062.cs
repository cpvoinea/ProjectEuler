using System;
using System.Linq;

namespace ProjectEuler
{
    class Problem062 : IProblem
    {
        bool SameDigits(long i, long j)
        {
            char[] si = i.ToString().ToArray();
            char[] sj = j.ToString().ToArray();
            Array.Sort(si);
            Array.Sort(sj);
            return new string(si) == new string(sj);
        }

        public string GetResult()
        {
            const byte c = 5;
            const double step = 2.15443469003;
            double currentStep = step * step;
            long i = (long)currentStep + 1;
            while (i < 1000000)
            {
                currentStep *= step;
                long next = (int)currentStep + 1;
                while (i < next - c + 1)
                {
                    long first = i * i * i;
                    byte count = 1;
                    for (long j = i + 1; j < next; j++)
                    {
                        if (SameDigits(first, j * j * j))
                            count++;
                        if (count >= c)
                            break;
                    }
                    if (count == c)
                        return first.ToString();

                    i++;
                }

                i = next;
            }

            return "";
        }
    }
}
