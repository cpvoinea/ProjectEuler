using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem500 : IProblem
    {
        public string GetResult()
        {
            const int limit = 7376510;
            const int m = 500500507;
            var primes = Common.GetPrimeNumbersLowerThan(limit).ToArray();
            int count = primes.Length; //500500
            Dictionary<int, int> powers = new Dictionary<int, int>();
            foreach (int p in primes)
                powers.Add(p, 1);
            int currentPow = 2;
            int right = 500499;
            int left = 0;
            while (left < right)
            {
                int leftVal = primes[left];
                int rightVal = primes[right];
                long leftPow = leftVal;
                for (int i = 1; i < currentPow; i *= 2)
                    leftPow *= leftPow;
                if (leftPow < rightVal)
                {
                    powers.Remove(rightVal);
                    powers[leftVal] += currentPow;
                    left++;
                    right--;
                }
                else if (left == 0)
                    left = right;
                else
                {
                    left = 0;
                    currentPow *= 2;
                }
            }

            long s = 1;
            foreach (int p in powers.Keys)
            {
                for (int i = 0; i < powers[p]; i++)
                    s = (s * p) % m;
            }

            return s.ToString();
        }
    }
}
