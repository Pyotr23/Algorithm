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
            var inputChars = messages
                .SelectMany(m => m.ToCharArray())
                .ToArray();
            var outputChars = secrets
                .SelectMany(s => s.ToCharArray())
                .ToArray();
            var hashSet = new HashSet<string>();
            for (var i = 0; i < inputChars.Length; i++)
            {
                if (inputChars[i] == outputChars[i])
                    continue;

                var key = (char)Math.Min(inputChars[i], outputChars[i]);
                var value = (char) Math.Max(inputChars[i], outputChars[i]);
                var str = string.Join("", key, value);
                if (!hashSet.Contains(str))
                    hashSet.Add(str);
            }

            return string.Join("", hashSet.OrderBy(x => x).ToArray());
        }
    }
}