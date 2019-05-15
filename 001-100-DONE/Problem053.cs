namespace ProjectEuler
{
    class Problem053 : IProblem
    {
        public object GetResult()
        {
            int limit = 1000000;
            int s = 0;
            for (int n = 23; n <= 100; n++)
            {
                int r = 4;
                int c = n * (n - 1) * (n - 2) * (n - 3) / 24;
                while (c < limit)
                {
                    c = c * (n - r) / (r + 1);
                    r++;
                }
                s += n - 2 * r + 1;
            }

            return s;
        }
    }
}
