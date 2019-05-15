namespace ProjectEuler
{
    class Problem001 : IProblem
    {
        int GetMultipleOf3Or5SumLessThan(int n)
        {
            int s = 0;
            for (int i = 1; i < n; i++)
                if (i % 3 == 0 || i % 5 == 0)
                    s += i;
            return s;
        }

        // Better method
        int GetMultipleSumOf(int i, int n)
        {
            int maxFactor = n / i;
            return i * maxFactor * (maxFactor + 1) / 2;
        }

        int GetMultipleSumOfPair(int i, int j, int n)
        {
            return GetMultipleSumOf(i, n) + GetMultipleSumOf(j, n) - GetMultipleSumOf(i * j, n);
        }

        public object GetResult()
        {
            int n = 1000;
            return GetMultipleOf3Or5SumLessThan(n) + " Better method: " + GetMultipleSumOfPair(3, 5, n);
        }
    }
}
