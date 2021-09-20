using System;

namespace Codewars.Five.ValidParentheses
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine(ValidParentheses("(())((()())())"));
        }

        private static bool ValidParentheses(string input)
        {
            var count = 0;
            foreach (var letter in input)
            {
                switch (letter)
                {
                    case '(':
                        count++;
                        break;
                    case ')':
                    {
                        count--;
                        if (count < 0)
                            return false;
                        break;
                    }
                }
            }
            
            return count == 0;
        }
    }
}