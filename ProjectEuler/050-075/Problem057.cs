using System;

namespace ProjectEuler
{
    class Problem057 : IProblem
    {
        struct Frac
        {
            internal string N;
            internal string D;
            internal Frac Next
            {
                get
                {
                    return new Frac
                    {
                        N = Common.AddLargeInt(Common.AddLargeInt(N, N), D),
                        D = N
                    };
                }
            }
        }

        public string GetResult()
        {
            int count = 0;
            Frac f = new Frac { N = "2", D = "1" };
            for(int i = 0; i < 1000; i++)
            {
                f = f.Next;
                if (Common.AddLargeInt(f.N, f.D).Length > f.N.Length)
                    count++;
            }

            return count.ToString();
        }
    }
}
