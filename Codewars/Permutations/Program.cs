using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Four.Permutations
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            SinglePermutations("aabb").ForEach(Console.WriteLine);
        }

        private static List<string> SinglePermutations(string s) 
            => s.Length < 2 
                ? new List<string> { s } 
                : SinglePermutations(s[1..])
                    .SelectMany(x => Enumerable
                        .Range(0, x.Length + 1)
                        .Select((_, i) => x[..i] + s[0] + x[i..]))
                .Distinct()
                .ToList();
    }
}