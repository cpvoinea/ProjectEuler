
namespace ProjectEuler
{
    class Problem058 : IProblem
    {
        public string GetResult()
        {
            long count = 8;
            long l = 4;
            while (true)
            {
                long x = 4 * l * l + 1;
                if (Common.IsPrime(x))
                    count++;
                if (Common.IsPrime(x - 2 * l))
                    count++;
                if (Common.IsPrime(x + 2 * l))
                    count++;
                if (count * 10 < 4 * l + 1)
                    return (2 * l + 1).ToString();
                l++;
            }
        }
    }
}
