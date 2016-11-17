using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
	class Problem051 : IProblem
	{
		struct Difference
		{
			public Difference( int count, int dif)
			{
				NoOfDigits = count;
				BaseDiff = dif;
			}

			public int NoOfDigits;
			public int BaseDiff;
		}

		List<Difference> GetDifferences(int n)
		{
			List<Difference> result = new List<Difference>();
			n /= 10;
			int c = 10;
			int[] count = new int[3];
			int[] diff = new int[3];
			while (n > 0)
			{
				int d = n % 10;
				if (d < 3)
				{
					diff[d] += c;
					count[d]++;
				}
				c *= 10;
				n /= 10;
			}
			for (int i = 0; i < 3; i++)
				if (count[i] > 1)
					result.Add(new Difference(count[i], diff[i]));
			return result;
		}

		public string GetResult()
		{
			int limit = 1000000;
			List<int> primes = Common.GetPrimeNumbersLowerThan(limit).Where(n => n > 10000).ToList();
			int c = primes.Count;

			Console.WriteLine("90007 " + primes.Contains(90007));
			Console.WriteLine("91117 " + primes.Contains(91117));
			Console.WriteLine("92227 " + primes.Contains(92227));
			Console.WriteLine("93337 " + primes.Contains(93337));
			Console.WriteLine("94447 " + primes.Contains(94447));
			Console.WriteLine("95557 " + primes.Contains(95557));
			Console.WriteLine("96667 " + primes.Contains(96667));
			Console.WriteLine("97777 " + primes.Contains(97777));
			Console.WriteLine("98887 " + primes.Contains(98887));
			Console.WriteLine("99997 " + primes.Contains(99997));

			int fi = 0;
			while (fi < c  - 1)
			{
				int n = primes[fi];
				foreach(Difference d in GetDifferences(n))
				{
					int count = 1;
					for (int i = 1; i < 10; i++)
						if (primes.Contains(n + i * d.BaseDiff))
							count++;
					if (count == 8)
						Console.WriteLine(n + " " + d.BaseDiff);
				}
				fi++;
			}

			return "nope";
		}
	}
}
