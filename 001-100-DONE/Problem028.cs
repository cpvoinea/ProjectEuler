﻿namespace ProjectEuler
{
    class Problem028 : IProblem
    {
        public object GetResult()
        {
            int n = 500;
            return ((16 * n * n * n + 30 * n * n + 26 * n + 3) / 3);
        }
    }
}
