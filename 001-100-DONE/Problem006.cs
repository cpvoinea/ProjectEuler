namespace ProjectEuler
{
    class Problem006 : IProblem
    {
        int GetDifferenceBetweenSquareOfSumAndSumOfSquaresOfFirst(int n)
        {
            int s = 0;
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= n; j++)
                    if (i != j)
                        s += i * j;
            return s;
        }

        // Better method
        int GetDifferenceBetweenSquareOfSumAndSumOfSquaresOfFirst(int n, bool better)
        {
            return n * (n + 1) * (3 * n * n - n - 2) / 12;
        }

        public object GetResult()
        {
            int n = 100;
            return GetDifferenceBetweenSquareOfSumAndSumOfSquaresOfFirst(n) + " Better method: " + GetDifferenceBetweenSquareOfSumAndSumOfSquaresOfFirst(n, true);
        }
    }
}
