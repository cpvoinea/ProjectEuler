namespace ProjectEuler
{
    class Problem097 : IProblem
    {
        public string GetResult()
        {
            const int pow = 7830457;
            const long dig = 10000000000;
            long num = 28433;
            for (int i = 0; i < pow; i++)
                num = num * 2 % dig;
            num = (num + 1) % dig;

            return num.ToString();
        }
    }
}
