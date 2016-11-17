using System.Collections.Generic;

namespace ProjectEuler
{
	class Problem017 : IProblem
	{
		Dictionary<string, int> GetWordCount1000()
		{
			Dictionary<string, int> count = new Dictionary<string, int>();

			int dCount = 9 * 10 + 100;
			count.Add("one", dCount + 1);
			count.Add("two", dCount);
			count.Add("three", dCount);
			count.Add("four", dCount);
			count.Add("five", dCount);
			count.Add("six", dCount);
			count.Add("seven", dCount);
			count.Add("eight", dCount);
			count.Add("nine", dCount);

			dCount = 10;
			count.Add("ten", dCount);
			count.Add("eleven", dCount);
			count.Add("twelve", dCount);
			count.Add("thirteen", dCount);
			count.Add("fourteen", dCount);
			count.Add("fifteen", dCount);
			count.Add("sixteen", dCount);
			count.Add("seventeen", dCount);
			count.Add("eighteen", dCount);
			count.Add("nineteen", dCount);

			dCount = 10 * 10;
			count.Add("twenty", dCount);
			count.Add("thirty", dCount);
			count.Add("forty", dCount);
			count.Add("fifty", dCount);
			count.Add("sixty", dCount);
			count.Add("seventy", dCount);
			count.Add("eighty", dCount);
			count.Add("ninety", dCount);

			dCount = 9 * 99;
			count.Add("and", dCount);

			dCount = 9 * 100;
			count.Add("hundred", dCount);

			dCount = 1;
			count.Add("thousand", dCount);

			return count;
		}

		public string GetResult()
		{
			Dictionary<string, int> count = GetWordCount1000();
			long s = 0;
			foreach (string word in count.Keys)
				s += word.Length * count[word];
			return s.ToString();
		}
	}
}
