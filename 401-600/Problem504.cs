using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem504 : IProblem
    {
        Dictionary<int, int> vals = new Dictionary<int, int>();

        int GetInterior(int a, int b)
        {
            if (a < b)
                return GetInterior(b, a);
            int key = b * 1000 + a;
            if (vals.ContainsKey(key))
                return vals[key];

            double m = 1.0 * b / a + 0.0000001;
            int c = 0;
            double y = b;
            for (int i = 1; i < a; i++)
            {
                y -= m;
                c += (int)y;
            }

            vals.Add(key, c);
            return c;
        }

        public object GetResult()
        {
            const int l = 100;
            Dictionary<int, bool> squares = new Dictionary<int, bool>();
            for (int i = 1; i <= (l + 1) * (l + 1); i++)
                squares.Add(i * i, true);
            int count = 0;
            for (int a = 1; a <= l; a++)
                for (int b = 1; b <= l; b++)
                    for (int c = 1; c <= l; c++)
                        for (int d = 1; d <= l; d++)
                        {
                            int s = a + b + c + d - 3 + GetInterior(a, b) + GetInterior(b, c) + GetInterior(c, d) + GetInterior(d, a);
                            if (squares.ContainsKey(s))
                                count++;
                        }
            return count;
        }
    }
}
