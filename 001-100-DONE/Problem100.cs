namespace ProjectEuler
{
    class Problem100 : IProblem
    {
        public object GetResult()
        {
            long limit = 1000000000000;
            // x(n) = a(n)*b(n), y(n) = a(n)*c(n)
            // a(n+1) = b(n)
            // c(n+1) = (b(n)+c(n)) / (n%2+1)
            // b(n+1) = c(n+1) + b(n)*(2-n%2)
            // a1=1, b1=3, c1=1
            long a = 1, b = 3, c = 1;
            long s = a * (b + c);
            int n = 1;
            while (s < limit)
            {
                a = b;
                c = (b + c) / (n % 2 + 1);
                b = c + b * (2 - n % 2);
                s = a * (b + c);
                n++;
            }
            return (a * b);
        }
    }
}
