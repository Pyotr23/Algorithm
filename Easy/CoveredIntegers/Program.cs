using System;
using System.Collections.Generic;

namespace CoveredIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            var ranges = new[]
            {
                new[] {1, 2},
                new[] {3, 4},
                new[] {5, 6}
            };
            Console.WriteLine(IsCovered(ranges, 1, 6));

            ranges = new[]
            {
                new[] {1, 10},
                new[] {10, 20}
            };
            Console.WriteLine(IsCovered(ranges, 21, 21));
        }
        
        public static bool IsCovered(int[][] ranges, int left, int right)
        {
            var hashSet = CreateHashSet(ranges);
            
            for (var i = left; i <= right; i++)
            {
                if (hashSet.Add(i))
                    return false;;
            }

            return true;
        }

        private static HashSet<int> CreateHashSet(int[][] ranges)
        {
            var hashSet = new HashSet<int>();
            
            foreach (var range in ranges)
            {
                for (var i = range[0]; i <= range[1]; i++)
                {
                    hashSet.Add(i);
                }
            }

            return hashSet;
        }
    }
}