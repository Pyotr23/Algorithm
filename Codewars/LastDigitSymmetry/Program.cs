using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Codewars.Six.LastDigitSymmetry
{
    class Program
    {
        private static readonly HashSet<int> _primeDigits = new HashSet<int>();
        
        static void Main(string[] args)
        {
            Console.WriteLine(Solve(1, 1200));
        }

        public static int Solve(int min, int max)
        {
            var count = max - min + 1;
            var enumerable = Enumerable.Range(min, count);
            FillPrimeDigits();
            var result = 0;
            foreach (var digit in enumerable)
            {
                var stringDigit = digit.ToString();
                var stringSquare = Math.Pow(digit, 2).ToString(CultureInfo.InvariantCulture);
                if (IsSameLastTwoDigit(stringDigit, stringSquare)
                    && IsPrimeFirstTwoDigit(stringDigit)
                    && IsPrimeFirstTwoDigit(stringSquare)
                    )
                    result++;
            }

            return result;
        }

        private static void FillPrimeDigits()
        {
            var enumerable = Enumerable.Range(11, 99);
            foreach (var digit in enumerable)
            {
                if (IsPrime(digit))
                    _primeDigits.Add(digit);
            }
        }

        private static bool IsPrimeFirstTwoDigit(string value)
        {
            if (value.Length < 2)
                return false;
           
            var number = int.Parse(value[..2]);

            return _primeDigits.Contains(number);
        }

        private static bool IsSameLastTwoDigit(string value, string square)
        {
            if (value.Length < 2)
                return false;
            var valueInteger = int.Parse(value[^2..]);
            var squareInteger = int.Parse(square[^2..]);
            return valueInteger == squareInteger;
        }
        
        private static bool IsPrime(int numb)
        {
            if (!(numb % 2 == 0 || numb % 3 == 0 || numb % 5 == 0))
            { 
                for (var i = 3; i < numb / 3; i += 2)
                {
                    if ((double) numb % i != 0) 
                        continue;
                    
                    return false;
                }
            }
            else
                return false;
            
            return true;
        }
    }
}