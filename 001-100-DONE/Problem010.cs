namespace ProjectEuler
{
    class Problem010 : IProblem
    {
        long GetPrimeSumBelow(int n)
        {
            bool[] marked = new bool[n + 1];
            long s = 0;
            int i = 2;
            while (i < n)
            {
                if (!marked[i])
                {
                    s += i;
                    for (int j = 1; j <= n / i; j++)
                        marked[i * j] = true;
                }
                i++;
            }

            return s;
        }

        public object GetResult()
        {
            return GetPrimeSumBelow(2000000);
        }
    }
}
