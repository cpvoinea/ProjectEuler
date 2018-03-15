using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Problem059 : IProblem
    {
        bool IsPlainText(int b)
        {
            return b >= 32 && b < 123;
        }

        public string GetResult()
        {
            byte[] cipher = Common.GetTextFromFile("Resources\\Problem059.txt").Split(',').Select(n => byte.Parse(n)).ToArray();

            List<byte> letters = new List<byte>();
            for (char c = 'a'; c <= 'z'; c++)
                letters.Add((byte)c);
            string[] keyLetters = new string[3];
            for (int j = 0; j < 3; j++)
            {
                foreach (byte l in letters)
                {
                    bool isValid = true;
                    for (int i = j; i < cipher.Length; i += 3)
                    {
                        int d = cipher[i] ^ l;
                        if (!IsPlainText(d))
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid)
                        keyLetters[j] += (char)l;
                }
                //Console.WriteLine(keyLetters[j]);
            }

            string key = "god";
            int sum = 0;
            for(int i = 0; i < cipher.Length; i++)
            {
                sum += (byte)key[i % 3] ^ cipher[i];
            }

            return sum.ToString();
        }
    }
}
