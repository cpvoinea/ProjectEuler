using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
	class Problem029: IProblem
	{
		public string GetResult()
		{
			int limit = 100;
			List<int> primes = Common.GetPrimeNumbersLowerThan(limit);
			Dictionary<int, string> primeFactors = new Dictionary<int, string>();
			for (int i = 2; i <= limit; i++)
			{
				int n = i;
				string factors = "";
				for(int j = 0; j < primes.Count; j++)
				{
					int p = primes[j];
					int c = 0;
					while (n % p == 0)
					{
						n = n / p;
						c++;
					}
					factors += c + " ";
					if (n == 1)
						break;
				}
				primeFactors.Add(i, factors.Trim());
			}

			List<string> unique = new List<string>();
			for (int i = 2; i <= 100; i++)
			{
				string factors = primeFactors[i];
				for (int j = 2; j <= 100; j++)
				{
					string newFactors = string.Concat(factors.Split().Select(s => int.Parse(s) * j + " "));
					if (!unique.Contains(newFactors))
						unique.Add(newFactors);
				}
			}

			return unique.Count.ToString();
		}
	}
}
