using System;
using System.Collections.Generic;

namespace ProjectEuler
{
	class Problem005 : IProblem
	{
		long GetSmallestNumberDivisibleWithAllBelow(int n)
		{
			List<int> primes = Common.GetPrimeNumbersLowerThan(n);
			Dictionary<int, int> powers = new Dictionary<int, int>();
			for (int i = 2; i <= n; i++)
			{
				int m = i;
				for (int j = 0; j < primes.Count; j++)
				{
					int c = 0;
					int p = primes[j];
					while (m % p == 0)
					{
						c++;
						m = m / p;
					}
					if (c > 0)
					{
						if (powers.ContainsKey(p))
						{
							if (powers[p] < c)
								powers[p] = c;
						}
						else
							powers.Add(p, c);
					}
				}
			}

			long result = 1;
			foreach (int p in powers.Keys)
				for (int i = 0; i < powers[p]; i++)
					result *= p;

			return result;
		}

		// Better method
		long GetSmallestNumberDivisibleWithAllBelow(int n, bool better)
		{
			List<int> primes = Common.GetPrimeNumbersLowerThan(n);
			Dictionary<int, int> powers = new Dictionary<int, int>();

			int sqrt = (int)Math.Sqrt(n);
			double lg = Math.Log(n);
			for (int j = 0; j < primes.Count; j++)
			{
				int a = 1;
				int p = primes[j];
				if (p <= sqrt)
					a = (int)(lg / Math.Log(p));
				powers.Add(p, a);
			}

			long result = 1;
			foreach (int p in powers.Keys)
				for (int i = 0; i < powers[p]; i++)
					result *= p;

			return result;
		}

		public string GetResult()
		{
			int n = 20;
			return GetSmallestNumberDivisibleWithAllBelow(n) + " Better method: " + GetSmallestNumberDivisibleWithAllBelow(n, true);
		}
	}
}
