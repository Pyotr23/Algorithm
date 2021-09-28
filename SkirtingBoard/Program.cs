using System;

namespace Route256.OneStar.SkirtingBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = Console
                .ReadLine()
                .Split(' ');
            var maxLength = int.Parse(inputs[0]);
            var totalLength = int.Parse(inputs[1]);
            var res = totalLength % maxLength == 0
                ? totalLength / maxLength
                : totalLength / maxLength + 1;
            Console.WriteLine(res);
        }
    }
}