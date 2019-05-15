namespace ProjectEuler
{
    class Problem151 : IProblem
    {
        double Count(int[] a, double prob)
        {
            double s = 0;
            foreach (int i in a) s += i;
            double c = 0;
            if (s == 1)
            {
                if (a[3] == 1)
                    return 0;
                c = prob;
            }
            if (a[0] == 1)
                c += Count(new[] { 0, a[1] + 1, a[2] + 1, a[3] + 1 }, prob / s);
            if (a[1] >= 1)
                c += Count(new[] { a[0], a[1] - 1, a[2] + 1, a[3] + 1 }, prob * a[1] / s);
            if (a[2] >= 1)
                c += Count(new[] { a[0], a[1], a[2] - 1, a[3] + 1 }, prob * a[2] / s);
            if (a[3] >= 1)
                c += Count(new[] { a[0], a[1], a[2], a[3] - 1 }, prob * a[3] / s);
            return c;
        }

        public object GetResult()
        {
            return Count(new[] { 1, 1, 1, 1 }, 1);
        }
    }
}
