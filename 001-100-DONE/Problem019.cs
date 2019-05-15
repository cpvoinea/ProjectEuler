namespace ProjectEuler
{
    class Problem019 : IProblem
    {
        public object GetResult()
        {
            int[] daysInMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int current = 365;
            int count = 0;
            for (int i = 1; i <= 100; i++)
            {
                bool isLeap = i % 4 == 0;
                for (int j = 0; j < 12; j++)
                {
                    if (isLeap && j > 0)
                    {
                        current++;
                        isLeap = false;
                    }
                    current += daysInMonth[j];
                    if (current % 7 == 6)
                        count++;
                }
            }
            return count;
        }
    }
}
