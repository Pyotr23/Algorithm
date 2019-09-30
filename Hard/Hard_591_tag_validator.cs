using System;
using System.Text.RegularExpressions;

namespace Hard
{
    class Hard_591_tag_validator
    {
        static void Main(string[] args)
        {
            string input = "<DIV>This is the first line <![CDATA[<div>]]></DIV>";            
            Console.WriteLine(IsValid(input));
            Console.ReadKey();
        }

        public static bool IsValid(string code)
        {
            string codeWithoutMainTag = GetCodeWithCheckingTag(code);
            if (string.IsNullOrEmpty(codeWithoutMainTag))
                return false;            
            return true;
        }

        public static string GetCodeWithCheckingTag(string code)
        {            
            var regex = new Regex(@"(?<=^<(?<tagName>[A-Z]{1,9})>).+(?=</\k<tagName>>)");
            var match = regex.Match(code);
            return match.Value;
        }
    }
}
