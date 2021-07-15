using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem725 : IProblem
    {
        const long D = 10000000000000000;

        int[][] GetSumDigits(int slots, int sum)
        {
            List<int[]> result = new List<int[]>();
            int c = 0;
            while (c <= slots && c <= sum)
            {
                if (c == 1)
                {
                    int[] digits = new int[10];
                    digits[sum] = 2;
                    result.Add(digits);
                }
                if (c == 2)
                {
                    for (int i = 1; i <= sum / 2; i++)
                    {
                        int[] digits = new int[10];
                        digits[sum] = 1;
                        digits[i]++;
                        digits[sum - i]++;
                        result.Add(digits);
                    }
                }
                if (c == 3)
                {
                    for (int i = 1; i <= sum / 2; i++)
                        for (int i2 = i; i2 <= (sum - i) / 2; i2++)
                        {
                            int[] digits = new int[10];
                            digits[sum] = 1;
                            digits[i]++;
                            digits[i2]++;
                            digits[sum - i - i2]++;
                            result.Add(digits);
                        }
                }
                if (c == 4)
                {
                    for (int i = 1; i <= sum / 2; i++)
                        for (int i2 = i; i2 <= (sum - i) / 2; i2++)
                            for (int i3 = i2; i3 <= (sum - i - i2) / 2; i3++)
                            {
                                int[] digits = new int[10];
                                digits[sum] = 1;
                                digits[i]++;
                                digits[i2]++;
                                digits[i3]++;
                                digits[sum - i - i2 - i3]++;
                                result.Add(digits);
                            }
                }
                if (c == 5)
                {
                    for (int i = 1; i <= sum / 2; i++)
                        for (int i2 = i; i2 <= (sum - i) / 2; i2++)
                            for (int i3 = i2; i3 <= (sum - i - i2) / 2; i3++)
                                for (int i4 = i3; i4 <= (sum - i - i2 - i3) / 2; i4++)
                                {
                                    int[] digits = new int[10];
                                    digits[sum] = 1;
                                    digits[i]++;
                                    digits[i2]++;
                                    digits[i3]++;
                                    digits[i4]++;
                                    digits[sum - i - i2 - i3 - i4]++;
                                    result.Add(digits);
                                }
                }
                if (c == 6)
                {
                    for (int i = 1; i <= sum / 2; i++)
                        for (int i2 = i; i2 <= (sum - i) / 2; i2++)
                            for (int i3 = i2; i3 <= (sum - i - i2) / 2; i3++)
                                for (int i4 = i3; i4 <= (sum - i - i2 - i3) / 2; i4++)
                                    for (int i5 = i4; i5 <= (sum - i - i2 - i3 - i4) / 2; i5++)
                                    {
                                        int[] digits = new int[10];
                                        digits[sum] = 1;
                                        digits[i]++;
                                        digits[i2]++;
                                        digits[i3]++;
                                        digits[i4]++;
                                        digits[i5]++;
                                        digits[sum - i - i2 - i3 - i4 - i5]++;
                                        result.Add(digits);
                                    }
                }
                if (c == 7)
                {
                    for (int i = 1; i <= sum / 2; i++)
                        for (int i2 = i; i2 <= (sum - i) / 2; i2++)
                            for (int i3 = i2; i3 <= (sum - i - i2) / 2; i3++)
                                for (int i4 = i3; i4 <= (sum - i - i2 - i3) / 2; i4++)
                                    for (int i5 = i4; i5 <= (sum - i - i2 - i3 - i4) / 2; i5++)
                                        for (int i6 = i5; i6 <= (sum - i - i2 - i3 - i4 - i5) / 2; i6++)
                                        {
                                            int[] digits = new int[10];
                                            digits[sum] = 1;
                                            digits[i]++;
                                            digits[i2]++;
                                            digits[i3]++;
                                            digits[i4]++;
                                            digits[i5]++;
                                            digits[i6]++;
                                            digits[sum - i - i2 - i3 - i4 - i5 - i6]++;
                                            result.Add(digits);
                                        }
                }
                if (c == 8)
                {
                    for (int i = 1; i <= sum / 2; i++)
                        for (int i2 = i; i2 <= (sum - i) / 2; i2++)
                            for (int i3 = i2; i3 <= (sum - i - i2) / 2; i3++)
                                for (int i4 = i3; i4 <= (sum - i - i2 - i3) / 2; i4++)
                                    for (int i5 = i4; i5 <= (sum - i - i2 - i3 - i4) / 2; i5++)
                                        for (int i6 = i5; i6 <= (sum - i - i2 - i3 - i4 - i5) / 2; i6++)
                                            for (int i7 = i6; i7 <= (sum - i - i2 - i3 - i4 - i5 - i6) / 2; i7++)
                                            {
                                                int[] digits = new int[10];
                                                digits[sum] = 1;
                                                digits[i]++;
                                                digits[i2]++;
                                                digits[i3]++;
                                                digits[i4]++;
                                                digits[i5]++;
                                                digits[i6]++;
                                                digits[i7]++;
                                                digits[sum - i - i2 - i3 - i4 - i5 - i6 - i7]++;
                                                result.Add(digits);
                                            }
                }
                if (c == 9)
                {
                    int[] digits = new int[10];
                    digits[9] = 1;
                    digits[1] = 9;
                    result.Add(digits);
                }
                c++;
            }
            return result.ToArray();
        }

        long GetCount(int n, int k, long f)
        {
            long current = n;
            bool usedF = false;
            int i = 1;
            while (i < k)
            {
                if (!usedF)
                {
                    for (int j = 2; j <= 9; j++)
                        while (f % j == 0 && current % j == 0)
                        {
                            f /= j;
                            current /= j;
                            if (f == 1)
                                usedF = true;
                        }
                }

                if (!usedF)
                    current *= n - i;
                else
                {
                    long t = current;
                    for (int j = 1; j < n - i; j++)
                        current = (current + t) % D;
                }

                i++;
            }
            if (!usedF)
                current /= f;

            return current;
        }

        long Comb(int n, int[] digits)
        {
            long result = 0;
            for (int first = 1; first < 10; first++)
                if (digits[first] > 0)
                {
                    int all = 0;
                    int nonZero = 0;
                    long fact = 1;
                    for (int i = 1; i < 10; i++)
                        if (digits[i] > 0)
                        {
                            int d = digits[i] - (i == first ? 1 : 0);
                            all += d;
                            if (d > 0)
                                nonZero++;
                            for (int j = 2; j <= d; j++)
                                fact *= j;
                        }

                    long count = GetCount(n - 1, all, fact);

                    for (int i = 0; i < first; i++)
                        result = (result + count) % D;
                }

            return result;
        }

        long S(int n)
        {
            long s = 0;
            for (int sum = 9; sum >= 1; sum--)
            {
                long sSum = 0;
                int[][] sumDigits = GetSumDigits(n - 1, sum);
                foreach (int[] digits in sumDigits)
                {
                    sSum = (sSum + Comb(n, digits)) % D;
                }
                s = (s + sSum) % D;
            }

            long result = s;
            for (int i = 0; i < n - 1; i++)
                result = (result * 10 + s) % D;

            return result;
        }

        public object GetResult()
        {
            return S(2020);
        }
    }
}
