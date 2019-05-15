using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Problem491 : IProblem
    {
        const int fact10 = 3628800;
        const int fact9 = 362880;

        long CountSums(int[] digitCount)
        {
            long count = fact10;
            for (int i = 0; i < 10; i++)
                if (digitCount[i] == 2)
                    count /= 2;
            if (digitCount[0] > 0)
            {
                long countZero = fact9;
                for (int i = 1; i < 10; i++)
                    if (digitCount[i] == 2)
                        countZero /= 2;
                count -= countZero;
            }

            long secondCount = fact10;
            for (int i = 0; i < 10; i++)
                if (digitCount[i] == 0)
                    secondCount /= 2;

            return count * secondCount;
        }

        long Count(int currentDigit, int currentSum, int[] digitCount, int digitsLeft)
        {
            if (currentSum < currentDigit)
                return 0;

            if (digitsLeft == 1 && currentSum < 10 && digitCount[currentSum] < 2)
            {
                digitCount[currentSum]++;
                long sum = CountSums(digitCount);
                digitCount[currentSum]--;
                return sum;
            }

            long count = 0;
            for (int i = currentDigit; i < 10; i++)
                if (digitCount[i] < 2)
                {
                    digitCount[i]++;
                    count += Count(i, currentSum - i, digitCount, digitsLeft - 1);
                    digitCount[i]--;
                }

            return count;
        }

        public object GetResult()
        {
            int[] oddDigitSums = { 23, 34, 45, 56, 67 };
            long count = 0;

            for (int index = 0; index < oddDigitSums.Length; index++)
            {
                int[] digitCount = new int[10];
                for (int i = 0; i < 10; i++)
                {
                    digitCount[i] = 1;
                    count += Count(i, oddDigitSums[index] - i, digitCount, 9);
                    digitCount[i] = 0;
                }
            }

            return count;
        }
    }
}
