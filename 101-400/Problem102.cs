using System.IO;

namespace ProjectEuler
{
    class Problem102 : IProblem
    {
        struct Point
        {
            internal int X;
            internal int Y;

            internal Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        int Sign(Point a, Point b, Point c)
        {
            return (a.X - c.X) * (b.Y - c.Y) - (b.X - c.X) * (a.Y - c.Y);
        }

        bool IsInTriangle(Point a, Point b, Point c)
        {
            Point z = new Point(0, 0);
            bool b1 = Sign(z, a, b) < 0;
            bool b2 = Sign(z, b, c) < 0;
            bool b3 = Sign(z, c, a) < 0;
            return b1 == b2 && b2 == b3;
        }

        public object GetResult()
        {
            int count = 0;
            using (StreamReader sr = File.OpenText("Resources\\Problem102.txt"))
                while (!sr.EndOfStream)
                {
                    string[] coords = sr.ReadLine().Split(',');
                    Point a = new Point(int.Parse(coords[0]), int.Parse(coords[1]));
                    Point b = new Point(int.Parse(coords[2]), int.Parse(coords[3]));
                    Point c = new Point(int.Parse(coords[4]), int.Parse(coords[5]));

                    if (IsInTriangle(a, b, c))
                        count++;
                }

            return count;
        }
    }
}
