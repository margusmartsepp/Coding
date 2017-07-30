using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Util;

namespace Framework.DataStructures.Arrays.ArraysDs
{
    public class Solution
    {
        public static void Main()
        {
            Console.ReadLine(); //ignore N

            var result = string.Join(" ", GetInts.Reverse().ToList());
            Console.Write(result);
        }

        private static IEnumerable<int> GetInts => Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? new string[0], int.Parse);
    }

    public class Sample : IoTest
    {
        public Sample()
        {
            Proccess = Solution.Main;
            Input = "4\n1 4 3 2";
            ExpectedOutput = "2 3 4 1";
        }
    }
}