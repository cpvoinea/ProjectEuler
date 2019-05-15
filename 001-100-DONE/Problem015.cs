namespace ProjectEuler
{
    class Problem015 : IProblem
    {
        long R(int n, int m)
        {
            if (n == 0 || m == 0)
                return 1;
            if (n == 1 || m == 1)
                return m + n;
            return R(n - 1, m - 1) * 2 + R(n, m - 2) + R(n - 2, m);
        }

        public object GetResult()
        {
            return R(20, 20);
        }
    }
}
