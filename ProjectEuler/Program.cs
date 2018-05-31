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

			p = new Problem093();
			Console.WriteLine("Result = " + p.GetResult());
		
			Console.ReadKey();
		}
	}
}
