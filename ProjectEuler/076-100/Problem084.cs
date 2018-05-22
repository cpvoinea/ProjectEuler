namespace ProjectEuler
{
    class Problem084 : IProblem
    {
        const int l = 40;
        const int d = 6;
        double[] s = new double[l];

        double Prob(double sum)
        {
            return (sum <= d + 1 ? (sum - 1) : 2 * d + 1 - sum) / d / d;
        }

        double Prob(int square, int prev, int roll)
        {
            int dif = square - prev;
        }

        public string GetResult()
        {
            double p10 = Prob(10, 0, 1) + Prob(30,0);
        }
    }
}
