namespace ProjectEuler
{
	class Problem031 : IProblem
	{
		int[] coins = new int[] { 1, 2, 5, 10, 20, 50, 100, 200 };

		int GetCombinationCount(int coinVal, int maxIndex)
		{
			if (coinVal == 1 || maxIndex == 0)
				return 1;
			int maxVal = coins[maxIndex];
			int n = coinVal / maxVal;
			int r = coinVal % maxVal;
			int s = 0;
			for (int i = 0; i <= n; i++)
				s += GetCombinationCount(maxVal * i + r, maxIndex - 1);
			return s;
		}

		public string GetResult()
		{
			int len = 7; //coins.Length - 1;
			return GetCombinationCount(coins[len], len).ToString();
		}
	}
}
