using System;
using System.Collections.Generic;

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
            if (string.IsNullOrEmpty(input))
                return true;

            var stack = new Stack<char>();

            foreach (var letter in input)
            {
                switch (letter)
                {
                    case '(':
                        stack.Push(letter);
                        break;
                    case ')':
                        if (stack.TryPop(out var lastParentheses) || lastParentheses == '(')
                            break;
                        return false;
                }
            }
            
            return stack.Count == 0;
        }
    }
}