namespace ProjectEuler
{
    class Problem187 : IProblem
    {
        public string GetResult()
        {
            const int limit = 100000000;
            var prime = Common.GeneratePrimes(limit / 2);
            long c = 0;
            for (int i = 2; i <= limit / 2; i++)
                if (prime[i])
                {
                    for (int j = i; j <= limit / i; j++)
                        if (prime[j])
                            c++;
                }

            return c.ToString();
        }
    }
}
