using System.Linq;
using System.IO;

namespace ProjectEuler
{
	class Problem022 : IProblem
	{
		int Value(string name)
		{
			int s = 0;
			for (int i = 0; i < name.Length; i++)
				s += name[i] - 64;
			return s;
		}

		public string GetResult()
		{
			string namesStr = Common.GetTextFromFile("Resources\\Problem022.txt");
			string[] names = namesStr.Split(',').Select(s => s.Trim('"')).OrderBy(s => s).ToArray();

			long sum = 0;
			for (int i = 0; i < names.Length; i++)
				sum += (i + 1) * Value(names[i]);

			return sum.ToString();
		}
	}
}
