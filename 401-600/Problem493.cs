namespace ProjectEuler
{
    class Problem493 : IProblem
    {
        private double Prob(int samples, int colors)
        {
            if (colors <= 0 || colors > 7 || colors > samples)
                return 0;
            if (samples == 1)
                return 1;

            int inUrn = 70 - samples + 1;

            double p = 0;
            p += Prob(samples - 1, colors) * (colors * 10 - samples + 1);
            p += Prob(samples - 1, colors - 1) * 10 * (7 - colors + 1);
            return p / inUrn;
        }

        public string GetResult()
        {
            double s = 0;

            for (int i = 1; i <= 7; i++)
                s += i * Prob(20, i);

            return s.ToString();
        }
    }
}
