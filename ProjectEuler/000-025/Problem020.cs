namespace ProjectEuler
{
	class Problem020 : IProblem
	{
		public string GetResult()
		{
			string fact = "1";
			for (int i = 1; i <= 100; i++)
				fact = Common.MultiplyLargeInt(i.ToString(), fact);
			int s = 0;
			for (int i = 0; i < fact.Length; i++)
				s += fact[i] - 48;

			return s.ToString();
		}
	}
}
