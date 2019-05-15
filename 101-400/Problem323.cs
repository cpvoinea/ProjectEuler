using System;

namespace ProjectEuler
{
    class Problem323 : IProblem
    {
        public object GetResult()
        {
            const int n = 32;
            const int limit = 100;
            int m = 1;
            double s = 1;
            double e = 2;
            while (m < limit)
            {
                double d = (e - 1) / e;
                if (e == 0)
                    break;
                double dm = 1;
                for (int i = 0; i < n; i++)
                    dm *= d;
                s += 1 - dm;
                //Console.WriteLine(s);
                //Console.ReadKey();
                m++;
                e *= 2;
            }

            return s;
        }
    }
}
