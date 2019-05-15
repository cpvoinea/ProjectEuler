namespace ProjectEuler
{
    class Problem056 : IProblem
    {
        public object GetResult()
        {
            int max = 0;
            for (int a = 2; a < 100; a++)
            {
                string sa = a.ToString();
                for (int b = 2; b < 100; b++)
                {
                    sa = Common.MultiplyLargeInt(sa, a.ToString());
                    int n = Common.GetSumOfDigits(sa);
                    if (n > max)
                        max = n;
                }
            }

            return max;
        }
    }
}
