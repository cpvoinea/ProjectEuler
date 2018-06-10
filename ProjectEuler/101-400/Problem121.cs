namespace ProjectEuler
{
    class Problem121 : IProblem
    {
        const int limit = 15;

        long Count(int turns, int draw)
        {
            if (turns == limit)
                return draw > limit / 2 ? 1 : 0;
            turns++;
            // there are (turns+1) balls on each turn, 1 of them is blue
            return Count(turns, draw + 1) + turns * Count(turns, draw);
        }

        public string GetResult()
        {
            long wins = Count(0, 0);
            long count = 1;
            for (int i = 2; i <= limit + 1; i++)
                count *= i;
            long sum = count / wins;

            System.Console.WriteLine("{0} / {1}", wins, count);

            return sum.ToString();
        }
    }
}
