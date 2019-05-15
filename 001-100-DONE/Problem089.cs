using System.IO;

namespace ProjectEuler
{
    class Problem089 : IProblem
    {
        readonly int[] digit = new[] { 0, 1, 2, 3, 2, 1, 2, 3, 4, 2 };

        int MinLength(int n)
        {
            int l = 0;
            int c = 0;
            while (n > 0 && c < 3)
            {
                int i = n % 10;
                l += digit[i];
                n /= 10;
                c++;
            }
            return l + n;
        }

        int Parse(string s)
        {
            int n = 0;
            int i = 0;
            while (i < s.Length && s[i] == 'M')
            {
                n += 1000;
                i++;
            }
            if (i < s.Length - 1 && s[i] == 'C')
            {
                if (s[i + 1] == 'M')
                {
                    n += 900;
                    i += 2;
                }
                else if (s[i + 1] == 'D')
                {
                    n += 400;
                    i += 2;
                }
            }
            if (i < s.Length && s[i] == 'D')
            {
                n += 500;
                i++;
            }
            while (i < s.Length && s[i] == 'C')
            {
                n += 100;
                i++;
            }
            if (i < s.Length - 1 && s[i] == 'X')
            {
                if (s[i + 1] == 'C')
                {
                    n += 90;
                    i += 2;
                }
                else if (s[i + 1] == 'L')
                {
                    n += 40;
                    i += 2;
                }
            }
            if (i < s.Length && s[i] == 'L')
            {
                n += 50;
                i++;
            }
            while (i < s.Length && s[i] == 'X')
            {
                n += 10;
                i++;
            }
            if (i < s.Length - 1 && s[i] == 'I')
            {
                if (s[i + 1] == 'X')
                {
                    n += 9;
                    i += 2;
                }
                else if (s[i + 1] == 'V')
                {
                    n += 4;
                    i += 2;
                }
            }
            if (i < s.Length && s[i] == 'V')
            {
                n += 5;
                i++;
            }

            return n + s.Length - i;
        }

        public object GetResult()
        {
            int result = 0;
            using (StreamReader sr = new StreamReader("Resources\\Problem089.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    int n = Parse(s);
                    result += s.Length - MinLength(n);
                }
            }

            return result;
        }
    }
}
