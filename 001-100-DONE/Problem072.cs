namespace ProjectEuler
{
    class Problem072 : IProblem
    {
        public object GetResult()
        {
            const int limit = 1000000;
            long count = 0;
            for (int n = 2; n <= limit; n++)
                count += Common.Totient(n, 2, n, Common.GeneratePrimes(limit));

            return count;
        }
    }
}
