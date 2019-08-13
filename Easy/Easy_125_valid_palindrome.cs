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
            string str = "race a car";
            Console.WriteLine(IsPalindrome(str));
            Console.ReadKey();
        }

        public static bool IsPalindrome(string s)
        {
            s = s.ToLower();
            //Regex regex = new Regex("[a-z]");
            //string modernS = regex.Matches(lowerS).ToString();  
            int startIndex = 0;
            int finishIndex = s.Length - 1;
            while (startIndex < finishIndex)
            {                
                if (!char.IsLetterOrDigit(s[startIndex]))
                {
                    startIndex++;
                    continue;
                }
                if (!char.IsLetterOrDigit(s[finishIndex]))
                {
                    finishIndex--;
                    continue;
                }
                if (s[startIndex] != s[finishIndex])
                    return false;
                startIndex++;
                finishIndex--;
            }
            return true;
        }
    }
}
