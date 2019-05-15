namespace ProjectEuler
{
    class Problem301 : IProblem
    {
        int X(int n)
        {
            return n ^ (2 * n) ^ (3 * n);
        }

        public object GetResult()
        {
            int c = 0;
            for (int n = 1; n <= 1073741824; n++)
                if (X(n) == 0)
                    c++;
            return c;
        }
    }
}
