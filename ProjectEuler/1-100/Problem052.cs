using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Problem052 : IProblem
    {
        bool Check(string n, string m)
        {
            if (n.Length != m.Length)
                return false;
            List<char> chars = n.ToCharArray().ToList();
            foreach (char c in m)
            {
                if (!chars.Contains(c))
                    return false;
                chars.Remove(c);
            }
            return true;
        }

        public string GetResult()
        {
            string template = "111111";
            string n = template;
            bool found = false;
            while (!found)
            {
                bool ok = true;
                int i = 2;
                while (i < 7 && ok)
                {
                    ok = Check(n, Common.MultiplyLargeInt(n, i.ToString()));
                    i++;
                }
                if (ok)
                    return n;
                n = Common.AddLargeInt(n, "1");
                if (!n.StartsWith("1"))
                {
                    template += "1";
                    n = template;
                }
            }

            return "nope";
        }
    }
}
