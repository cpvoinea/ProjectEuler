namespace ProjectEuler
{
    class Problem073 : IProblem
    {
        public string GetResult()
        {
            const int limit = 12000;
            var primes = Common.GetPrimeNumbersLowerThan(limit);
            int count = 0;
            for (int x = 2; x <= limit; x++)
                for (int y = 2 * x + 1; y <= limit && y < 3 * x; y++)
                {
                    bool reduced = true;
                    for (int i = 0; primes[i] <= x / 2 + 1; i++)
                    {
                        int p = primes[i];
                        if (x % p == 0 && y % p == 0)
                        {
                            reduced = false;
                            break;
                        }
                    }
                    if (reduced)
                        count++;
                }
            return count.ToString();
        }
    }
}
