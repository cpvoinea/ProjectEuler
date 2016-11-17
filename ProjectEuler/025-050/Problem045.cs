using System;

namespace ProjectEuler
{
	class Problem045 : IProblem
	{
		public string GetResult()
		{
			int limit = 100000;
			for (int i = 144; i < limit; i++)
			{
				long h = (long)i * (2 * i - 1);
				double s = Math.Sqrt(24 * h + 1);
				if (s % 1 == 0.0 && (s + 1) % 6 == 0)
					return h.ToString();
			}

			return "nope";
		}
	}
}
