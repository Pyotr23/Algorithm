using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementalWords
{
    internal static class Program
    {
        private static string _lowerCaseWord;
        private static ElementCollection _elementCollection;
        private static List<List<string>> _elementalFormList;

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
            _elementalFormList = new List<List<string>>();

            foreach (var key in _elementCollection.GetElementKeys(_lowerCaseWord))
            {
                ElementalForms(new List<string> {key});
            }

            return _elementCollection.GetElementalForms(_elementalFormList);
        }

        private static void ElementalForms(List<string> abbreviations)
        {
            
            if (_lowerCaseWord.Equals(StringHelper.GetJoinedString(abbreviations)))
            {
                _elementalFormList.Add(abbreviations);
                return;
            }

            var elementKeys = _elementCollection.GetElementKeys(_lowerCaseWord, abbreviations);
            
            foreach (var elementKey in elementKeys)
            {
                var enlargedAbbreviationList = new List<string>(abbreviations) {elementKey};
                ElementalForms(enlargedAbbreviationList);
            }
        }
    }
}