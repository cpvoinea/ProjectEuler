namespace ProjectEuler
{
    class Problem643 : IProblem
    {
        const int modulo = 1_000_000_007;
        const int limit = 1000000;//00000;

        public string GetResult()
        {
            var primes = Common.GeneratePrimes(limit);
            long s = 0;
            int n = limit / 2;
            while (n >= 2)
            {
                for (int i = 2; i <= n; i++)
                    s = (s + Common.Totient(i, 2, i, primes)) % modulo;
                n /= 2;
            }

            return s.ToString();
        }
    }
}