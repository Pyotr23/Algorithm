using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Route256.ThreeStars.GaltonCasino
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<string>(File.ReadAllLines("casino.txt"));
            var setCount = int.Parse(queue.Dequeue());
            for (var i = 0; i < setCount; i++)
            {
                var depth = int.Parse(queue.Dequeue());
                var result = (long) 0;
                for (var levelIndex = 0; levelIndex < depth; levelIndex++)
                {
                    var count = (int)Math.Pow(2, depth - levelIndex - 1);
                    result = queue.Dequeue()
                        .Split(' ')
                        .Select((x, ind) => IsOuterHex(levelIndex, ind)
                            ? int.Parse(x) * count
                            : int.Parse(x) * count * 2)
                        .Aggregate(result, (current, value) => current + value);
                }

                if (result == 0)
                {
                    Console.WriteLine("0 1");
                    continue;
                }
                
                var pathCount = depth == 1
                    ? 1
                    : depth * 2 - 2;
                
                var divisor = GetGreatestCommonDivisor(Math.Abs(result), pathCount);
                var nominator = result / divisor;
                var denominator = pathCount / divisor;
                
                Console.WriteLine(nominator + " " + denominator);
            }
        }

        private static bool IsOuterHex(int rowIndex, int hexIndex)
        {
            return rowIndex < 2 
                   || hexIndex == 0 
                   || hexIndex == rowIndex;
        }

        private static long GetGreatestCommonDivisor(long a, long b)
        {
            while (true)
            {
                if (a == b) 
                    return a;

                var max = Math.Max(a, b);
                var min = Math.Min(a, b);
                a = max - min;
                b = min;
            }
        }
    }
}