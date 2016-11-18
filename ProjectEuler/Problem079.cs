using System.Collections.Generic;
using System.IO;

namespace ProjectEuler
{
    class Problem079 : IProblem
    {
        struct Digit
        {
            internal List<byte> Left;
            internal List<byte> Right;
            public Digit(byte left, byte right)
            {
                Left = new List<byte> { left };
                Right = new List<byte> { right };
            }
        }

        public string GetResult()
        {
            Dictionary<byte, Digit> digits = new Dictionary<byte, Digit>();
            using(StreamReader sr = new StreamReader("Problem079.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                }
            }

            return "";
        }
    }
}
