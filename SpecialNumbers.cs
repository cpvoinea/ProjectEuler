using System;
using System.Collections;

namespace ProjectEuler
{
    static class SpecialNumbers
    {
        public static BitArray Prime(int n)
        {
            return Common.GeneratePrimes(n + 1);
        }

        public static BitArray Lucky(int n)
        {
            BitArray isLucky = new BitArray(n + 1, true);
            isLucky[0] = false;
            int from = 2;
            while (from <= n)
            {
                while (from <= n && !isLucky[from])
                    from++;
                if (from > n)
                    break;
                int c = 0;
                int i = 1;
                while (i <= n)
                {
                    if (isLucky[i])
                        c++;
                    if (c == from)
                    {
                        isLucky[i] = false;
                        c = 0;
                    }
                    i++;
                }
                from++;
            }

            return isLucky;
        }

        public static BitArray Triangle(int n)
        {
            BitArray isTriangle = new BitArray(n + 1);
            int limit = (int)Math.Sqrt(2 * n) + 1;
            for (int i = 0; i <= limit; i++)
            {
                int t = i * (i + 1) / 2;
                if (t <= n)
                    isTriangle[t] = true;
                else
                    break;
            }

            return isTriangle;
        }

        public static void Print(BitArray numbers)
        {
            int currentDivision = 0;
            int divisionCount = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (i / 100 > currentDivision)
                {
                    currentDivision++;
                    Console.WriteLine("==={0}00: {1}===", currentDivision, divisionCount);
                    divisionCount = 0;
                }
                if (numbers[i])
                {
                    Console.WriteLine(i);
                    divisionCount++;
                }
            }
            Console.WriteLine("==={0}00: {1}===", currentDivision + 1, divisionCount);
        }
    }
}