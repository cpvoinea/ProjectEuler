using System.Collections.Generic;

namespace ProjectEuler
{
	class Problem044 : IProblem
	{
		List<long> pentagonalNumbers = new List<long>();

		public string GetResult()
		{
			int limit = 10000;
			for (long j = 1; j <= limit; j++)
				pentagonalNumbers.Add(j * (3 * j - 1) / 2);
			int n = 2;
			int i = 2;
			int di = 3;
			long d = pentagonalNumbers[di];
			while (di < limit - 2)
			{
				d = pentagonalNumbers[di];
				long dif = pentagonalNumbers[n + i] - pentagonalNumbers[n];
				if (dif == d)
				{
					long sum = pentagonalNumbers[n + i] + pentagonalNumbers[n];
					if (pentagonalNumbers.Contains(sum))
					{
						return d.ToString();
					}
				}
				if (dif > d)
				{
					if (i == 1)
					{
						di++;
						d = pentagonalNumbers[di];
						i = 2;
						n = di - 1;
						long s = pentagonalNumbers[n + i] - pentagonalNumbers[n];
						while (s < d)
						{
							n--;
							i++;
							s = pentagonalNumbers[n + i] - pentagonalNumbers[n];
						}
					}
					else
					{
						n++;
						i--;
					}
				}
				else
				{
					if (n + i < limit - 1)
						i++;
					else
					{
						di++;
						d = pentagonalNumbers[di];
						i = 2;
						n = di - 1;
						long s = pentagonalNumbers[n + i] - pentagonalNumbers[n];
						while (s < d)
						{
							n--;
							i++;
							s = pentagonalNumbers[n + i] - pentagonalNumbers[n];
						}
					}
				}
			}

			return "nope";
		}
	}
}
