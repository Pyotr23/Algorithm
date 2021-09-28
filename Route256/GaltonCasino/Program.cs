using System;
using System.Linq;

namespace Route256.ThreeStars.GaltonCasino
{
    class Program
    {
        static void Main(string[] args)
        {
            var setCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < setCount; i++)
            {
                var depth = int.Parse(Console.ReadLine());
                var result = 0;
                for (var j = 0; j < depth; j++)
                {
                    var count = (int)Math.Pow(2, depth - j - 1);
                    result += Console
                        .ReadLine()
                        .Split(' ')
                        .Select((x, ind) => IsOuterHex(j, ind)
                            ? int.Parse(x) * count
                            : int.Parse(x) * count * 2)
                        .Sum();
                }

                Console.WriteLine(result);
            }
        }

        private static bool IsOuterHex(int rowIndex, int hexIndex)
        {
            return rowIndex < 2 
                   || hexIndex == 0 
                   || hexIndex == rowIndex;
        }
    }
}