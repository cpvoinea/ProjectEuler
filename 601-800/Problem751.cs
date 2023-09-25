using System;

namespace ProjectEuler
{
    class Problem751 : IProblem
    {
        double Next(double a)
        {
            return ((int)a) * (a - ((int)a) + 1);
        }

        public object GetResult()
        {
            const double t = 2.223561019313554106173177;
            double a = t;

            Console.WriteLine((int)a);
            for (int j = 0; j < 20; j++)
            {
                a = Next(a);
                Console.WriteLine((int)a);
            }

            return t;
        }
    }
}
