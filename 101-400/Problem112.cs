namespace ProjectEuler
{
    class Problem112 : IProblem
    {
        bool IsBouncy(long n)
        {
            bool asc = true;
            bool desc = true;
            long i = n % 10;
            while (n >= 10 && (asc || desc))
            {
                n /= 10;
                long j = n % 10;
                if (asc && j > i)
                    asc = false;
                if (desc && j < i)
                    desc = false;
                i = j;
            }

            return !asc && !desc;
        }

        public object GetResult()
        {
            long n = 0;
            long count = 0;
            bool ok = false;
            while (!ok)
            {
                n++;
                if (IsBouncy(n))
                {
                    count++;
                    if (count * 100.0 / n >= 99)
                        ok = true;
                }
            }
            return n;
        }
    }
}
