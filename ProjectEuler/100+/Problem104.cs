using System.Numerics;

namespace ProjectEuler
{
    class Problem104 : IProblem
    {
        bool Check(BigInteger y)
        {
            if (!Common.IsAllPandigital((long)(y % 1000000000)))
                return false;
            if (!Common.IsAllPandigital(long.Parse(y.ToString().Substring(0, 9))))
                return false;
            return true;
        }

        public string GetResult()
        {
            BigInteger n = 2, x = 1, y = 1;
            while (n <= 2749 || !Check(y))
            {
                y = x + y;
                x = y - x;
                n++;
            }

            return n.ToString();
        }
    }
}
