namespace ProjectEuler
{
    class Problem700 : IProblem
    {
        const long E = 1504170715041707;
        const long M = 4503599627370517;

        public object GetResult()
        {
            long sum = E;
            long min = E;
            long lastN = 1;
            long lastE = E;
            long n = 1;
            long e = E;

            while (n < M)
            {
                n += lastN;
                e = (e + lastE) % M;

                if (e < min)
                {
                    long difN = n - lastN;
                    long difE = M + e - lastE;
                    while (e < min)
                    {
                        min = e;
                        sum += min;

                        lastN = n;
                        lastE = e;
                        n += difN;
                        e = (e + difE) % M;
                    }
                }
            }
            return sum;
        }
    }
}
