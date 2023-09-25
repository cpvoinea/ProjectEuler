using System;

namespace ProjectEuler
{
    class Problem743 : IProblem
    {
        const int K = 100000000;
        const int MOD = 1000000007;
        const int PK = 494499948; // = 2^(10^8) % MOD
        const int PKP = 803895745; // = 2^(10^16) % MOD

        public object GetResult()
        {
            long s = PKP;
            for(int z = 1; z <= K / 2; z++)
            {
                s = (s + B(K, z) * P(K - 2 * z)) % MOD;
            }

            return s;
        }

        long B(int n, int k)
        {
            return Comb(n, k) * Comb(n - k, k) % MOD;
        }

        int P(int p)
        {
            return (int)((long)Math.Pow(PK, p) % MOD);
        }

        int Comb(int n, int k)
        {
            if (k > n / 2)
                k = n - k;
            long s = 1;
            for (int i = 0; i < k; i++)
                s *= n - i;
            for (int i = 2; i <= k; i++)
                s /= i;
            return (int)s % MOD;
        }
    }
}
