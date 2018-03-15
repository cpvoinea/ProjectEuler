using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace ProjectEuler
{
    class Problem079 : IProblem
    {
        Dictionary<byte, Digit> _digits = new Dictionary<byte, Digit>();

        class Digit
        {
            readonly byte _value;

            internal byte Value { get { return _value; } }
            internal HashSet<Digit> Left { get; private set; }
            internal HashSet<Digit> Right { get; private set; }
            internal int Count { get { return Left.Count + Right.Count; } }

            public Digit(byte value)
            {
                _value = value;
                Left = new HashSet<Digit>();
                Right = new HashSet<Digit>();
            }

            public override string ToString()
            {
                return string.Format("{0}: Left({1}) Right({2})", _value, string.Join(", ", Left.Select(v => v.Value.ToString()).ToArray()), string.Join(", ", Right.Select(v => v.Value.ToString()).ToArray()));
            }
        }

        void Add(Digit d)
        {
            foreach (var l in d.Left)
            {
                foreach (var ll in l.Left)
                    if (!d.Left.Contains(ll))
                        d.Left.Add(ll);
            }
            foreach(var r in d.Right)
            {
                foreach (var rr in r.Right)
                    if (!d.Right.Contains(rr))
                        d.Right.Add(rr);
            }
        }

        Digit GetOrAdd(byte d)
        {
            if (_digits.ContainsKey(d))
                return _digits[d];
            else
            {
                var dig = new Digit(d);
                _digits.Add(d, dig);
                return dig;
            }
        }

        public string GetResult()
        {
            using (StreamReader sr = new StreamReader("Problem079.txt"))
            {
                while (!sr.EndOfStream)
                {
                    var s = sr.ReadLine().ToCharArray().Select(c => GetOrAdd(byte.Parse(c.ToString()))).ToArray();
                    s[1].Left.Add(s[0]);
                    s[1].Right.Add(s[2]);
                }
            }

            var d = _digits.Aggregate((i, j) => i.Value.Count > j.Value.Count ? i : j).Value;
            Add(d);
            foreach (var l in d.Left)
                Add(l);
            foreach (var r in d.Right)
                Add(r);

            string result = "";

            return "";
        }
    }
}
