namespace ProjectEuler
{
    class Problem710 : IProblem
    {
        const long D = 1000000;
        const long M = 1000000000000;

        public object GetResult()
        {
            long t1 = 0;
            long t2 = 1;
            long t3 = 2;
            long pow = 1;
            long n = 4;
            while(t3 % D > 0)
            {
                long d = M + t3 + pow + t1 - t2;
                pow = (pow * 2) % M;
                t1 = t2;
                t2 = t3;
                t3 = (t3 + d) % M;
                n += 2;
            }

            return n;
        }
    }
}
