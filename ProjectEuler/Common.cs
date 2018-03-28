using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler
{
    public class Common
    {
        internal static int Fact(int n)
        {
            if (n <= 1)
                return 1;
            return n * Fact(n - 1);
        }

        internal static int GetSumOfDivisorsOf(int n)
        {
            if (n == 1)
                return 1;

            double sqrt = Math.Sqrt(n);
            int s = 1;
            for (int i = 2; i <= sqrt; i++)
                if (n % i == 0)
                    s += i + (i != n / i ? n / i : 0);
            return s;
        }

        internal static int GetSumOfDigits(string str)
        {
            int n = 0;
            foreach (char c in str)
                n += c - '0';
            return n;
        }

        internal static BitArray GeneratePrimes(int limit)
        {
            BitArray bits = new BitArray(limit + 1, true);
            bits[0] = false;
            bits[1] = false;
            for (int i = 0; i * i <= limit; i++)
            {
                if (bits[i])
                {
                    for (int j = i * i; j <= limit; j += i)
                    {
                        bits[j] = false;
                    }
                }
            }
            return bits;
        }

        internal static List<int> GetPrimeNumbersLowerThan(int limit)
        {
            var primes = GeneratePrimes(limit);
            List<int> result = new List<int>();
            for (int i = 2; i < limit; i++)
                if (primes[i])
                    result.Add(i);
            return result;
        }

		internal static bool IsPrime(long n)
		{
			if (n == 1)
				return false;

			double sqrt = Math.Sqrt(n);
			for (long i = 2; i <= sqrt; i++)
				if (n % i == 0)
					return false;
			return true;
		}

		internal static bool IsPandigital(string n, int from = 1, int to = 9)
		{
			bool[] marked = new bool[to - from + 1];
			foreach (char c in n)
				if (c - 48 < from || c - 48 > to || marked[c - 48])
					return false;
				else
					marked[c - 48] = true;

			return true;
		}

		internal static bool IsPalindrome(string n)
		{
			int l = n.Length;
			for (int i = 0; i < l / 2; i++)
				if (n[i] != n[l - i - 1])
					return false;
			return true;
		}

		internal static string AddLargeInt(string n1, string n2)
		{
			if (n1 == "" || n2 == "")
				return n1 + n2;

			int l1 = n1.Length;
			int l2 = n2.Length;
			int min = l1 < l2 ? l1 : l2;
			string result = "";
			int r = 0;
			for (int i = 0; i < min; i++)
			{
				int s = n1[l1 - i - 1] + n2[l2 - i - 1] - 96 + r;
				result = (s % 10) + result;
				r = s / 10;
			}

			if (l1 < l2)
				return (AddLargeInt(n2.Substring(0, l2 - l1), r.ToString()) + result).TrimStart('0');
			else
				return (AddLargeInt(n1.Substring(0, l1 - l2), r.ToString()) + result).TrimStart('0');
		}

		internal static string MultiplyLargeInt(string n1, string n2)
		{
			if (n1 == "" || n2 == "")
				return "0";

			int l1 = n1.Length;
			int l2 = n2.Length;

			int d = n1[l1 - 1] - 48;
			string m = "";
			int r = 0;
			for (int i = 0; i < l2; i++)
			{
				int s = (n2[l2 - i - 1] - 48) * d + r;
				m = (s % 10) + m;
				r = s / 10;
			}
			m = r + m;

			string n = MultiplyLargeInt(n1.Substring(0, l1 - 1), n2) + "0";
			return AddLargeInt(m, n).TrimStart('0');
		}

        internal static string GetTextFromFile(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
                return sr.ReadToEnd();
        }
	}
}
