using System;

namespace Easy
{
    class Easy_1078_occurrences_after_bigram
    {
        static void Main(string[] args)
        {
            string inputString = "we will we will rock you";
            FindOcurrences(inputString, "we", "will");
            Console.WriteLine("Hello World!");
        }

        private static string[] FindOcurrences(string text, string first, string second)
        {
            string[] array = text.Split($"{first} {second}");
            foreach (var x in array)
                Console.WriteLine(x);
            return new string[] { "" };
        }
    }
}
