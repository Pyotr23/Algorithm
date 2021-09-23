using System.Linq;
using System.Text.RegularExpressions;
using Codewars.Three.Calculator.Extensions;
using Codewars.Three.Calculator.Helpers;

namespace Codewars.Three.Calculator.Arithmetic
{
    internal sealed class Multiplier : Simplifier
    {
        internal Multiplier(string expression) : base(expression){ }
        
        internal override string GetSimplifiedExpression()
        {
            const string pattern = @"-?\d*\.?\d+[/*]-?-?\d+\.?\d*";
            var regex = new Regex(pattern);
            var matches = regex.Matches(Expression);
            
            while (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    var operation = match.Value;
                    var result = MultiplyOrDivide(operation);
                    Expression = Expression.Replace(operation, result);
                }
                matches = regex.Matches(Expression);
            }

            return Expression;
        }
        
        private static string MultiplyOrDivide(string operation)
        {
            operation = operation.Replace("--", "");
            var signs = new[] { '*', '/' };
            var currentSign = operation.First(signs.Contains);
            var stringDigits = operation.Split(currentSign);
            var firstDigit = stringDigits[0].ToDouble();
            var secondDigit = stringDigits[1].ToDouble();;
            var result = currentSign == '*'
                ? firstDigit * secondDigit
                : firstDigit / secondDigit;
            return result.ToString(CultureHelper.Culture);
        }
    }
}