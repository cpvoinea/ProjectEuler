namespace ProjectEuler
{
    class Problem065 : IProblem
    {
        struct Fraction
        {
            internal string Up;
            internal string Down;

            internal Fraction Next(int d)
            {
                return new Fraction { Up = Common.AddLargeInt(Common.MultiplyLargeInt(Up, d.ToString()), Down), Down = Up };
            }
        }

        public string GetResult()
        {
            int n = 99;
            int p = 33;
            Fraction f = new Fraction { Up = "1", Down = "1" };
            while (n > 1)
            {
                int d = 1;
                if(n % 3 == 0)
                {
                    d = p * 2;
                    p--;
                }
                f = f.Next(d);
                n--;
            }
            f = f.Next(2);
            return Common.GetSumOfDigits(f.Up).ToString();
        }
    }
}
