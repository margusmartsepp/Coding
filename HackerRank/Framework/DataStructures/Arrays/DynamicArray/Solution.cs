using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Util;
using Xunit.Abstractions;

namespace Framework.DataStructures.Arrays.DynamicArray
{
    class Solution
    {
        private enum QueryType
        {
            Query1Xy = 1,
            Query2Xy = 2
        }

        private class ConstraintDto
        {
            public QueryType Query { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
        }

        public static void Main()
        {
            var nq = GetInts.ToArray();
            var inputs = new List<ConstraintDto>();

            for (var i = 0; i < nq[1]; i++)
            {
                var input = GetInts.ToArray();
                inputs.Add(new ConstraintDto{ Query = (QueryType)input[0], X = input[1], Y = input[2]});
            }

            foreach (var result in DynamicArray(inputs, nq[0]))
            {
                Console.Write($"{result}\n");
            }
        }

        private static IEnumerable<int> GetInts => Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? new string[0], int.Parse);

        private static IEnumerable<int> DynamicArray(IEnumerable<ConstraintDto> constraints, int n)
        {
            var results = new List<int>();
            var slots = new Dictionary<int, List<int>>();
            var last = 0;
            foreach (var constraint in constraints)
            {
                var key = (constraint.X ^ last) % n;
                if (constraint.Query == QueryType.Query1Xy)
                {
                    if (!slots.ContainsKey(key))
                    {
                        slots[key] = new List<int>();
                    }
                    slots[key].Add(constraint.Y);
                }
                else if (constraint.Query == QueryType.Query2Xy)
                {
                    var index = constraint.Y % slots[key].Count;
                    last = slots[key][index];
                    results.Add(last);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            return results;
        }
    }

    public class Sample : IoTest
    {
        public Sample()
        {
            Proccess = Solution.Main;
            Input = "2 5\n1 0 5\n1 1 7\n1 0 3\n2 1 0\n2 1 1";
            ExpectedOutput = "7\n3\n";
        }
    }
    
    public class BigSample : IoTestSkip
    {
        public BigSample(ITestOutputHelper output) : base(output)
        {
            Proccess = Solution.Main;
            Input = System.IO.File.ReadAllText(@"DataStructures\Arrays\DynamicArray\input09.txt"); 
            ExpectedOutput = System.IO.File.ReadAllText(@"DataStructures\Arrays\DynamicArray\output09.txt");
        }
    }
}