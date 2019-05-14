using System;
using System.Numerics;

namespace ProjectEuler
{
    class Problem669 : IProblem
    {
        public string GetResult()
        {
            // for (int i = 0; i < fibos.Length; i++)
            //     Console.WriteLine(fibos[i]);
            const long place = 10_000_000_000_000_000;
            double phi = (Math.Sqrt(5) + 3) / 2;
            long f1 = 61305790721611591;
            long f2 = 99194853094755497;
            long max = f2 - place + 1;

            // f1 = 21;
            // f2 = 34;
            // max = 32;
            long maxIndex = max / 6;

            // http://oeis.org/A001950
            long max6 = (long)(maxIndex / phi);
            long max10 = maxIndex - max6;
            long index = 10 * maxIndex - 4 * max6;
            long step = place / 10;
            while (index > max)
            {
                maxIndex -= step;
                max6 = (long)(maxIndex / phi);
                max10 = maxIndex - max6;
                index = 10 * maxIndex - 4 * max6;
                if (step > 100 && index < max)
                {
                    step /= 10;
                    while (index < max)
                    {
                        maxIndex += step;
                        max6 = (long)(maxIndex / phi);
                        max10 = maxIndex - max6;
                        index = 10 * maxIndex - 4 * max6;
                    }
                    step /= 10;
                }
            }
            while (index <= max)
            {
                maxIndex++;
                max6 = (long)(maxIndex / phi);
                max10 = maxIndex - max6;
                index = 10 * maxIndex - 4 * max6;
            }
            maxIndex--;
            max6 = (long)(maxIndex / phi);
            max10 = maxIndex - max6;
            index = 10 * maxIndex - 4 * max6;
            // maxIndex = 10528024286734893 max6 = 4021347443148360 max10 = 6506676843586533 index = 89194853094755490  max-index = 8
            // Console.WriteLine("{0} {1} {2} {3} {4}", maxIndex, max6, max10, index, max - index);
            long a = max / 2;
            long b = -(3 + 3 * (max10 - 1) + 2 * (max6) + 2);
            // a = 44597426547377748 b = 27562725417056321 a-b = 72160151964434069
            // Console.WriteLine("{0} {1} {2}", a, b, a * f1 + b * f2);
            BigInteger b1 = new BigInteger(a) * f1;
            BigInteger b2 = new BigInteger(b) * f2;
            BigInteger r = b1 + b2;

            return r.ToString();
        }
    }
}