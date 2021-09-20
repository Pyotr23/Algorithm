using System;
using System.Collections.Generic;

namespace Codewars.Five.ValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ValidParentheses("(())((()())())"));
        }
        
        public static bool ValidParentheses(string input)
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