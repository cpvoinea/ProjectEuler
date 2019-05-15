using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ProjectEuler
{
    class Triangle
    {
        public int value;
        public Triangle left;
        public Triangle right;
        public bool leftClosed = false;
        public bool rightClosed = false;

        public Triangle(int value)
        {
            this.value = value;
        }

        public Triangle(int value, Triangle left, Triangle right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }

        public Triangle(List<int[]> lines)
        {
            List<Triangle> lastTriangleLine = new List<Triangle>();
            for (int i = lines.Count - 1; i > 0; i--)
            {
                List<Triangle> nextTriangleLine = new List<Triangle>();
                for (int j = 0; j <= i; j++)
                {
                    Triangle t = new Triangle(lines[i][j]);
                    if (i < lines.Count - 1)
                    {
                        t.left = lastTriangleLine[j];
                        t.right = lastTriangleLine[j + 1];
                    }

                    nextTriangleLine.Add(t);
                }

                lastTriangleLine = new List<Triangle>(nextTriangleLine);
            }

            value = lines[0][0];
            left = lastTriangleLine[0];
            right = lastTriangleLine[1];
        }

        public static Triangle Read(List<int[]> lines, int currentLine, List<Triangle> triangleLine = null)
        {
            if (currentLine == 0)
                return new Triangle(lines[0][0], triangleLine[0], triangleLine[1]);
            List<Triangle> newTriangleLine = new List<Triangle>();
            for (int i = 0; i <= currentLine; i++)
                if (currentLine < lines.Count - 1)
                    newTriangleLine.Add(new Triangle(lines[currentLine][i], triangleLine[i], triangleLine[i + 1]));
                else
                    newTriangleLine.Add(new Triangle(lines[currentLine][i]));

            return Read(lines, currentLine - 1, newTriangleLine);
        }

        public static Triangle Read(List<int[]> lines, int currentLine, int currentPos, int size)
        {
            Triangle t = new Triangle(lines[currentLine][currentPos]);
            if (size == 1)
                return t;
            t.left = Triangle.Read(lines, currentLine + 1, currentPos, size - 1);
            t.right = Triangle.Read(lines, currentLine + 1, currentPos + 1, size - 1);

            return t;
        }

        public void Write()
        {
            int count = 0;
            Console.WriteLine();
            List<Triangle> list = new List<Triangle>();
            list.Add(this);
            while (list.Count > 0)
            {
                List<Triangle> newList = new List<Triangle>();
                if (list[0].left != null)
                {
                    newList.Add(list[0].left);
                    foreach (Triangle t in list)
                    {
                        if (t != null)
                        {
                            Console.Write(t.value + " ");
                            newList.Add(t.right);
                        }
                        else
                            Console.Write("   ");
                        count++;
                    }
                    Console.WriteLine();
                }
                else
                {
                    foreach (Triangle t in list)
                    {
                        if (t != null)
                            Console.Write(t.value + " ");
                        else
                            Console.Write("   ");
                        count++;
                    }
                    Console.WriteLine();
                }

                list = new List<Triangle>(newList);
            }
            Console.WriteLine(count);
            Console.WriteLine();
        }
    }

    class Problem018 : IProblem
    {
        Dictionary<Triangle, int> maxSums = new Dictionary<Triangle, int>();

        int GetTriangleMaxSum(Triangle t)
        {
            if (t == null)
                return 0;
            if (maxSums.ContainsKey(t))
                return maxSums[t];

            if (t.leftClosed || t.left == null)
                return t.value + GetTriangleMaxSum(t.right);
            if (t.rightClosed || t.right == null)
                return t.value + GetTriangleMaxSum(t.left);

            if (t.left.value > t.right.value)
                t.right.leftClosed = true;
            else
                t.left.rightClosed = true;

            int leftSum = GetTriangleMaxSum(t.left);
            int rightSum = GetTriangleMaxSum(t.right);
            int s = t.value + (leftSum > rightSum ? leftSum : rightSum);
            maxSums.Add(t, s);

            return s;
        }

        public object GetResult()
        {
            StreamReader sr = new StreamReader("Resources\\Problem018.txt");
            List<int[]> lines = new List<int[]>();
            while (!sr.EndOfStream)
                lines.Add(sr.ReadLine().Split().Select(s => int.Parse(s)).ToArray());

            Triangle t1 = Triangle.Read(lines, 0, 0, lines.Count);
            sr.Close();
            //Triangle t2 = new Triangle(lines);

            int sum1 = GetTriangleMaxSum(t1);
            return sum1;
        }
    }
}
