using System;

namespace ProjectEuler
{
    class Problem037 : IProblem
    {
        public object GetResult()
        {
            int limit = 1000000;
            int s = 0;
            for (int i = 11; i < limit; i += 2)
            {
                if (Common.IsPrime(i))
                {
                    bool ok = true;
                    int n = i;
                    int c = 10;
                    while (n != 0)
                    {
                        int m = i % c;
                        n = i / c;
                        if (!Common.IsPrime(n) || !Common.IsPrime(m))
                        {
                            ok = false;
                            break;
                        }
                        c *= 10;
                    }

                    if (ok)
                    {
                        Console.WriteLine(i);
                        s += i;
                    }
                }
            }

            return s;
        }
    }
}
