using System;
using System.Text.RegularExpressions;

namespace Hard
{
    class Hard_591_tag_validator
    {
        static void Main(string[] args)
        {
            //string input = @"<DIV>>>  ![cdata[]] <![CDATA[<div>]>]]>]]>>]</DIV>";
            string input = "<TRUE><![CDATA[wahaha]]]><![CDATA[]> wahaha]]></TRUE>";
            Console.WriteLine(IsValid(input));
            Console.ReadKey();
        }

        public static bool IsValid(string code)
        {
            code = GetCodeWithDeletingCdata(code);            
            code = GetCodeWithCheckingTag(code);
            if (string.IsNullOrEmpty(code))
                return false;            
            return IsValidTags(code);
        }

        public static string GetCodeWithDeletingCdata(string code)
        {
            var regex = new Regex(@"<!\[CDATA\[.+\]\]>", RegexOptions.IgnoreCase);
            var match = regex.Match(code);
            string matchValue = match.Value;
            if (string.IsNullOrEmpty(match.Value))
                return code;
            return code.Replace(matchValue, string.Empty);
        }

        public static string GetCodeWithCheckingTag(string code)
        {            
            var regex = new Regex(@"(?<=^<(?<tagName>[A-Z]{1,9})>).+(?=</\k<tagName>>)");
            var match = regex.Match(code);
            return match.Value;
        }

        public static bool IsValidTags(string code)
        {
            var regex = new Regex(@"(?<=<)/?[A-Z]{1,9}(?=>)", RegexOptions.IgnoreCase);
            var matches = regex.Matches(code);            
            if (matches.Count == 0)
                return true;
            if (matches.Count % 2 != 0)
                return false;
            int start = 0;
            int end = matches.Count - 1;
            while(start != end)
            {
                if (matches[end].Value != $"/{matches[start].Value}")
                    return false;
                start++;
                end--;
            }
            return true;
        }
    }
}
