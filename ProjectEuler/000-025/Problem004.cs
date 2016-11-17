using System;

namespace ProjectEuler
{
	class Problem004 : IProblem
	{
		string GetLargestPalindromeProduct()
		{
			// 6 digits
			for (int a = 9; a > 0; a--)
				for (int b = 9; b >= 0; b--)
					for (int c = 9; c >= 0; c--)
					{
						int p = 100001 * a + 10010 * b + 1100 * c;
						for (int i = 100; i < Math.Sqrt(p); i++)
							if (p % i == 0 && p / i < 1000)
								return p + " = " + i + " * " + (p / i);
					}

			// 5 digits
			for (int a = 9; a > 0; a--)
				for (int b = 9; b >= 0; b--)
					for (int c = 9; c >= 0; c--)
					{
						int p = 10001 * a + 1010 * b + 100 * c;
						for (int i = 100; i < Math.Sqrt(p); i++)
							if (p % i == 0 && p / i >= 100)
								return p + " = " + i + " * " + (p / i);
					}
			return "NOT FOUND";
		}

		public string GetResult()
		{
			return GetLargestPalindromeProduct();
		}
	}
}
