namespace ProjectEuler
{
    class Problem071 : IProblem
    {
        public string GetResult()
        {
            double max = 0;
            int nmax = 0;
            int dmax = 0;
            for (int d = 2; d <= 1000000; d++)
            {
                int n = 3 * d - 1;
                if (n % 7 != 0)
                    continue;
                n = n / 7;
                double x = n * 1.0 / d;
                if (x > max)
                {
                    max = x;
                    nmax = n;
                    dmax = d;
                }
            }

            int i = 2;
            int nf = nmax;
            int df = dmax;
            while (i < nmax)
            {
                while (nf % i == 0 && df % i == 0)
                {
                    nf /= i;
                    df /= i;
                }
                i++;
            }

            return nf.ToString();
        }
    }
}
