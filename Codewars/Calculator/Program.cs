using System;
using System.Text.RegularExpressions;
using Codewars.Three.Calculator.Arithmetic;
using Codewars.Three.Calculator.Extensions;

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
            var example = "1 - -(-(-(-4)))"; // "2 / 2 + 3 * 4 - 6";
            Console.WriteLine(Evaluate(example));
            example = "-12*-1";
            Console.WriteLine(Evaluate(example));
            example = "12* 123/-(-5 + 2)";
            Console.WriteLine(Evaluate(example));
        }
        
        public static double Evaluate(string expression)
        {
            var symbols = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            expression = string.Concat(symbols);
            expression = ExpandBrackets(expression);
            expression = Calculate(expression);
            return expression.ToDouble();
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
                    var result = Calculate(operationWithoutBrackets);
                    expression = expression.Replace(operation, result);
                }
                matches = regex.Matches(expression);
            }

            return expression;
        }

        private static string Calculate(string example)
        {
            var multiplier = new Multiplier(example);
            example = multiplier.GetSimplifiedExpression();

            var adder = new Adder(example);
            return adder.GetSimplifiedExpression();
        }
    }
}