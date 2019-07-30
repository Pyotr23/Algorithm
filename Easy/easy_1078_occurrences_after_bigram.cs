using System;
using System.Collections.Generic;

namespace Easy
{
    class Easy_1078_occurrences_after_bigram
    {
        //static void Main(string[] args)
        //{
        //    string inputString = "alice is a good girl she is a good student";
        //    string[] otvet = FindOcurrences(inputString, "a", "good");
        //    foreach (var x in otvet)
        //        Console.WriteLine(x);
        //    Console.ReadKey();
        //}

        private static string[] FindOcurrences(string text, string first, string second)
        {            
            string[] wordsArray = text.Split(" ");
            List<string> answearList = new List<string>();
            for (int i = 2; i < wordsArray.Length; i++)
            {
                if ((wordsArray[i - 1] == second) && (wordsArray[i - 2] == first))
                    answearList.Add(wordsArray[i]);
            }
            return answearList.ToArray();
        }
    }
}
