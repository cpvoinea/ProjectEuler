using System;

namespace ProjectEuler
{
    class Problem205 : IProblem
    {
        void Roll(int rolls, int dice, int sum, int[] result)
        {
            if (rolls == 0)
                return;
            if (rolls == 1)
                for (int i = 1; i <= dice; i++)
                    result[sum + i]++;
            for (int i = 1; i <= dice; i++)
                Roll(rolls - 1, dice, sum + i, result);
        }

        public string GetResult()
        {
            int[] pete = new int[37];
            int[] colin = new int[37];
            Roll(9, 4, 0, pete);
            Roll(6, 6, 0, colin);
            long c = 0;
            long sp = 0;
            for (int i = 9; i <= 36; i++)
            {
                int s = 0;
                sp += pete[i];
                for (int j = 6; j < i; j++)
                    s += colin[j];
                c += pete[i] * s;
            }
            long sc = 0;
            for (int j = 6; j <= 36; j++)
                sc += colin[j];
            double p = (double)c / (sp * sc);
            return Math.Round(p, 7).ToString();
        }
    }
}
