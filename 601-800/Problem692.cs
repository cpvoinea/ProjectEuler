namespace ProjectEuler
{
    class Problem692 : IProblem
    {
        public object GetResult()
        {
            const long M = 23416728348467685;
            long f1 = 1, f2 = 2;
            long g1 = 1, g2 = 3;
            while (f2 < M)
            {
                f2 = f1 + f2;
                f1 = f2 - f1;
                long g3 = g1 + g2 + f1;
                g1 = g2;
                g2 = g3;
            }

            return g2;
        }
    }
}
