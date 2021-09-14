using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Codewars.Six.LastDigitSymmetry
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve(1, 1200));
        }

        public static int Solve(int min, int max)
        {
            var count = max - min + 1;
            var enumerable = Enumerable.Range(min, count);
            var result = 0;
            foreach (var digit in enumerable)
            {
                var stringDigit = digit.ToString();
                var stringSquare = Math.Pow(digit, 2).ToString(CultureInfo.InvariantCulture);
                if (IsPrimeFirstTwoDigit(stringDigit)
                    && IsPrimeFirstTwoDigit(stringSquare)
                    && IsSameLastTwoDigit(stringDigit, stringSquare))
                    result++;
            }

            return result;
        }

        private static bool IsPrimeFirstTwoDigit(string value)
        {
            if (value.Length < 2)
                return false;
            var number = int.Parse(string.Join("", value[..2]));
            return IsPrime(number);
        }

        private static bool IsSameLastTwoDigit(string value, string square)
        {
            if (value.Length < 2)
                return false;
            var valueInteger = int.Parse(string.Join("", value[^2..]));
            var squareInteger = int.Parse(string.Join("", square[^2..]));
            return valueInteger == squareInteger;
        }
        
        private static bool IsPrime(int numb)
        {
            if (numb is 3 or 5)
                return true;
            
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