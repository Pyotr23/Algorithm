using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Four.Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglePermutations("aabb").ForEach(Console.WriteLine);
        }
        
        public static List<string> SinglePermutations(string s)
        {
            var hashSet = new HashSet<string>();
            Permute(hashSet, s, 0, s.Length - 1);
            return hashSet.ToList();
        }
        
        private static void Permute(HashSet<string> hashSet, 
            string str, 
            int leftIndex, 
            int rightIndex)
        {
            if (leftIndex != rightIndex)
            {
                for (var i = leftIndex; i <= rightIndex; i++)
                {
                    str = Swap(str, leftIndex, i);
                    Permute(hashSet, str, leftIndex + 1, rightIndex);
                    str = Swap(str, leftIndex, i);
                }
            }

            if (!hashSet.Contains(str))
                hashSet.Add(str);
        }

        private  static string Swap(string str, int leftIndex, int rightIndex)
        {
            var charArray = str.ToCharArray();
            (charArray[leftIndex], charArray[rightIndex]) = (charArray[rightIndex], charArray[leftIndex]);
            var result = new string(charArray);
            return result;
        }
    }
}