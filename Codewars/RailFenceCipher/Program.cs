using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Three.RailFenceCipher
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine(Encode("WEAREDISCOVEREDFLEEATONCE", 3));
            Console.WriteLine(Decode("WECRLTEERDSOEEFEAOCAIVDEN", 3));
        }
        
        public static string Encode(string s, int n)
        {
            var lists = new List<List<char>>();

            for (var i = 0; i < n; i++)
            {
                lists.Add(new List<char>());
            }

            var listIndex = 0;
            var isForward = true;
            foreach (var letter in s)
            {
                lists[listIndex].Add(letter);

                if (listIndex == 0 && !isForward || listIndex == n - 1 && isForward)
                    isForward = !isForward;
                
                listIndex = isForward
                    ? listIndex + 1
                    : listIndex - 1;
            }
            return string.Concat(lists.SelectMany(x => x));
        }

        public static string Decode(string s, int n)
        {
            var dictionary = new Dictionary<int, List<int>>();
            for (var i = 0; i < n; i++)
            {
                dictionary.Add(i, new List<int>());
            }
            
            var listIndex = 0;
            var isForward = true;
            for (var i = 0; i < s.Length; i++)
            {
                dictionary[listIndex].Add(i);
                
                if (listIndex == 0 && !isForward || listIndex == n - 1 && isForward)
                    isForward = !isForward;
                
                listIndex = isForward
                    ? listIndex + 1
                    : listIndex - 1;
            }

            var letters = dictionary
                .SelectMany(pair => pair.Value)
                .ToArray();

            var decodedArray = new char[s.Length];
            for (var i = 0; i < s.Length; i++)
            {
                decodedArray[letters[i]] = s[i];
            }
            return new string(decodedArray);
        }
    }
}