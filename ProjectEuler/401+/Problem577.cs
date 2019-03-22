namespace ProjectEuler
{
    class Problem577 : IProblem
    {
        long Triangle(int n)
        {
            return n * (n + 1) / 2;
        }

        long H(int n)
        {
            long sum = 0;
            for (int k = 1; 3 * k <= n; k++)
                sum += k * Triangle(n - 3 * k + 1);
            return sum;
        }

        public string GetResult()
        {
            const int limit = 12345;
            //return H(20).ToString();
            long sum = 0;
            for (int n = 3; n <= limit; n++)
                sum += H(n);

            return sum.ToString();
        }
    }
}
