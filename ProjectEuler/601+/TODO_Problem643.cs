namespace ProjectEuler
{
    class Problem643 : IProblem
    {
        const int modulo = 1_000_000_007;
        const long limit = 100_000_000_000;

        public string GetResult()
        {
            var primes = Common.GeneratePrimes(limit, 10000);
            long s = 0;
            long n = limit / 2;
            while (n >= 2)
            {
                for (int i = 2; i <= n; i++)
                    s = (s + Common.Totient(i, 2, i, primes, (int)(limit / 10000))) % modulo;
                n /= 2;
            }

            return s.ToString();
        }
    }
}