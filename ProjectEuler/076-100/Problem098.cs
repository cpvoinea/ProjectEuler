using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Problem098 : IProblem
    {
        public string GetResult()
        {
            string[] words = Common.GetTextFromFile("Resources\\Problem098.txt").Split(',').Select(w => w.Trim('"')).ToArray();

            Dictionary<string, string> anagrams = new Dictionary<string, string>();
            foreach (string w1 in words)
            {
                foreach (string w2 in words)
                    if (w1.Length == w2.Length && w1 != w2)
                    {
                        List<char> c1 = w1.ToCharArray().ToList();
                        foreach (char c2 in w2)
                            if (c1.Contains(c2))
                                c1.Remove(c2);
                            else
                                break;
                        if (c1.Count == 0 && !anagrams.ContainsKey(w1) && !anagrams.ContainsKey(w2))
                            anagrams.Add(w1, w2);
                    }
            }

            long maxSquare = (long)Math.Pow(10, anagrams.Keys.Max(w => w.Length));
            long n = 1;
            long n2 = n * n;
            List<long> squares = new List<long>();
            while (n2 < maxSquare)
            {
                squares.Add(n2);
                n2 += 2 * n + 1;
                n++;
            }

            Dictionary<string, List<long>> candidates = new Dictionary<string, List<long>>();
            foreach (long s in squares)
                foreach (string a in anagrams.Keys)
                    if (a.Length == s.ToString().Length)
                    {
                        Dictionary<char, int> map = new Dictionary<char, int>();
                        bool ok = true;
                        long v = s;
                        for (int i = a.Length - 1; i >= 0; i--)
                        {
                            if (v == 0)
                            {
                                ok = false;
                                break;
                            }
                            int d = (int)(v % 10);
                            if (map.ContainsKey(a[i]))
                            {
                                if (map[a[i]] != d)
                                {
                                    ok = false;
                                    break;
                                }
                            }
                            else
                            {
                                foreach (char c in map.Keys)
                                    if (map[c] == d && c != a[i])
                                    {
                                        ok = false;
                                        break;
                                    }
                                if (!ok)
                                    break;
                                map[a[i]] = d;
                            }
                            v /= 10;
                        }
                        if (!ok || v > 0)
                            continue;

                        string b = anagrams[a];
                        v = 0;
                        for (int i = 0; i < b.Length; i++)
                        {
                            v = v * 10 + map[b[i]];
                        }
                        if (v.ToString().Length != s.ToString().Length)
                            continue;
                        if (squares.Contains(v))
                        {
                            if (!candidates.ContainsKey(a))
                                candidates.Add(a, new List<long>(new[] { s, v }));
                            else
                            {
                                candidates[a].Add(s);
                                candidates[a].Add(v);
                            }
                        }
                    }

            long maxCand = 0;
            foreach (string s in candidates.Keys)
            {
                foreach (long v in candidates[s])
                    if (v > maxCand)
                        maxCand = v;
            }

            return maxCand.ToString();
        }
    }
}
