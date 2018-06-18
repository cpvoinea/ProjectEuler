using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem336 : IProblem
    {
        const int limit = 11;
        const int idx = 2011;
        readonly List<string> list = new List<string>();

        string Swap(string s, int p)
        {
            string newS = s.Substring(0, p);
            for (int i = s.Length - 1; i >= p; i--)
                newS += s[i];
            return newS;
        }

        void AddToList(string w, int p)
        {
            if (p < 0)
                list.Add(w);
            else
            {
                string nw = Swap(w, p);
                if (p >= limit - 2)
                    AddToList(nw, p - 1);
                else
                    for (int i = p + 1; i < limit - 1; i++)
                    {
                        string nnw = Swap(nw, i);
                        AddToList(nnw, p - 1);
                    }
            }
        }

        public string GetResult()
        {
            string w = "";
            for (int i = 0; i < limit; i++)
                w += (char)('A' + i);

            AddToList(w, limit - 2);
            list.Sort();
            return list[idx - 1];
        }
    }
}
