namespace ProjectEuler
{
    class Problem036 : IProblem
    {
        string Base2(int n)
        {
            string result = "";
            while (n != 0)
            {
                result = (n % 2) + result;
                n = n / 2;
            }

            return result;
        }

        public object GetResult()
        {
            int limit = 1000000;
            int s = 0;
            for (int i = 1; i < limit; i++)
            {
                if (Common.IsPalindrome(i.ToString()) && Common.IsPalindrome(Base2(i)))
                    s += i;
            }

            return s;
        }
    }
}
