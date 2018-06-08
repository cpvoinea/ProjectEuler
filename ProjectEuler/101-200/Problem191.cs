namespace ProjectEuler
{
    class Problem191 : IProblem
    {
        const int n = 30;
        long count = 0;

        void CountFrom(int i, bool wasLate, int absences)
        {
            if (i >= n)
                count++;
            else
            {
                if (!wasLate)
                    CountFrom(i + 1, true, 0);
                if (absences < 2)
                    CountFrom(i + 1, wasLate, absences + 1);
                CountFrom(i + 1, wasLate, 0);
            }
        }

        public string GetResult()
        {
            CountFrom(0, false, 0);
            return count.ToString();
        }
    }
}
