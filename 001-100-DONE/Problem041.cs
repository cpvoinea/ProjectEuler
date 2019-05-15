namespace ProjectEuler
{
    class Problem041 : IProblem
    {
        public object GetResult()
        {
            for (int n = 7654321; n >= 1234567; n -= 2)
                if (Common.IsPandigital(n.ToString(), 7) && Common.IsPrime(n))
                    return n;
            return "bau";
        }
    }
}
