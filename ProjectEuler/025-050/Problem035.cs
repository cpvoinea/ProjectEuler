namespace ProjectEuler
{
	class Problem035 : IProblem
	{
		public string GetResult()
		{
			int limit = 1000000;
			int count = 1;
			for (int i = 3; i < limit; i += 2)
			{
				if (Common.IsPrime(i))
				{
					bool ok = true;

					int n = i;
					int c = 0;
					int m = 1;
					while (n != 0)
					{
						int d = n % 10;
						if (d % 2 == 0)
						{
							ok = false;
							break;
						}

						c++;
						n /= 10;
						m *= 10;
					}
					m /= 10;

					n = i;
					for (int j = 0; j < c - 1; j++)
					{
						n = (n % 10) * m + n / 10;
						if (!Common.IsPrime(n))
						{
							ok = false;
							break;
						}
					}

					if (ok)
						count++;
				}
			}

			return count.ToString();
		}
	}
}
