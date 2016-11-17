namespace ProjectEuler
{
	class Problem048 : IProblem
	{
		public string GetResult()
		{
			int target = 10;
			int limit = 1000;
			string result = "0";
			for (int i = 1; i <= limit; i++)
			{
				string n = i.ToString();
				for (int j = 1; j < i; j++)
				{
					n = Common.MultiplyLargeInt(n, i.ToString());
					int l = n.Length;
					if (l > target)
						n = n.Substring(l - target);
				}
				result = Common.AddLargeInt(result, n);
			}

			return result.Substring(result.Length - target);
		}
	}
}
