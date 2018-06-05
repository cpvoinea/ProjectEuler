using System;

namespace ProjectEuler
{
    class Problem084 : IProblem
    {
        const int count = 40;
        const int sides = 4;
        readonly double[] prob = new double[count];
        double dp = 1.0 / sides / sides;

        double Count(int dice)
        {
            return (sides - Math.Abs(sides + 1 - dice)) * dp;
        }

        void CalculateProb(int i, ref long passes)
        {
            passes++;
            for (int dice = 2; dice <= 2 * sides; dice++)
            {
                int n = (i + dice) % count;
                double p = Count(dice);
                // 3 doubles
                if (passes >= 3 && dice % 2 == 0)
                {
                    prob[10] += dp * dp;
                    p = p - dp * dp;
                }
                // G2J
                if (n == 30)
                {
                    prob[10] += p;
                }
                // CC
                else if (n == 2 || n == 17 || n == 33)
                {
                    prob[0] += p / 16;
                    prob[10] += p / 16;
                    prob[n] += 7 * p / 8;
                }
                // CH
                else if (n == 7 || n == 22 || n == 36)
                {
                    prob[0] += p / 16;
                    prob[10] += p / 16;
                    prob[n - 3] += p / 16;
                    prob[11] += p / 16;
                    prob[24] += p / 16;
                    prob[39] += p / 16;
                    prob[5] += p / 16;
                    prob[n == 17 ? 28 : 12] += p / 16;
                    prob[((n + 5) / 10 * 10 + 5) % count] += p / 8;
                    prob[n] += 3 * p / 8;
                }
                else
                    prob[n] += p;
            }
        }

        public string GetResult()
        {
            long passes = 0;
            for (int i = 0; i < count; i++)
                CalculateProb(i, ref passes);

            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                prob[i] = prob[i] * 100 / passes;
                sum += prob[i];
            }

            int[] sorted = new int[count];
            for (int i = 0; i < count; i++)
                sorted[i] = i;
            bool ok = false;
            while (!ok)
            {
                ok = true;
                for (int i = 0; i < count - 1; i++)
                    if (prob[sorted[i]] < prob[sorted[i + 1]])
                    {
                        ok = false;
                        int t = sorted[i];
                        sorted[i] = sorted[i + 1];
                        sorted[i + 1] = t;
                    }
            }

            for (int i = 0; i < 10; i++)
                Console.WriteLine("{0:00} = {1:0.00}%", sorted[i], prob[sorted[i]]);

            return sum.ToString();
        }
    }
}
