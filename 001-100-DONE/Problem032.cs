using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Problem032 : IProblem
    {
        public object GetResult()
        {
            List<long> list = new List<long>();
            #region comment
            //for (int i = 1; i <= 10000; i++)
            //{
            //    int lastI = i % 10;
            //    //if (lastI != 0 && lastI != 1 && lastI != 5)
            //    {
            //        int firstI = i / 10;
            //        //if (firstI != lastI)
            //            for (int j = 1; j <= 10000; j++)
            //            {
            //                int lastJ = j % 10;
            //                //if (lastJ != 0 && lastJ != 1 && lastJ != 5 && lastJ != firstI && lastJ != lastI)
            //                {
            //                    int firstJ = j / 100;
            //                    //if (firstJ != lastJ && firstJ != firstI && firstJ != lastI)
            //                    {
            //                        int secondJ = (j / 10) % 10;
            //                        //if (secondJ != 0 && secondJ != firstJ && secondJ != lastJ && secondJ != firstI && secondJ != lastI)
            //                        {
            //                            int m = i * j;
            //                            if (//m >= 1234 &&
            //                                !list.Contains(m))
            //                            {
            //                                //if (m <= 9876)
            //                                {
            //                                    string str = "" + i + j + m;
            //                                    if (str.Length == 9)
            //                                    {
            //                                        bool[] marked = new bool[9];
            //                                        bool ok = true;
            //                                        foreach (char c in str)
            //                                            if (//c < 49 || c > 57 || 
            //                                                c == 48 || marked[c - 49])
            //                                            {
            //                                                ok = false;
            //                                                break;
            //                                            }
            //                                            else
            //                                                marked[c - 49] = true;
            //                                        if (ok)
            //                                        {
            //                                            Console.WriteLine(str);
            //                                            list.Add(m);
            //                                        }
            //                                    }
            //                                }
            //                                //else
            //                                //	break;
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //    }
            //}
            #endregion

            for (long i = 1; i <= 10000; i++)
            {
                for (long j = 1; j < 100000 / i; j++)
                {
                    long m = i * j;
                    string str = "" + i + j + m;
                    if (str.Length == 9 && !list.Contains(m) && Common.IsPandigital(str))
                        list.Add(m);
                }
            }

            return list.Sum();
        }
    }
}
