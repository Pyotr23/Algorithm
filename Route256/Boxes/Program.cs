using System;
using System.Linq;

namespace Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            var boxCount = int.Parse(Console.ReadLine());
            var numbers = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToArray();
            
            var result = 0;
            for (var i = 0; i < boxCount; i += 2)
            {
                result += numbers[i + 1] - numbers[i];
            }

            Console.WriteLine(result);
        }
    }
}