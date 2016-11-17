namespace ProjectEuler
{
    class Problem063 : IProblem
    {
        public string GetResult()
        {
            int count = 0;
            int d = 1;
            int first = 1;
            while(first < 10)
            {
                for (int i = first; i < 10; i++)
                {
                    string p = i.ToString();
                    for (int j = 0; j < d - 1; j++)
                        p = Common.MultiplyLargeInt(p, i.ToString());
                    if (p.Length < d)
                        first++;
                    if (p.Length == d)
                        count++;
                }
                d++;
            }

            return count.ToString();
        }
    }
}
