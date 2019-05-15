namespace ProjectEuler
{
    class Problem025 : IProblem
    {
        int GetFibonacciWith100Digits()
        {
            string a = "1";
            string b = "1";
            int i = 1;
            while (a.Length < 1000)
            {
                string t = b;
                b = Common.AddLargeInt(a, b);
                a = t;
                i++;
            }
            return i;
        }

        public object GetResult()
        {
            return GetFibonacciWith100Digits();
        }
    }
}
