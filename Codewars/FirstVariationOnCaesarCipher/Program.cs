using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Five.FirstVariationOnCaesarCipher
{
    class Program
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        private const string ReverseAlphabet = "zyxwvutsrqponmlkjihgfedcba";
        private static readonly int AlphabetLength = Alphabet.Length;

        static void Main(string[] args)
        {
            const string? str = "I should have known that you would have a perfect answer for me!!!";
            const int shift = 1;
            var encoded = movingShift(str, shift);
            Console.WriteLine(string.Concat(encoded));
            Console.WriteLine(demovingShift(encoded, shift));
        }
        
        public static List<string> movingShift(string s, int shift)
        {
            var bundles = Split(s);
            var encodedBundles = new List<string>(5);
            
            foreach (var bundle in bundles)
            {
                var encryptedChars = new Queue<char>();
                
                for (var i = 0; i < bundle.Length; i++, shift++)
                {
                    var current = bundle[i];
                    
                    if (!char.IsLetter(current))
                    {
                        encryptedChars.Enqueue(current);
                        continue;
                    }

                    var isUpper = char.IsUpper(current);
                    current = char.ToLower(current);
                    var currentIndex = Alphabet.IndexOf(current);
                    var shiftedIndex = currentIndex + shift;
                    var encryptedChar = GetShiftedChar(shiftedIndex);
                    
                    encryptedChar = isUpper
                        ? char.ToUpper(encryptedChar)
                        : encryptedChar;

                    encryptedChars.Enqueue(encryptedChar);
                }
                encodedBundles.Add(string.Concat(encryptedChars));
            }
            return encodedBundles;
        }

        public static string demovingShift(List<string> s, int shift)
        {
            var encodedString = string.Concat(s);
            var decryptedChars = new Queue<char>();
            
            for (var i = 0; i < encodedString.Length; i++, shift++)
            {
                var current = encodedString[i];
                
                if (!char.IsLetter(current))
                {
                    decryptedChars.Enqueue(current);
                    continue;
                }
                
                var isUpper = char.IsUpper(current);
                current = char.ToLower(current);
                var currentIndex = Alphabet.IndexOf(current);
                var shiftedIndex = currentIndex - shift;

                var decryptedChar = GetShiftedChar(shiftedIndex);

                decryptedChar = isUpper
                    ? char.ToUpper(decryptedChar)
                    : decryptedChar;
                
                decryptedChars.Enqueue(decryptedChar);
            }
                
            return string.Concat(decryptedChars);
        }

        private static char GetShiftedChar(int index)
        {
            var decryptedChar = ' ';
            
            if (index >= 0)
                decryptedChar = Alphabet[index % AlphabetLength];
            else
            {
                index = (Math.Abs(index) - 1) % AlphabetLength;
                decryptedChar = ReverseAlphabet[index];
            }

            return decryptedChar;
        }

        private static List<string> Split(string text)
        {
            var length = text.Length;
            var maxBundleLength = (int) Math.Ceiling((double) length / 5);
            var bundles = new List<string>(5);
            var bundlesLength = 0;
            
            for (var i = 0; i < 5; i++)
            {
                var bundleLength = Math.Min(maxBundleLength, length - bundlesLength);
                var startIndex = Math.Min(maxBundleLength * i, length);
                var bundle = text.Substring(startIndex, bundleLength);
                
                bundlesLength += bundleLength;
                bundles.Add(bundle);
            }

            return bundles;
        }
    }
}