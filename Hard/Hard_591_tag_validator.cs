using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hard
{
    class Hard_591_tag_validator
    {
        //static void Main(string[] args)
        //{
        //    //string input = @"<DIV>>>  ![cdata[]] <![CDATA[<div>]>]]>]]>>]</DIV>";
        //    string input = "<DIV>This is the first line <![CDATA[<div> <![cdata]> [[]]</div>   ]]>  <DIV> <A>  <![CDATA[<b>]]>  " +
        //        "</A>  <A> <C></C></A></DIV>    </DIV>";
        //    Console.WriteLine(IsValid(input));
        //    Console.ReadKey();
        //}

        public static bool IsValid(string code)
        {
            code = GetCodeWithDeletingCdata(code);
            Console.WriteLine(code);
            code = GetCodeWithCheckingFirstTag(code);
            Console.WriteLine(code);
            if (string.IsNullOrEmpty(code))
                return false;            
            return IsValidTagsAndBrackets(code);
        }

        public static string GetCodeWithDeletingCdata(string code)
        {
            var regex = new Regex(@"<!\[CDATA\[.*?\]\]>");
            var matches = regex.Matches(code);
            foreach(Match match in matches)
            {
                if (!(code.StartsWith(match.Value) || code.EndsWith(match.Value)))
                    code = code.Replace(match.Value, string.Empty);
            }            
            return code;
        }

        public static string GetCodeWithCheckingFirstTag(string code)
        {
            var regex = new Regex(@"(?<=^<)[A-Z]{1,9}(?=>)");
            var match = regex.Match(code);
            string startTag = match.Value;
            if (string.IsNullOrEmpty(startTag))
                return string.Empty;
            regex = new Regex($"</{startTag}>$", RegexOptions.IgnoreCase);
            match = regex.Match(code);
            if (string.IsNullOrEmpty(match.Value))
                return match.Value;
            return code;
        }

        public static bool IsValidTagsAndBrackets(string code)
        {
            var tagRegex = new Regex(@"(?<=<)/?[A-Z]{1,9}(?=>)");
            var anyTagRegex = new Regex(@"</?[^>]*>");            
            int tagsMatchesCount = tagRegex.Matches(code).Count;
            int anyTagsMatchesCount = anyTagRegex.Matches(code).Count;
            if (tagsMatchesCount != anyTagsMatchesCount)
                return false;
            var tags = tagRegex.Matches(code).Select(x => x.Value).ToArray();             
            var bracketRegex = new Regex("[<>]");
            var brackets = bracketRegex.Matches(code).Select(y => y.Value).ToArray();
            return IsValidTags(tags) && IsValidBrackets(brackets);
        }

        public static bool IsValidTags(string[] tags)
        {
            if (tags.Length == 0)
                return true;
            if (tags.Length % 2 != 0)
                return false;
            var tagStack = new Stack<string>();
            for (int i = 1; i <= tags.Length - 2; i++)
            {
                //if (tags[i].Length == 0 || tags[i].Length > 9)
                //    return false;
                //if (tags[i] != tags[i].ToUpper())
                //    return false;
                if (tags[i].StartsWith("/"))
                {
                    if (tagStack.Count == 0 || tags[i] != $"/{tagStack.Pop()}")
                        return false;
                }
                else
                    tagStack.Push(tags[i]);
            }
            return tagStack.Count == 0;
        }

        public static bool IsValidBrackets(string[] brackets)
        {                     
            for (int i = 2; i <= brackets.Length - 3; i++)
            {
                if (brackets[i] == "<")
                {
                    if (brackets[i + 1] == "<")
                        return false;
                }                
            }
            return true;
        }
    }
}
