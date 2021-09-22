using System.Globalization;
using System.Linq;

namespace Codewars.Three.Calculator
{
    public class OperationCreator
    {
        private string _firstDigit = string.Empty;
        private string _secondDigit = string.Empty;
        private char? _sign = null;

        internal void Push(char letter)
        {
            if (string.IsNullOrEmpty(_firstDigit))
            {
                _firstDigit += letter;
                return;
            }

            if (_sign == null)
            {
                if (char.IsDigit(letter) || letter == '.' || !_firstDigit.Any(char.IsDigit))
                {
                    _firstDigit += letter;
                    return;
                }

                _sign = letter;
                return;
            }

            if (string.IsNullOrEmpty(_secondDigit))
            {
                _secondDigit += letter;
                return;
            }

            if (char.IsDigit(letter) || letter == '.' || !_secondDigit.Any(char.IsDigit))
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

        private void Calculate()
        {
            _firstDigit = _firstDigit.Replace("--", "");
            _secondDigit = _secondDigit.Replace("--", "");
            var result = _sign == '+'
                ? double.Parse(_firstDigit, CultureInfo.InvariantCulture) + double.Parse(_secondDigit, CultureInfo.InvariantCulture)
                : double.Parse(_firstDigit, CultureInfo.InvariantCulture) - double.Parse(_secondDigit, CultureInfo.InvariantCulture);
            
            _firstDigit = result.ToString(CultureInfo.InvariantCulture);
        }
    }
}