using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem084 : IProblem
    {
        const int count = 40;
        const int sides = 4;
        readonly double[] prob = new double[count];
        double dp = 1.0 / sides / sides;
        Random r = new Random();

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

        void Shuffle(int[] c, int n)
        {
            List<int> cand = new List<int>();
            for (int i = 0; i < 16; i++)
                if (c[i] == 0)
                    cand.Add(i);
            c[cand[r.Next(cand.Count)]] = n--;
            if (n > 0)
                Shuffle(c, n);
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

            // simulation
            long[] hits = new long[count];
            const long limit = 1000000000;
            int current = 0;
            int[] cc = new int[16];
            Shuffle(cc, 2);
            int[] ch = new int[16];
            Shuffle(ch, 10);
            int ic = 0, ih = 0;
            int cons = 0;
            for(int i = 0; i < limit; i++)
            {
                int d1 = r.Next(sides) + 1;
                int d2 = r.Next(sides) + 1;
                if (d1 == d2)
                    cons++;
                else
                    cons = 0;

                if (cons >= 3)
                {
                    current = 10;
                }
                else
                {
                    current = (current + d1 + d2) % count;

                    // G2J
                    if (current == 30)
                        current = 10;
                    // CC
                    else if (current == 2 || current == 17 || current == 33)
                    {
                        switch (cc[ic++])
                        {
                            case 1: current = 0; break;
                            case 2: current = 10; break;
                        }
                        if (ic >= 16)
                            ic = 0;
                    }
                    // CH
                    else if (current == 7 || current == 22 || current == 36)
                    {
                        switch (ch[ih++])
                        {
                            case 1: current = 0; break;
                            case 2: current = 10; break;
                            case 3: current -= 3; break;
                            case 4: current = 11; break;
                            case 5: current = 24; break;
                            case 6: current = 39; break;
                            case 7: current = 5; break;
                            case 8: current = current == 17 ? 28 : 12; break;
                            case 9: current = ((current + 5) / 10 * 10 + 5) % count; break;
                            case 10: current = ((current + 5) / 10 * 10 + 5) % count; break;
                        }
                        if(current == 33)
                        {
                            switch (cc[ic++])
                            {
                                case 1: current = 0; break;
                                case 2: current = 10; break;
                            }
                            if (ic >= 16)
                                ic = 0;
                        }
                        if (ih >= 16)
                            ih = 0;
                    }
                }

                hits[current]++;
            }

            int[] sorted = new int[count];
            for (int i = 0; i < count; i++)
                sorted[i] = i;
            bool ok = false;
            while (!ok)
            {
                ok = true;
                for (int i = 0; i < count - 1; i++)
                    if (hits[sorted[i]] < hits[sorted[i + 1]])
                    {
                        ok = false;
                        int t = sorted[i];
                        sorted[i] = sorted[i + 1];
                        sorted[i + 1] = t;
                    }
            }

            for (int i = 0; i < 10; i++)
                Console.WriteLine("{0:00} = {1:0.00}%", sorted[i], hits[sorted[i]] * 100.0 / limit);

            return sum.ToString();
        }
    }
}
