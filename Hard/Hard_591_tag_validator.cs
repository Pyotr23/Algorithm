using System;
using System.Text.RegularExpressions;

namespace Hard
{
    class Hard_591_tag_validator
    {
        static void Main(string[] args)
        {
            string input = @"<DIV>>>  ![cdata[]] <![CDATA[<div>]>]]>]]>>]</DIV>";
            //string input = "<DIV>This is the first line <![CDATA[<div>]]></DIV>";            
            Console.WriteLine(IsValid(input));
            Console.ReadKey();
        }

        public static bool IsValid(string code)
        {
            code = GetCodeWithDeletingCdata(code);
            Console.WriteLine(code);
            code = GetCodeWithCheckingTag(code);
            if (string.IsNullOrEmpty(code))
                return false;            
            return true;
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
    }
}
