using System.Linq;

namespace ProjectEuler
{
	class Problem055 : IProblem
	{
		public string GetResult()
		{
			int limit = 10000;
			int count = 0;
			for (int i = 10; i < limit; i++)
			{
				string s = i.ToString();
				string n = Common.AddLargeInt(s, new string(s.Reverse().ToArray()));
				if (Common.IsPalindrome(n))
					continue;
				bool ok = true;
				for (int k = 1; k < 50; k++)
				{
					n = Common.AddLargeInt(n, new string(n.Reverse().ToArray()));
					if (Common.IsPalindrome(n))
					{
						ok = false;
						break;
					}
				}
				if (ok)
					count++;
			}

			return count.ToString();
		}
	}
}
