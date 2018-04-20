namespace ProjectEuler
{
    class Problem092 : IProblem
    {
        int Sum(int n)
        {
            int s = 0;
            while (n > 0)
            {
                int i = n % 10;
                s += i * i;
                n /= 10;
            }

            return s;
        }

        public string GetResult()
        {
            int n = 1;
            int count = 0;
            while (n < 10000000)
            {
                int s = Sum(n);
                while (s != 1 && s != 89)
                    s = Sum(s);
                if (s == 89)
                    count++;
                n++;
            }

            return count.ToString();
        }
    }
}
