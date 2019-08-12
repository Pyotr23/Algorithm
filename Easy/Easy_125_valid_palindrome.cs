using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Easy
{
    class Easy_125_valid_palindrome
    {
        static void Main(string[] args)
        {
            
            Console.ReadKey();
        }

        public static bool IsPalindrome(string s)
        {
            string lowerS = s.ToLower();
            Regex regex = new Regex("[a-z]");
            string modernS = regex.Matches(lowerS).ToString();
            char start;
            char finish;
            int length = s.Length
        }
    }
}
