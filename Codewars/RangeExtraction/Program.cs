using System;
using System.Collections.Generic;

namespace Codewars.Four.RangeExtraction
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine(
                Extract(new[] {-6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20, 22}));
            Console.WriteLine(
                Extract(new[] { -3, -2, -1, 2, 10, 15, 16, 18, 19, 20 }));
        }

        private static string Extract(int[] args)
        {
            switch (args.Length)
            {
                case 0:
                    return string.Empty;
                case 1:
                    return args[0].ToString();
            }

            var result = new List<string>(args.Length);
            var start = args[0];
            var end = args[0];
            
            for (var i = 1; i < args.Length; i++)
            {
                if (args[i] == args[i - 1] + 1)
                {
                    end = args[i];
                    continue;
                }
                
                Write(result, start, end);

                start = args[i];
                end = args[i];
            }

            Write(result, start, end);
            
            return string.Join(",", result);  
        }

        private static void Write(List<string> result, int start, int end)
        {
            if (start == end)
                result.Add(start.ToString());
            else if (start == end - 1)
                result.AddRange(new []{start.ToString(), end.ToString()});
            else
                result.Add($"{start.ToString()}-{end.ToString()}");
        }
    }
}