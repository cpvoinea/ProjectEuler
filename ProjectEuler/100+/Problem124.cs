using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem124 : IProblem
    {
        const int _limit = 100000;
        readonly List<int> _primes = Common.GetPrimeNumbersLowerThan(_limit);

        bool IsRad(int n, out List<int> factors)
        {
            factors = new List<int>();
            if (_primes.Contains(n))
            {
                factors.Add(n);
                return true;
            }
            int i = 0;
            int p = _primes[0];
            while (n > 1 && p <= n && i < _primes.Count)
            {
                if (n % p == 0)
                {
                    if (factors.Contains(p))
                        return false;
                    factors.Add(p);
                    n /= p;
                }
                else
                {
                    i++;
                    p = _primes[i];
                }
            }

            return n == 1;
        }

        void GetList(List<int> factors, int n, List<int> list)
        {
            if (n > _limit)
                return;
            if (!list.Contains(n))
                list.Add(n);
            foreach (int f in factors)
                GetList(factors, n * f, list);
        }

        public string GetResult()
        {
            const int idx = 10000;
            int n = 2;
            int count = 1;
            while (n < _limit)
            {
                List<int> factors;
                while (!IsRad(n, out factors))
                    n++;
                List<int> list = new List<int>();
                GetList(factors, n, list);
                list.Sort();
                int c = list.Count;
                count += c;
                if (count > idx)
                    return list[count - idx + 1].ToString();
                n++;
            }

            return "N/A";
        }
    }
}
