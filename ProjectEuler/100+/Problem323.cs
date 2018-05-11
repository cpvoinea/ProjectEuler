namespace ProjectEuler
{
    class Problem323 : IProblem
    {
        public string GetResult()
        {
            // N = (1-n)/2^n + sum(S(k))
            // S(k) = Comb(n+k-1, k)/2^kn
            // sum(S(k)) = 1 / (1 - 1/2^n)^n
            const int n = 32;
            double r = 1.0 / n;
            double s = r;
            double a = 32 * 33;
            double t = r * r;
            int i = 2;
            while (t > 0)
            {
                s += a * t;
                a *= (n + i) / i;
                t *= r;
                i++;
            }

            s = 64;
            r = 34;
            for (int k = 0; k < 27; k++)
            {
                r /= 2;
            }

            return (s + r).ToString();
        }
    }
}
