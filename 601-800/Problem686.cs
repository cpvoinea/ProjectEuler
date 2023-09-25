using System;
using System.Text;

namespace ProjectEuler
{
    class Problem686 : IProblem
    {
        string Multiply(string n, int b)
        {
            StringBuilder result = new StringBuilder();
            int r = 0;
            for (int i = n.Length - 1; i >= 0; i--)
            {
                int d = (n[i] - '0') * b + r;
                result.Insert(0, (d % 10).ToString());
                r = d / 10;
            }
            if (r > 0)
                result.Insert(0, r);
            string s = result.ToString();
            return s;
        }

        public object GetResult() // 193060223
        {
            const int COUNT = 678910;
            const int ROUND = 30;

            string n = "1";
            for (int i = 0; i < 30; i++)
                n = Multiply(n, 8);
            int count = 1;
            long pow = 90;

            //int step = COUNT / 10;
            //int progress = 0;
            while (count < COUNT)
            {
                string next = n;
                for (int i = 0; i < 65; i++)
                    next = Multiply(next, 8);
                next = Multiply(next, 2);
                if(next.StartsWith("123"))
                {
                    count++;
                    pow += 196;
                    n = next.Substring(0, ROUND);
                }
                else
                {
                    for (int i = 0; i < 31; i++)
                        next = Multiply(next, 8);
                    if(next.StartsWith("123"))
                    {
                        count++;
                        pow += 289;
                        n = next.Substring(0, ROUND);
                    }
                    else
                    {
                        for (int i = 0; i < 65; i++)
                            next = Multiply(next, 8);
                        next = Multiply(next, 2);
                        count++;
                        pow += 485;
                        n = next.Substring(0, ROUND);
                    }
                }

                //if (count % step == 0)
                //{
                //    progress++;
                //    Console.Write(10 - progress);
                //}
            }
            //Console.WriteLine();

            return pow;
        }
    }
}
