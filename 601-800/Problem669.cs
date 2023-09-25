using System;
using System.Numerics;

namespace ProjectEuler
{
    class Problem669 : IProblem
    {
        public object GetResult()
        {
            const long place = 10_000_000_000_000_000;
            double phi = (Math.Sqrt(5) + 3) / 2;
            long f1 = 61305790721611591;
            long f2 = 99194853094755497;
            long seat = f2 - place + 1;

            long maxIndex = seat / 6;
            long index = 10 * maxIndex - 4 * (long)(maxIndex / phi);
            long step = 1_000_000_000_000_000;
            while (step > 0)
            {
                while (index > seat)
                {
                    maxIndex -= step;
                    index = 10 * maxIndex - 4 * (long)(maxIndex / phi);
                    if (step > 1 && index < seat)
                    {
                        step /= 10;
                        while (index < seat)
                        {
                            maxIndex += step;
                            index = 10 * maxIndex - 4 * (long)(maxIndex / phi);
                        }
                    }
                }
                step /= 10;
            }
            long intervals6 = (long)(maxIndex / phi);
            long intervals10 = maxIndex - intervals6;
            int correction = 2; // for the extra 8 seats after the last interval
            long a = seat / 2;
            long b = 3 * intervals10 + 2 * intervals6 + correction;
            BigInteger b1 = new BigInteger(a) * f1;
            BigInteger b2 = new BigInteger(b) * f2;
            BigInteger result = b1 - b2;

            return result;
        }
    }
}