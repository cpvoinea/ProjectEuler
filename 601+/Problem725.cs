namespace ProjectEuler
{
    class Problem725 : IProblem
    {
        int Ds(int n)
        {
            int s = 0;
            while (n > 0)
            {
                s += n % 10;
                n /= 10;
            }
            return s;
        }

        bool HasD(int n, int d)
        {
            while(n > 0)
            {
                if (n % 10 == d)
                    return true;
                n /= 10;
            }
            return false;
        }

        bool IsDs(int n)
        {
            int s = Ds(n);
            if (s > 18 || s % 2 == 1)
                return false;
            return HasD(n, s / 2);
        }

        public object GetResult()
        {
            int n = 1;
            double sum = 0;
            double d = 1;

            for (int k = 1; k < 10; k++)
            {
                long s = 0;
                for (int i = n; i < n * 10; i++)
                {
                    if (IsDs(i))
                        s += i;
                }
                sum += s;
                System.Console.WriteLine($"{k} {sum/d/(k-1)}");
                n *= 10;
                d = d * 10 + 1;
            }

            return 0;
        }
    }
}
