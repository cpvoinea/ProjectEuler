namespace ProjectEuler
{
    class Problem381 : IProblem
    {
        int GetSum(int p)
        {
            int s = 1;
            for (int i = 2; i <= p - 5; i++)
                s = (s * i) % p;
            int f = s;
            for (int i = p - 4; i < p; i++)
            {
                f = (f * i) % p;
                s = (s + f) % p;
            }
            return s;
        }

        public object GetResult()
        {
            const int limit = 100000000;
            var primes = Common.GetPrimeNumbersLowerThan(limit);
            primes.Remove(2);
            primes.Remove(3);
            long sum = 0;
            // S(p) = 9 * (p-5)! mod p
            // (p-1)! = p-1 mod p https://en.wikipedia.org/wiki/Wilson%27s_theorem
            // x = (p-5)! mod p => 24x = -1 mod p
            // 24x + 1 = p^2
            foreach (long p in primes)
            {
                long x = (p * p - 1) / 24;
                sum += (x * 9) % p;
            }

            return sum;
        }
    }
}
