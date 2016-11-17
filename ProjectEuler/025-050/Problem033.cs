using System;

namespace ProjectEuler
{
	class Problem033 : IProblem
	{
		public string GetResult()
		{
			int mp = 1, np = 1;
			for(int x = 1; x <= 9; x++)
				for (int y = 1; y <= 9; y++)
				{
					int m = 9 * x * y;
					int n = 10 * x - y;
					if (m % n == 0)
					{
						int a = m / n;
						if (a >= 1 && a <= 9 && (a != x || a != y))
						{
							Console.WriteLine("" + x + a + "/" + a + y);
							mp *= 10 * x + a;
							np *= 10 * a + y;
						}
					}
				}

			return mp + "/" + np;
		}
	}
}
