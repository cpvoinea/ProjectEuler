namespace ProjectEuler
{
    class Problem016 : IProblem
    {
        int GetDigitSum(string n)
        {
            int l = n.Length;
            int s = 0;
            for (int i = 0; i < l; i++)
                s += n[i] - 48;

            return s;
        }

        public object GetResult()
        {
            string n = "1";
            for (int i = 0; i < 1000; i++)
                n = Common.AddLargeInt(n, n);

            return GetDigitSum(n);
        }
    }
}
