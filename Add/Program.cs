using System;

namespace Route256.OneStar.Add
{
    class Program
    {
        static void Main(string[] args)
        {
            var setsCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < setsCount; i++)
            {
                var number = int.Parse(Console.ReadLine());
                var res = IsPossibleToGet(number)
                    ? "YES"
                    : "NO";
                Console.WriteLine(res);
            }
        }

        private static bool IsPossibleToGet(int number)
        {
            if (number >= 990)
                return true;

            for (var i = number / 111 * 111; i >= 0; i -= 111)
            {
                var current = (number - i) % 11;
                if (current == 0)
                    return true;
            }

            return false;
        }
    }
}