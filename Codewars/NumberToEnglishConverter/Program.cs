using System;
using System.Collections.Generic;

namespace Codewars.Five.NumberToEnglishConverter
{
    internal static class Program
    {
        private static readonly Dictionary<int, string> Dictionary = new()
        {
            { 0, "zero" },
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" },
            { 5, "five" },
            { 6, "six" },
            { 7, "seven" },
            { 8, "eight" },
            { 9, "nine" },
            { 10, "ten" },
            { 11, "eleven" },
            { 12, "twelve" },
            { 13, "thirteen" },
            { 14, "fourteen" },
            { 15, "fifteen" },
            { 16, "sixteen" },
            { 17, "seventeen" },
            { 18, "eighteen" },
            { 19, "nineteen" },
            { 20, "twenty" },
            { 30, "thirty" },
            { 40, "forty" },
            { 50, "fifty" },
            { 60, "sixty" },
            { 70, "seventy" },
            { 80, "eighty" },
            { 90, "ninety" },
            { 100, "hundred" },
            { 1000, "thousand"}
        };

        internal static void Main()
        {
            Console.WriteLine(NumberToEnglish(6800));
            Console.WriteLine(NumberToEnglish(99999));
        }

        private static string NumberToEnglish(int n)
        {
            switch (n)
            {
                case < 0 or > 99999:
                    return string.Empty;
                case 0:
                    return Dictionary[0];
            }
            
            var result = new List<string>(10);

            if (n / 1000 > 0)
            {
                result.Add(ConvertNumberLessHundred(n / 1000));
                result.Add(Dictionary[1000]);
                n %= 1000;
            }

            if (n / 100 > 0)
            {
                result.Add(ConvertNumberLessHundred(n / 100));
                result.Add(Dictionary[100]);
                n %= 100;
            }

            result.Add(ConvertNumberLessHundred(n));

            return string.Join(" ", result);
        }
        
        private static string ConvertNumberLessHundred(int number)
        {
            if (number == 0)
                return string.Empty;
            
            return Dictionary.ContainsKey(number)
                ? Dictionary[number]
                : Dictionary[number / 10 * 10] + " " + Dictionary[number % 10];
        }
    }
}