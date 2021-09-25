using System;
using System.Collections.Generic;

namespace Codewars.Four.Permutations
{
    class Program
    {
        private static HashSet<string> _hashSet = new HashSet<string>();
        static void Main(string[] args)
        {
            var list = SinglePermutations("aabb");
        }
        
        public static List<string> SinglePermutations(string s)
        {
            var hashSet = new HashSet<string>();
            Permute(s, 0, s.Length - 1);
            return null;
        }
        
        private static void Permute(string str, int leftIndex, int rightIndex)
        {
            if (leftIndex != rightIndex)
            {
                for (var i = leftIndex; i <= rightIndex; i++)
                {
                    str = Swap(str, leftIndex, i);
                    Permute(str, leftIndex + 1, rightIndex);
                    str = Swap(str, leftIndex, i);
                }
            }

            if (!_hashSet.Contains(str))
                _hashSet.Add(str);
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