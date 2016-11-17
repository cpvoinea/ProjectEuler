using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem064 : IProblem
    {
        class RootForm
        {
            struct Fraction
            {
                internal int Up;
                internal int Down;

                public Fraction Next(int n)
                {
                    int d = (n - Up * Up) / Down;
                    int a = 1;
                    while ((Up - d * a) * (Up - d * a) < n)
                        a++;
                    a--;
                    return new Fraction { Up = d * a - Up, Down = d };
                }

                public override bool Equals(object obj)
                {
                    var f = (Fraction)obj;
                    return f.Up == Up && f.Down == Down;
                }
                public override int GetHashCode()
                {
                    return Up.GetHashCode() + Down.GetHashCode();
                }
            }

            readonly List<Fraction> _period = new List<Fraction>();

            internal bool IsOddPeriod { get { return _period.Count % 2 == 1; } }

            internal RootForm(int n)
            {
                int r = 1;
                while (r * r <= n)
                    r++;
                r--;
                int d = n - r * r;
                if (d == 0)
                    return;
                int a = 1;
                while ((r - d * a) * (r - d * a) < n)
                    a++;
                a--;

                Fraction f = new Fraction { Up = d * a - r, Down = d };
                while (true)
                {
                    if (_period.Contains(f))
                        return;
                    _period.Add(f);
                    f = f.Next(n);
                }
            }
        }

        public string GetResult()
        {
            int count = 0;
            for(int i = 2; i <= 10000; i++)
            {
                var r = new RootForm(i);
                if (r.IsOddPeriod)
                    count++;
            }

            return count.ToString();
        }
    }
}
