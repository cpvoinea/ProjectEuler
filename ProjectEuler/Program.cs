﻿using System;

namespace ProjectEuler
{
    class Program
    {
        /// <summary>
        /// http://projecteuler.net/problems
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            IProblem p;

            p = new Problem650();
            Console.WriteLine("Result = " + p.GetResult());
        }
    }
}
