using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Four.CommentsStripper
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine(
            StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", 
                new[] { "#", "!" }));
        }

        private static string StripComments(string text, IEnumerable<string> commentSymbols)
        {
            var rows = text
                .Split("\n")
                .Select(str => string.Concat(str
                    .TakeWhile(s => !commentSymbols.Contains(s.ToString())))
                    .TrimEnd());
            return string.Join("\n", rows);
        }

    }
}