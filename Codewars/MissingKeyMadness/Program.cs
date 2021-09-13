using System;
using System.Collections.Generic;
using System.Linq;

namespace Corewars.Five.MissingKeyMadness
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SearchForKey(
                new[]{ "dance", "level", "right", "yours" }, 
                new []{ "tpnes", "irvri", "dkucr", "elghy" }));
        }
        
        public static string SearchForKey(string[] messages, string[] secrets)
        {
            var messageVariants = GetPermutations(messages, messages.Length).ToArray();
            var secret = string.Join("", secrets);
            foreach (var message in messageVariants)
            {
                var secretWord = SearchForKey(message, secret);
                if (secretWord.Length == 12)
                    return secretWord;
            }

            return string.Empty;
        }
        
        private static string SearchForKey(string message, string secret)
        {
            var hashSet = new HashSet<string>();
            
            for (var i = 0; i < message.Length; i++)
            {
                if (message[i] == secret[i])
                    continue;

                var key = (char)Math.Min(message[i], secret[i]);
                var value = (char) Math.Max(message[i], secret[i]);
                var str = string.Join("", key, value);
                if (!hashSet.Contains(str))
                    hashSet.Add(str);
            }

            return string.Join("", hashSet.OrderBy(x => x).ToArray());
        }
        
        private static IEnumerable<string> GetPermutations(IEnumerable<string> list, int length)
        {
            if (length == 1) 
                return list;
        
            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(t2))
                .Select(x => string.Join("", x));
        }
    }
}