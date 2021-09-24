using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Four.StringsMix
{
    internal static class Program
    {
        private static void Main()
        {
            const string first = "A generation must confront the looming ";
            const string second = "codewarrs";
            Console.WriteLine(Mix(first, second));
        }

        private static string Mix(string s1, string s2)
        {
            var dictionary = new Dictionary<char, string[]>();
            
            foreach (var letter in s1.Where(l => char.IsLetter(l) && char.IsLower(l)))
            {
                if (dictionary.ContainsKey(letter))
                {
                    dictionary[letter][0] = dictionary[letter][0] + letter;
                    continue;
                }
                dictionary.Add(letter, new[]{ letter.ToString(), string.Empty });
            }
            
            foreach (var letter in s2.Where(l => char.IsLetter(l) && char.IsLower(l)))
            {
                if (dictionary.ContainsKey(letter))
                {
                    dictionary[letter][1] = dictionary[letter][1] + letter;
                    continue;
                }
                dictionary.Add(letter, new[]{ string.Empty, letter.ToString() });
            }

            var result = dictionary
                .Where(pair => pair.Value[0].Length > 1 || pair.Value[1].Length > 1)
                .Select(pair =>
                {
                    var (_, value) = pair;
                    var firstMax = value[0].Length;
                    var secondMax = value[1].Length;
                    
                    if (firstMax > secondMax)
                        return $"1:{value[0]}";
                    if (secondMax > firstMax)
                        return $"2:{value[1]}";
                    return $"=:{value[0]}";
                })
                .OrderByDescending(x => x.Length)
                .ThenBy(y =>
                {
                    return y[0] switch
                    {
                        '1' => 0,
                        '2' => 1,
                        _ => 2
                    };
                })
                .ThenBy(z => z);
            
            return string.Join('/', result);
        }
    }
}