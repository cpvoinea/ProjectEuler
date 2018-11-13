namespace ProjectEuler
{
    class Problem206 : IProblem
    {
        bool Check(long n)
        {
            int i = 8;
            long m = n;
            while (i > 1)
            {
                if (m % 10 != i)
                    return false;
                m /= 100;
                i--;
            }
            return true;
        }

        public string GetResult()
        {
            for (int n = 10000001; n < 14000000; n++)
            {
                long m = n * 10 + 3;
                if (Check(m * m / 100))
                    return (m * 10).ToString();
                m = n * 10 + 7;
                if (Check(m * m / 100))
                    return (m * 10).ToString();
            }
            return "NONE";
        }
    }
}
