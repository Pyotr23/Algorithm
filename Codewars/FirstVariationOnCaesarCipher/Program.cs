using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Five.FirstVariationOnCaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            // var str = "I should have known that you would have a perfect answer for me!!!";
            var str = "I should have known that you would have a perfect answer for me!!!";
            var encoded = movingShift(str, 1);
            Console.WriteLine(demovingShift(encoded, 1));
        }
        
        public static List<string> movingShift(string s, int shift)
        {
            var bundles = Split(s);
            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            var encodedBundles = new List<string>(5);
            foreach (var bundle in bundles)
            {
                var characters = new Queue<char>();
                for (var i = 0; i < bundle.Length; i++, shift++)
                {
                    var character = bundle[i];
                    
                    if (!char.IsLetter(character))
                    {
                        characters.Enqueue(character);
                        continue;
                    }

                    var isUpper = char.IsUpper(character);
                    var index = alphabet.IndexOf(char.ToLower(character));
                    var newIndex = (index + shift) % 26;
                    characters.Enqueue(isUpper 
                        ? char.ToUpper(alphabet[newIndex])
                        : alphabet[newIndex]);
                }
                encodedBundles.Add(string.Concat(characters));
            }
            return encodedBundles;
        }

        public static string demovingShift(List<string> s, int shift)
        {
            var encodedString = string.Concat(s);
            var result = new Queue<char>();
            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            var reverseAlphabet = string.Concat(alphabet.Reverse());
            for (var i = 0; i < encodedString.Length; i++, shift++)
            {
                var character = encodedString[i];
                if (!char.IsLetter(character))
                {
                    result.Enqueue(character);
                    continue;
                }
                
                var isUpper = char.IsUpper(character);
                var index = alphabet.IndexOf(char.ToLower(character));
                var shiftIndex = index - shift;
                var newChar = shiftIndex >= 0
                    ? alphabet[shiftIndex]
                    : reverseAlphabet[(Math.Abs(shiftIndex) - 1) % 26];
                result.Enqueue(isUpper 
                    ? char.ToUpper(newChar)
                    : newChar);
            }
                
            return string.Concat(result);
        }

        private static List<string> Split(string text)
        {
            var length = text.Length;
            var maxBundleLength = (int) Math.Ceiling((double) length / 5);
            var bundles = new List<string>(5);
            var bundlesLength = 0;
            for (var i = 0; i < 5; i++)
            {
                string bundle;
                if (i <= 2)
                {
                    bundle = text.Substring(maxBundleLength * i, maxBundleLength);
                    bundlesLength += maxBundleLength;
                }
                else if (i == 3)
                {
                    var fourthBundleLength = Math.Min(maxBundleLength, length - bundlesLength);
                    bundle = text.Substring(maxBundleLength * i, fourthBundleLength);
                    bundlesLength += fourthBundleLength;
                }
                else
                {
                    bundle = bundlesLength == length
                        ? string.Empty
                        : text[bundlesLength..];
                }

                bundles.Add(bundle);
            }

            return bundles;
        }
    }
}