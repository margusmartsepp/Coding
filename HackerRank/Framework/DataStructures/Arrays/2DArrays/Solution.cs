using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Util;

namespace Framework.DataStructures.Arrays._2DArrays
{
    public class Solution
    {
        public static void Main()
        {
            var source = Enumerable.Range(0, 6).Select(o => GetInts.ToList()).ToList();
            var result = Enumerable.Range(0, 4).SelectMany(
                i => Enumerable.Range(0, 4).Select(
                    j => SelectPattern(source, j, i).Sum())).Max();
            Console.Write(result);
        }

        private static IEnumerable<int> GetInts => Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? new string[0], int.Parse);
        private static IEnumerable<int> SelectPattern(IReadOnlyList<IReadOnlyList<int>> arr, int i, int j)
        {
            return new[]
            {
                arr[i][j], arr[i][j + 1], arr[i][j + 2],
                arr[i + 1][j + 1],
                arr[i + 2][j], arr[i + 2][j + 1], arr[i + 2][j + 2]
            };
        }
    }
            
    public class Sample : IoTest
    {
        public Sample()
        {
            Proccess = Solution.Main;
            Input = "1 1 1 0 0 0\n0 1 0 0 0 0\n1 1 1 0 0 0\n0 0 2 4 4 0\n0 0 0 2 0 0\n0 0 1 2 4 0";
            ExpectedOutput = "19";
        }
    }
}