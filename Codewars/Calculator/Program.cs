using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Codewars.Three.Calculator
{
    class Program
    {
        // 12*-1
        // 12* 123/-(-5 + 2)
        // (1 - 2) + -(-(-(-4)))
        // 1 - -(-(-(-4)))
        // 12* 123/(-5 + 2)
        
        static void Main(string[] args)
        {
            const string example = "-12*-1";
            Console.WriteLine(Evaluate(example));
        }
        
        public static double Evaluate(string expression)
        {
            var symbols = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            expression = string.Concat(symbols);
            expression = ExpandBrackets(expression);
            expression = CalculateAllOccurrences(expression);
            return double.Parse(expression);
        }

        private static string ExpandBrackets(string expression)
        {
            const string bracketPattern = @"\([^\(\)]*\)";
            var regex = new Regex(bracketPattern);
            var matches = regex.Matches(expression);
            
            while (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    var operation = match.Value;
                    var operationWithoutBrackets = operation
                        .TrimStart('(')
                        .TrimEnd(')');
                    var result = CalculateAllOccurrences(operationWithoutBrackets);
                    expression = expression.Replace(operation, result);
                }
                matches = regex.Matches(expression);
            }

            return expression;
        }

        private static string CalculateAllOccurrences(string example)
        {
            const string highPriorityPattern  = @"-?\d*\.?\d+[/*]-?\d+\.?\d*";
            example = CalculateOccurrences(example, highPriorityPattern, new[]{'*', '/'});
            
            const string lowPriorityPattern  = @"\d*\.?\d+[+-]\d+\.?\d*";
            return CalculateOccurrences(example, lowPriorityPattern, new []{'+', '-'});
        }

        private static string CalculateOccurrences(string example, string pattern, char[] splittingSigns)
        {
            var regex = new Regex(pattern);
            var matches = regex.Matches(example);
            
            while (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    var operation = match.Value;
                    var result = Calculate(operation, splittingSigns);
                    example = example.Replace(operation, result);
                }
                matches = regex.Matches(example);
            }

            return example;
        }

        private static string Calculate(string operation, char[] splittingSigns)
        {
            var stringDigits = operation.Split(splittingSigns);
            var firstDigit = double.Parse(stringDigits[0]);
            var secondDigit = double.Parse(stringDigits[1]);
            var sign = operation.First(splittingSigns.Contains);
            var result = 0.0;
            
            switch (sign)
            {
                case '*':
                    result = firstDigit * secondDigit;
                    break;
                case '/':
                    result = firstDigit / secondDigit;
                    break;
                case '+':
                    result = firstDigit + secondDigit;
                    break;
                case '-':
                    result = firstDigit - secondDigit;
                    break;
            }

            return result.ToString(CultureInfo.CurrentCulture);
        }
    }
}