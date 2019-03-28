using System;
using System.Linq;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem060 : IProblem
    {
        readonly List<int> _primes;
        readonly Dictionary<int, List<int>> _pairs = new Dictionary<int, List<int>>();
        const int _maxPrime = 10000;

        public Problem060()
        {
            _primes = Common.GetPrimeNumbersLowerThan(_maxPrime);
            Console.WriteLine("Primes generated");

            int i = 0;
            while (i < _primes.Count)
            {
                int p = _primes[i];
                string sp = p.ToString();
                for (int j = i + 1; j < _primes.Count; j++)
                {
                    int q = _primes[j];
                    if (Common.IsPrime(long.Parse(sp + q)) && Common.IsPrime(long.Parse(q + sp)))
                    {
                        if (_pairs.ContainsKey(p))
                            _pairs[p].Add(q);
                        else
                            _pairs.Add(p, new List<int> { q });
                    }
                }
                i++;
            }
            Console.WriteLine("Pairs generated");
        }

        List<int> GetCommon(params int[] n)
        {
            List<int> result = new List<int>();
            if (_pairs.ContainsKey(n[0]))
                foreach (int x in _pairs[n[0]])
                {
                    bool isCommon = true;
                    for (int i = 1; i < n.Length; i++)
                        if (!_pairs.ContainsKey(n[i]) || !_pairs[n[i]].Contains(x))
                        {
                            isCommon = false;
                            break;
                        }
                    if (isCommon)
                        result.Add(x);
                }
            return result;
        }

        public string GetResult()
        {
            int n = 5;
            List<int> sums = new List<int>();
            foreach (int p in _pairs.Keys)
            {
                if (_pairs[p].Count >= n - 1)
                {
                    foreach (int q in _pairs[p])
                    {
                        var c1 = GetCommon(q, p);
                        if (c1.Count >= n - 2)
                        {
                            foreach (int r in c1)
                            {
                                var c2 = GetCommon(r, q, p);
                                if (c2.Count >= n - 3)
                                {
                                    foreach (int s in c2)
                                    {
                                        var c3 = GetCommon(s, r, q, p);
                                        if (c3.Count >= n - 4)
                                        {
                                            int t = c3[0];
                                            sums.Add(p + q + r + s + t);
                                            Console.WriteLine("{0} {1} {2} {3} {4}", p, q, r, s, t);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return sums.Count == 0 ? "0" : sums.Min().ToString();
        }
    }
}
