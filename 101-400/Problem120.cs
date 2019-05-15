namespace ProjectEuler
{
    class Problem120 : IProblem
    {
        public object GetResult()
        {
            // n par => rmax = 2, n impar => rmax = 2*n*a
            // n impar: a par => rmax = a*a-2*a, a impar => rmax = a*a-a
            long s = 0;
            for (int a = 3; a <= 1000; a++)
            {
                s += a * (a - 2 + a % 2);
            }

            return s;
        }
    }
}
