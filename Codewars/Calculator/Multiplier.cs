using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Codewars.Three.Calculator
{
    public class Multiplier : IArithmetic
    {
        private string _expression;

        public Multiplier(string expression)
        {
            _expression = expression;
        }

        public string GetSimplifiedExpression()
        {
            const string pattern = @"-?\d*\.?\d+[/*]-?\d+\.?\d*";
            var regex = new Regex(pattern);
            var matches = regex.Matches(_expression);
            
            while (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    var operation = match.Value;
                    var result = MultiplyOrDivide(operation);
                    _expression = _expression.Replace(operation, result);
                }
                matches = regex.Matches(_expression);
            }

            return _expression;
        }
        
        private static string MultiplyOrDivide(string operation)
        {
            var signs = new[] { '*', '/' };
            var currentSign = operation.First(signs.Contains);
            var stringDigits = operation.Split(currentSign);
            var firstDigit = double.Parse(stringDigits[0]);
            var secondDigit = double.Parse(stringDigits[1]);
            var result = currentSign == '*'
                ? firstDigit * secondDigit
                : firstDigit / secondDigit;
            return result.ToString(CultureInfo.CurrentCulture);
        }
    }
}