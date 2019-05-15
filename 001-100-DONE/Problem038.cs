namespace ProjectEuler
{
    class Problem038 : IProblem
    {
        public object GetResult()
        {
            // prin deductie, n = 2 si x = 9182..9999
            int max = 918273645;
            for (int i = 9182; i < 10000; i++)
            {
                int n = 100002 * i;
                if (Common.IsPandigital(n.ToString()))
                    max = n;
            }
            return max;
        }
    }
}
