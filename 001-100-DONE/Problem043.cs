namespace ProjectEuler
{
    class Problem043 : IProblem
    {
        int[] primes = new int[] { 2, 3, 5, 7, 11, 13, 17 };

        void Swap(ref char a, ref char b)
        {
            if (a == b)
                return;
            a ^= b;
            b ^= a;
            a ^= b;
        }

        void Check(char[] n, int from, int to, ref long s)
        {
            if (from == to)
            {
                int m = (n[1] - 48) * 100 + (n[2] - 48) * 10 + n[3] - 48;
                int i = 0;
                bool ok = m % primes[i] == 0;
                while (ok && i < primes.Length - 1)
                {
                    i++;
                    m = (m % 100) * 10 + n[i + 3] - 48;
                    ok = m % primes[i] == 0;
                }

                if (ok)
                    s += long.Parse(new string(n));
            }
            else
            {
                for (int i = from; i <= to; i++)
                {
                    Swap(ref n[from], ref n[i]);
                    Check(n, from + 1, to, ref s);
                    Swap(ref n[from], ref n[i]);
                }
            }
        }

        public object GetResult()
        {
            long s = 0;
            Check(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }, 0, 9, ref s);

            return s;
        }
    }
}
