using System.Linq;
using Codewars.Three.Calculator.Extensions;
using Codewars.Three.Calculator.Helpers;

namespace Codewars.Three.Calculator.Arithmetic
{
    public class AddingMachine
    {
        private string _firstDigit = string.Empty;
        private string _secondDigit = string.Empty;
        private char? _sign;

        internal void Push(char letter)
        {
            if (string.IsNullOrEmpty(_firstDigit))
            {
                _firstDigit += letter;
                return;
            }

            if (_sign == null)
            {
                if (IsNeedFill(_firstDigit, letter))
                {
                    _firstDigit += letter;
                    return;
                }

                _sign = letter;
                return;
            }

            if (string.IsNullOrEmpty(_secondDigit) || IsNeedFill(_secondDigit, letter))
            {
                _secondDigit += letter;
                return;
            }

            Calculate();
            _sign = letter;
            _secondDigit = string.Empty;
        }
        
        internal string GetResult()
        {
            if (_sign != null)
                Calculate();
            _firstDigit = _firstDigit.Replace("--", "");
            return _firstDigit;
            
        }

        private static bool IsNeedFill(string digit, char letter)
        {
            return char.IsDigit(letter)
                   || letter == '.'
                   || !digit.Any(char.IsDigit);
        }

        private void Calculate()
        {
            _firstDigit = _firstDigit.Replace("--", "");
            _secondDigit = _secondDigit.Replace("--", "");
            
            var result = _sign == '+'
                ? _firstDigit.ToDouble() + _secondDigit.ToDouble()
                : _firstDigit.ToDouble() - _secondDigit.ToDouble();
            
            _firstDigit = result.ToString(CultureHelper.Culture);
        }
    }
}