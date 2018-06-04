namespace ProjectEuler
{
    class Problem628 : IProblem
    {
        public string GetResult()
        {
            const long mod = 1008691207;
            const long limit = 100000000;
            long n = 3;
            long s = 2;
            long f = 2;
            long fact = 6;
            while (n < limit)
            {
                long nextS = (s + (n - 1) * fact) % mod;
                f = (f + nextS + 2 * (mod - s)) % mod;
                s = nextS;
                n++;
                fact = (fact * n) % mod;
            }

            return f.ToString();
        }
    }
}
