using System;
using System.Collections;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem516 : IProblem
    {
        const long limit = 1_000_000_000_000;
        int[] hammingFactors = { 2, 3, 5 };
        long div = (long)Math.Pow(2, 32);
        BitArray primes = Common.GeneratePrimes((int)Math.Sqrt(limit));
        SortedSet<long> hamming = new SortedSet<long> { 1 };
        List<long> hammingPrimes = new List<long>();
        long sum = 1;

        bool IsPrime(long n)
        {
            for (int p = 2; p <= (int)Math.Sqrt(n); p++)
                if (primes[p])
                {
                    if (n % p == 0)
                        return false;
                }
            return true;
        }

        void Generate(long from)
        {
            foreach (int h in hammingFactors)
                if (from <= limit / h)
                {
                    long next = from * h;
                    if (!hamming.Contains(next))
                    {
                        Add(next);
                        hamming.Add(next);
                        if (next >= 5 && next < limit && next % 2 == 0 && IsPrime(next + 1))
                            hammingPrimes.Add(next + 1);
                        Generate(next);
                    }
                }
        }

        void Add(long v)
        {
            sum = (sum + v) % div;
        }

        void SumCombinations(long current, int maxIndex)
        {
            long max = limit / current;
            foreach (long h in hamming)
            {
                if (h > max)
                    break;
                Add(current * h);
            }
            while (maxIndex >= 0 && hammingPrimes[maxIndex] > max)
                maxIndex--;
            for (int i = maxIndex; i >= 0; i--)
                SumCombinations(current * hammingPrimes[i], i - 1);
        }

        public string GetResult()
        {
            Generate(1);
            hammingPrimes.Sort();
            for (int i = hammingPrimes.Count - 1; i >= 0; i--)
                SumCombinations(hammingPrimes[i], i - 1);

            return sum.ToString();
        }
    }
}