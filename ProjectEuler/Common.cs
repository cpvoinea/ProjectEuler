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

        internal static BitArray[] GeneratePrimes(long limit, int intervals)
        {
            BitArray[] bits = new BitArray[intervals];
            int oneLimit = (int)(limit / intervals);
            for (int i = 0; i < intervals; i++)
                bits[i] = new BitArray(oneLimit, false);
            bits[0][0] = false;
            bits[0][1] = false;
            for (long i = 0; i * i <= limit; i++)
            {
                int k = (int)(i / oneLimit);
                int j = (int)(i % oneLimit);
                if (!bits[k][j])
                    continue;
                for (long n = i * i; n <= limit; n += i)
                {
                    k = (int)(n / oneLimit);
                    j = (int)(n % oneLimit);
                    bits[k][j] = false;
                }
            }

            return bits;
        }

        internal static long Totient(long n, long p, long f, BitArray[] isPrime, int oneLimit)
        {
            if (n == 1)
                return f;

            if (isPrime[(int)(n / oneLimit)][(int)(n % oneLimit)])
                return f / n * (n - 1);

            while (!isPrime[(int)(p / oneLimit)][(int)(p % oneLimit)] || n % p > 0)
                p++;

            long m = n / p;
            while (m % p == 0)
                m /= p;
            return Totient(m, p + 1, f / p * (p - 1), isPrime, oneLimit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n">number to calculate Totient function for</param>
        /// <param name="p">smallest prime factor to check against (initialize to 2)</param>
        /// <param name="f">current totient value (initialize to n)</param>
        /// <param name="isPrime">ciurul lui Eratorstene cu numerele prime ramase</param>
        /// <returns></returns>
        internal static int Totient(int n, int p, int f, BitArray isPrime)
        {
            if (n == 1)
                return f;

            if (isPrime[n])
                return f / n * (n - 1);

            while (!isPrime[p] || n % p > 0)
                p++;

            int m = n / p;
            while (m % p == 0)
                m /= p;
            return Totient(m, p + 1, f / p * (p - 1), isPrime);
        }

        /// <summary>
        /// Excluding limit
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
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

        internal static bool IsAllPandigital(long n)
        {
            bool[] digits = new bool[9];
            while (n > 0)
            {
                int d = (int)(n % 10);
                if (d == 0 || digits[d - 1])
                    return false;
                digits[d - 1] = true;
                n /= 10;
            }
            return digits.All(d => d);
        }

        internal static bool IsPalindrome(string n)
        {
            int l = n.Length;
            for (int i = 0; i <= l / 2; i++)
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

        internal static string SubtractLargeInt(string n1, string n2)
        {
            if (n1 == "" || n2 == "")
                return n1 + n2;

            int l1 = n1.Length;
            int l2 = n2.Length;
            bool positive = GreaterThanLargeInt(n1, n2);
            if (!positive)
                return "-" + SubtractLargeInt(n2, n1);
            int min = positive ? l1 : l2;
            string result = "";
            int r = 0;
            for (int i = 0; i < min; i++)
            {
                int s = n1[l1 - i - 1] - n2[l2 - i - 1] - r;
                if (s < 0)
                {
                    r = 1;
                    s = -s;
                }
                else
                    r = 0;
                result = s + result;
            }

            if (r == 0)
                return n1.Substring(0, l1 - min) + result;
            else
                return (SubtractLargeInt(n1.Substring(0, l1 - min), "1") + result).TrimStart('0');
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

        internal static bool GreaterThanLargeInt(string a, string b)
        {
            if (a.Length > b.Length)
                return true;
            if (a.Length < b.Length)
                return false;
            int i = 0;
            while (i < a.Length)
            {
                if (a[i] < b[i])
                    return false;
                else if (a[i] > b[i])
                    return true;
                i++;
            }
            return false;
        }

        internal static string GetTextFromFile(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
                return sr.ReadToEnd();
        }
    }
}
