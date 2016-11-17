using System.Collections.Generic;

namespace ProjectEuler
{
	class Problem039 : IProblem
	{
		public string GetResult()
		{
			int limit = 1000;
			int maxCount = 0;
			int maxI = 0;
			for (int i = 12; i <= limit; i += 2)
			{
				int l = i / 2;
				int count = 0;
				List<int> foundA = new List<int>();
				for (int k = 1; k <= l / 2; k++)
					if (i % k == 0)
					{
						int j = i / k;
						for(int m = 1; m <= j / 2; m++)
							if (j % m == 0)
							{
								int n = (j / m) - m;
								if (n < m)
								{
									int a = 2 * k * m * n;
									int b = k * (m * m - n * n);
									if (a > b && !foundA.Contains(a))
									{
										foundA.Add(a);
										count++;
									}
								}
							}
					}
				if (count > maxCount)
				{
					maxCount = count;
					maxI = i;
				}
			}

			return maxI.ToString();
		}
	}
}
