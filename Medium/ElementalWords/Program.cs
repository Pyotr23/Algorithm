using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementalWords
{
    internal static class Program
    {
        private static string _lowerCaseWord;
        private static ElementCollection _elementCollection;

        private static void Main()
        {
            ElementalForms("snack")
                .ToList()
                .ForEach(variant =>
                {
                    var str = StringHelper.GetJoinedViaCommaString(variant);
                    Console.WriteLine(str);
                });
        }

        private static IEnumerable<string[]> ElementalForms(string word)
        {
            if (string.IsNullOrEmpty(word))
                return Array.Empty<string[]>();
            
            _lowerCaseWord = word.ToLower();
            _elementCollection = new ElementCollection();
            var resultList = new List<List<string>>();

            resultList = _elementCollection
                .GetElementKeys(_lowerCaseWord)
                .Aggregate(resultList, CheckElementKey());

            return _elementCollection.GetElementalForms(resultList);
        }

        private static Func<List<List<string>>, string, List<List<string>>> CheckElementKey()
        {
            return (current, elementKey) 
                => ElementalForms(new List<string> {elementKey}, current);
        }

        private static List<List<string>> ElementalForms(List<string> abbreviations, List<List<string>> resultList)
        {
            
            if (_lowerCaseWord.Equals(StringHelper.GetJoinedString(abbreviations)))
            {
                resultList.Add(abbreviations);
                return resultList;
            }

            var elementKeys = _elementCollection.GetElementKeys(_lowerCaseWord, abbreviations);
            
            foreach (var elementKey in elementKeys)
            {
                var enlargedAbbreviationList = new List<string>(abbreviations) {elementKey};
                ElementalForms(enlargedAbbreviationList, resultList);
            }

            return resultList;
        }
    }
}