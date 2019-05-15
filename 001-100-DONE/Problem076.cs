namespace ProjectEuler
{
    class Problem076 : IProblem
    {
        int Comb(int n, int m)
        {
            if (m == n)
                return 1;
            if (m > n)
                return 0;

            int S = 1;
            for (int i = 2; i <= m; i++)
                S += Comb(n - m, i);
            return S;
        }

        public object GetResult()
        {
            int S = 0;
            for (int i = 2; i <= 100; i++)
                S += Comb(100, i);
            return S;
        }
    }
}
