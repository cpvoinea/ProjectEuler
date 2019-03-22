using System;

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
            //SpecialNumbers.Print(SpecialNumbers.Triangle(698));
            Console.WriteLine("Result = " + new Problem577().GetResult());
        }
    }
}
