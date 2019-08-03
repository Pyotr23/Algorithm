using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    class Easy_202_happy_number
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsHappy(18));
            Console.ReadKey();
        }

        private static bool IsHappy(int n)
        {
            var hashSet = new HashSet<int>() { n };
            int squaresSum = 0;
            while (squaresSum != 1)
            {
                squaresSum = GetSquaresSum(n);
                if (hashSet.Contains(squaresSum))
                    return false;
                hashSet.Add(squaresSum);
                n = squaresSum;
            }
            return true;
        }

        private static int GetSquaresSum(int number)
        {
            string stringNumber = number.ToString();
            int result = 0;
            int tenDegree = 0;
            int digit = 0;
            for (int i = stringNumber.Length - 1; i >= 0; i--)
            {
                tenDegree = (int)Math.Pow(10, i);
                digit = number / tenDegree;
                result += (int)Math.Pow(digit, 2);
                number %= tenDegree;
            }
            return result;
        }
    }
}
