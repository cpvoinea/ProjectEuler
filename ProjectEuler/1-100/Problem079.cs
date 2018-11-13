using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace ProjectEuler
{
    class Problem079 : IProblem
    {
        readonly Dictionary<byte, List<byte>> _values = new Dictionary<byte, List<byte>>();

        void AddOrUpdate(byte l, byte r)
        {
            if (_values.ContainsKey(l))
            {
                if (!_values[l].Contains(r))
                    _values[l].Add(r);
            }
            else
            {
                _values.Add(l, new List<byte> { r });
            }

            if (!_values.ContainsKey(0))
                _values.Add(0, new List<byte>());
        }

        public string GetResult()
        {
            using (StreamReader sr = new StreamReader("Resources\\Problem079.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    byte l = byte.Parse(s[0].ToString());
                    byte d = byte.Parse(s[1].ToString());
                    byte r = byte.Parse(s[2].ToString());

                    AddOrUpdate(l, d);
                    AddOrUpdate(d, r);
                    AddOrUpdate(l, r);
                }
            }

            return string.Join("", _values.OrderByDescending(kv => kv.Value.Count).Select(kv => kv.Key.ToString()).ToArray());
        }
    }
}
