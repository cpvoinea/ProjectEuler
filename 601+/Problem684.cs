namespace ProjectEuler
{
    class Problem684 : IProblem
    {

        public object GetResult()
        {
            const int MOD = 1000000007;
            long result = 0;
            long[] fibo = new long[91];
            long[] k = new long[91];
            int[] r = new int[91];
            long[] pow = new long[91];
            pow[0] = 1;
            pow[1] = 1;
            long a = 1, b = 1;
            for(int i = 2; i <= 90; i++)
            {
                fibo[i] = b;
                k[i] = b / 9;
                r[i] = (int)(b % 9);
                pow[i] = (pow[i - 1] * pow[i-2]) % MOD;
                long from = k[i - 1] + k[i - 2];
                for (long j = from; j < k[i]; j++)
                    pow[i] = (pow[i] * 10) % MOD;

                long P = (MOD + (6 * (pow[i] - 1) % MOD) - (9 * k[i] % MOD)) % MOD;
                long T = (pow[i] * (r[i] * (r[i] + 3) / 2) - r[i]) % MOD;
                result = (result + P + T) % MOD;

                long c = a + b;
                a = b;
                b = c;
            }

            return result;
        }
    }
}
