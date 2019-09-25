using System;
using System.Text.RegularExpressions;

namespace Hard
{
    class Hard_591_tag_validator
    {
        static void Main(string[] args)
        {
            string input = "<DIV>This is the first line <![CDATA[<div>]]></DIV>";
            IsValid(input);            
            Console.ReadKey();
        }

        public static bool IsValid(string code)
        {
            string tag = GetTag(code);
            if (string.IsNullOrEmpty(tag))
                return false;
            code = code.Substring(tag.Length);
            string necessaryEndTag = tag.Insert(1, "/");            
            if (!code.EndsWith(necessaryEndTag))
                return false;
            code = code.Remove(code.Length - necessaryEndTag.Length);
            Console.WriteLine(code);
            return true;
        }

        public static string GetTag(string code)
        {
            var regex = new Regex(@"^<[A-Z]{1,9}>");
            var match = regex.Match(code);
            return match.Value;
        }

        public static string GetEndTag(string code, string endTag)
        {
            var regex = new Regex(endTag);
            var match = regex.Match(code);
            return match.Value;
        }
    }
}
