namespace ProjectEuler
{
    class Problem145 : IProblem
    {
        bool IsReversible(int n)
        {
            if (n % 10 == 0)
                return false;
            string sn = n.ToString();
            int l = sn.Length;
            int i = 0;
            int r = 0;
            while (i < l)
            {
                int s = sn[l - 1 - i] + sn[i] - 96 + r;
                if ((s % 10) % 2 == 0)
                    return false;
                r = s / 10;
                i++;
            }
            return true;
        }

        public object GetResult()
        {
            const int limit = 1000000000;

            int count = 0;
            for (int n = 12; n < limit; n++)
                if (IsReversible(n))
                    count++;

            return count;
        }
    }
}
