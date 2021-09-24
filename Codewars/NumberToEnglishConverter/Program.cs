using System;
using System.Collections.Generic;

namespace Codewars.Five.NumberToEnglishConverter
{
    class Program
    {
        private static readonly Dictionary<int, string> _dictionary = new Dictionary<int, string>()
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

        static void Main(string[] args)
        {
            Console.WriteLine(NumberToEnglish(6800));
        }
        
        public static string NumberToEnglish(int n)
        {
            var result = string.Empty;
            
            if (n < 0 || n > 99999)
                return result;
        
            if (n / 1000 > 0)
            {
                result += ConvertNumberLessHundred(n / 1000) + " " + _dictionary[1000];
                n %= 1000;
            }

            if (n / 100 > 0)
            {
                result += " " + _dictionary[n / 100] + " " + _dictionary[100];
                n %= 100;
            }

            if (n != 0 || string.IsNullOrEmpty(result))
                result += " " + ConvertNumberLessHundred(n);

            return result.TrimStart();
        }
        
        private static string ConvertNumberLessHundred(int number)
        {
            return _dictionary.ContainsKey(number)
                ? _dictionary[number]
                : _dictionary[number / 10 * 10] + " " + _dictionary[number % 10];
        }
    }
}