using System;

namespace LeetCode.Easy.CoveredIntegers
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
            
            ranges = new[]
            {
                new[] {1, 50}
            };
            Console.WriteLine(IsCovered(ranges, 50, 50));
        }
        
        public static bool IsCovered(int[][] ranges, int left, int right)
        {
            switch (ranges.Length)
            {
                case 0:
                    return false;
                case 1:
                    return Math.Max(left, ranges[0][0]) == left 
                           && Math.Min(right, ranges[0][1]) == right;
            }

            var array = new int[51];
            
            foreach (var range in ranges)
            {
                for (var i = range[0]; i <= range[1]; i++)
                {
                    array[i] = 1;
                }
            }
            
            for (var i = left; i <= right; i++)
            {
                if (array[i] == 0)
                    return false;;
            }

            return true;
        }
    }
}